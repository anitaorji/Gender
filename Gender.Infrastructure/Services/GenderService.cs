using Gender.Application.Common;
using Gender.Application.DTOs;
using Gender.Application.Interfaces;
using Gender.Application.Validators;
using System.Net.Http.Json;

namespace Gender.Infrastructure.Services
{
    public class GenderService : IGenderService
    {
        private readonly HttpClient _httpClient;
         
        public GenderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult> GetGenderAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ServiceResult.Error("Missing or empty name parameter", 400);
            }

            try
            {
                var url = $"https://api.genderize.io?name={name}";
                var httpResponse = await _httpClient.GetAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return ServiceResult.Error("Upstream failure", 502);
                }
                ;

                if (NameValidator.IsInvalid(name))
                {
                    return ServiceResult.Error("Name is not a string", 422);
                }
                ;

                var response = await httpResponse.Content.ReadFromJsonAsync<GenderApiResponse>();
                var data = new GenderResponseDto
                {
                    Gender = response.Gender,
                    Probability = response.Probability,
                    SampleSize = response.Count,
                    IsConfident = response.Probability >= 0.7 && response.Count >= 100,
                    ProcessedAt = DateTime.UtcNow.ToString("o")
                };

                return ServiceResult.Success(data);
            }
            catch (Exception)
            {
                return ServiceResult.Error("Server failure", 500);

            }
        }
    }
}

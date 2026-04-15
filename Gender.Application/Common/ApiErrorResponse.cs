namespace Gender.Application.Common
{
    public class ApiErrorResponse
    {
        public string Status { get; set; } = "error";
        public string Message { get; set; }
    }
}

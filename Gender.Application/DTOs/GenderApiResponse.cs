namespace Gender.Application.DTOs
{
    public class GenderApiResponse
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Probability { get; set; }
        public int Count { get; set; }
    }
}

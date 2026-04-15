namespace Gender.Application.Common
{
    public class ApiSuccessResponse<T>
    {
        public string Status { get; set; } = "success";
        public T Data { get; set; }
    }
}

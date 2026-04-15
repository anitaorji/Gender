namespace Gender.Application.Common
{
    public class ServiceResult
    {
        public int StatusCode { get; set; }
        public object Response { get; set; }


        public static ServiceResult Success(object data)
        {
            return new ServiceResult
            {
                StatusCode = 200,
                Response = new
                {
                    status = "success",
                    data
                }
            };
        }

        public static ServiceResult Error(string message, int statusCode)
        {
            return new ServiceResult
            {
                StatusCode = statusCode,
                Response = new
                {
                    status = "error",
                    message
                }
            };
        }
    }
}


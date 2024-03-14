namespace MusicLab.Repository.Models.ResponseModel
{
    public class CustomErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }

        public CustomErrorResponseModel(int statusCode, string message, Dictionary<string, string[]> errors)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }

        public CustomErrorResponseModel()
        {
        }
    }
}

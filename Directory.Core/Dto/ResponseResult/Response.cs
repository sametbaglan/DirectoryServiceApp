using Directory.Core.Validation.ValidMessage;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Directory.Core.Dto.ResponseResult
{
    public class Response<T>
    {
        public T data { get; set; }
        public int statuscode { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }
        public static Response<T> Success(T data, int statuscode)
        {
            return new Response<T> { data = data, statuscode = statuscode, IsSuccess = true, message = AllMessages.IsSuccess };
        }
        public static Response<T> Success(int statuscode)
        {
            return new Response<T> { data = default, statuscode = 200, IsSuccess = true, message = AllMessages.IsSuccess };
        }
        public static Response<T> Fail(List<string> errors, int statuscode)
        {
            return new Response<T> { errors = errors, statuscode = statuscode, IsSuccess = false, message = AllMessages.IsFail };
        }
        public static Response<T> Fail(string error, int statuscode)
        {
            var errors = new List<string>();
            errors.Add(error);
            return new Response<T> { errors = errors, statuscode = statuscode, IsSuccess = false, message = AllMessages.IsFail };
        }
    }
}

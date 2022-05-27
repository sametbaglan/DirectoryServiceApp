using Directory.Core.Dto.ResponseResult;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers
{


    public class BaseCustomController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(Response<T> response)
        {
            if (response.statuscode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.statuscode
                };
            return new ObjectResult(response)
            {
                StatusCode = response.statuscode
            };
        }
    }
}

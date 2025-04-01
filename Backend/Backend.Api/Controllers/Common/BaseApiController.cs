using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly ISender _sender;
        protected BaseApiController(ISender sender)
        {
            _sender = sender;
        }
    }
}

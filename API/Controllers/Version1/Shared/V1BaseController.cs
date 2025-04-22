using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Shared;

[ApiVersion("1.0")]
[ApiController]
[Route("api/[controller]")]
public class V1BaseController : ControllerBase
{
}

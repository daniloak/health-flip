using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace GD.HealthFlip.Api.Providers;

public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
{
  public override IActionResult CreateResponse(ErrorResponseContext context)
  {
    var response = new BadRequestResult();

    return response;
  }
}

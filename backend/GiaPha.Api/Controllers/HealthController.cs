using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GiaPha.Api.Controllers;

[ApiController]
[Route("api/health")]
public sealed class HealthController : ControllerBase
{
    private readonly AuthAccessOptions _authAccess;

    public HealthController(IOptions<AuthAccessOptions> authAccess)
    {
        _authAccess = authAccess.Value;
    }

    [HttpGet]
    public ActionResult<HealthResponse> Get()
    {
        return Ok(new HealthResponse(
            Status: "ok",
            Service: "GiaPha.Api",
            AllowedEmailCount: _authAccess.AllowedEmails.Length));
    }
}

public sealed record HealthResponse(
    string Status,
    string Service,
    int AllowedEmailCount);

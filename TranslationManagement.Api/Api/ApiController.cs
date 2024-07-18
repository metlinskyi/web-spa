namespace TranslationManagement.Api;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public abstract class ApiController : ControllerBase 
{
    protected IActionResult InternalError(string message)
    {
        return StatusCode(500, message);
    }
}
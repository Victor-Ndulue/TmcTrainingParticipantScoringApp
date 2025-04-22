using API.Controllers.Version1.Shared;
using Application.AdminServices.Interfaces;
using Application.Helpers.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Admin;

public class SessionsController : V1BaseController
{
    private readonly IEvaluationSessionService _sessionService;

    public SessionsController(IEvaluationSessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession(CreateSessionRequest request)
    {
        var result = await _sessionService.CreateSessionAsync(request.TopicId, request.StudentIds, request.EvaluatorIds);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetSessions()
        => Ok(await _sessionService.GetAllSessionsAsync());
}

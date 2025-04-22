using API.Controllers.Version1.Shared;
using Application.AdminServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Admin;

public class ScoreboardController : V1BaseController
{
    private readonly IScoreboardService _scoreboardService;

    public ScoreboardController(IScoreboardService scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetScoreboard()
        => Ok(await _scoreboardService.GetScoreboardAsync());
}

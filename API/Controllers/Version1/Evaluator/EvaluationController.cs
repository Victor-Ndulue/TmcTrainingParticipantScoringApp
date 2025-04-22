using API.Controllers.Version1.Shared;
using Application.EvaluatorServices.Interfaces;
using Application.Helpers.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Evaluator;

public class EvaluationController : V1BaseController
{
    private readonly IEvaluationService _evaluationService;

    public EvaluationController(IEvaluationService evaluationService)
    {
        _evaluationService = evaluationService;
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitScore(EvaluationRequest request)
    {
        await _evaluationService.SubmitScoreAsync(request.EvaluatorId, request.StudentId, request.TopicId, request.Score);
        return Ok("Score submitted");
    }

    [HttpGet("average")]
    public async Task<IActionResult> GetAverage(int studentId, int topicId)
    {
        var avg = await _evaluationService.GetAverageScoreAsync(studentId, topicId);
        return Ok(avg);
    }

    [HttpGet("check-all-submitted")]
    public async Task<IActionResult> AreAllSubmitted(int studentId, int topicId)
    {
        var result = await _evaluationService.AreAllScoresSubmitted(studentId, topicId);
        return Ok(result);
    }
}
using API.Controllers.Version1.Shared;
using Application.AdminServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Admin;

public class TopicsController : V1BaseController
{
    private readonly ITopicService _topicService;

    public TopicsController(ITopicService topicService) => _topicService = topicService;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _topicService.GetAllTopicsAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
        => Ok(await _topicService.CreateTopicAsync(name));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] string name)
        => Ok(await _topicService.UpdateTopicAsync(id, name));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _topicService.DeleteTopicAsync(id));
}

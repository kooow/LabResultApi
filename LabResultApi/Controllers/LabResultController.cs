using Microsoft.AspNetCore.Mvc;

namespace LabResultApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LabResultController : ControllerBase
{
    private readonly ILogger<LabResultController> _logger;

    public LabResultController(ILogger<LabResultController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetEntities")]
    public IEnumerable<TestEntity> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new TestEntity
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Data = Random.Shared.Next(-20, 55),
            Summary = string.Empty,
        })
        .ToArray();
    }
}

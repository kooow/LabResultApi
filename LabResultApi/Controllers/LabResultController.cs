using LabResultApi.Entities;
using LabResultApi.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LabResultApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LabResultController : ControllerBase
{
    private readonly ILogger<LabResultController> _logger;
    private readonly ILabResultRepository _labResultRepository;
    public LabResultController(ILogger<LabResultController> logger,
        ILabResultRepository labResultRepository)
    {
        _logger = logger;
        _labResultRepository = labResultRepository;
    }

    [HttpGet(Name = "GetLabResults")]
    public IEnumerable<LabResult> GetLabResults()
    {
        IEnumerable<LabResult> results = [];
        try
        {
            results = _labResultRepository.GetAll();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error!");
        }
        return results;
    }
}

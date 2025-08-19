using LabResultApi.Services.DbContext;

namespace LabResultApi.Services;

public class TestDataSeeder
{
    private readonly LabResultDbContext _context;
    private readonly ILoaderService _loaderService;

    public TestDataSeeder(LabResultDbContext context,
        ILoaderService loaderService)
    {
        _context = context;
        _loaderService = loaderService;
    }

    public void Seed()
    {
        SeedLabResults();
    }

    private void SeedLabResults()
    {
        if (_context.LabResults.Any())
        {
            return;
        }

        try
        {
            var fileFullPath = _loaderService.GetDataFilePath();
            var results = _loaderService.LoadResultsFromFile(fileFullPath);

            _context.LabResults.AddRange(results);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error during the seed: {ex.Message}");
        }
    }
}

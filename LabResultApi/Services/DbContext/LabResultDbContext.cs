using LabResultApi.Entities;

namespace LabResultApi.Services.DbContext;

public class LabResultDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public LabResultDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<LabResultDbContext> options) : base(options)
    {
    }

    public Microsoft.EntityFrameworkCore.DbSet<LabResult> LabResults { get; set; }
}

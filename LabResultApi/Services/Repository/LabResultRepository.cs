using LabResultApi.Entities;
using LabResultApi.Services.DbContext;

namespace LabResultApi.Services.Repository;

public class LabResultRepository : Repository<LabResult>, ILabResultRepository
{
    public LabResultRepository(LabResultDbContext context) : base(context)
    {
    }
}
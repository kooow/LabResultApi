using LabResultApi.Entities;

namespace LabResultApi.Services;

public interface ILoaderService
{
    string GetDataFilePath();

    List<LabResult> LoadResultsFromFile(string fileFullPath);
}

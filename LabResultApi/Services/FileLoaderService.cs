using LabResultApi.Entities;

namespace LabResultApi.Services;

public class FileLoaderService : ILoaderService
{
    public readonly static string FileDirectory = "DataFiles";
    public readonly static string FileName = "Software Developer Test - Appendix Q10.txt";

    private readonly static char DelimiterChar = '|';

    public string GetDataFilePath()
    {
        var dataFileFullPath = Path.Combine(Environment.CurrentDirectory, FileDirectory, FileName);
        return dataFileFullPath;
    }

    public List<LabResult> LoadResultsFromFile(string fileFullPath)
    {
        if (!File.Exists(fileFullPath))
        {
            throw new FileNotFoundException(fileFullPath);
        }

        var allLinesInFile = File.ReadAllText(fileFullPath);

        var stringReader = new StringReader(allLinesInFile);

        var comment1 = stringReader.ReadLine();
        var comment2 = stringReader.ReadLine();
        var comment3 = stringReader.ReadLine();

        var dataFieldsHeader = stringReader.ReadLine();
        if (string.IsNullOrEmpty(dataFieldsHeader))
        {
            throw new FormatException("Data fields header format missing!");
        }

        var dataFields = dataFieldsHeader.Split(DelimiterChar);
        List<string> lines = new ();

        string? line;
        do
        {
            line = stringReader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                lines.Add(line);
            }
        }
        while (line != null);

        var datas = ConvertFromLines(dataFields, lines);
        return datas;
    }

    private static List<LabResult> ConvertFromLines(string[] dataFields, List<string> lines)
    {
        List<LabResult> labResults = new ();

        foreach (var line in lines)
        {
            string[] values = line.Split(DelimiterChar);

            if (dataFields.Length != values.Length)
            {
                throw new FormatException($"Header fields and values are different: {dataFields.Length} != {values.Length}!");
            }

            var result = new LabResult
            {
                CLINIC_NO = int.Parse(values[0]),
                BARCODE = values[1],
                PATIENT_ID = int.Parse(values[2]),
                PATIENT_NAME = values[3],
                DOB = DateOnly.TryParseExact(values[4], "yyyy-MM-dd", out var dobDate) ? dobDate : null,
                GENDER = char.Parse(values[5]),
                COLLECTIONDATE = DateOnly.TryParseExact(values[6], "yyyy-MM-dd", out var collectionDate) ? collectionDate : null,
                COLLECTIONTIME = TimeOnly.TryParseExact(values[7], "hh:mm", out var collectionTime) ? collectionTime : null,
                TESTCODE = values[8],
                TESTNAME = values[9],
                RESULT = values[10],
                UNIT = values[11],
                REFRANGELOW = values[12],
                REFRANGEHIGH = values[13],
                NOTE = values[14],
                NONSPECREFS = values[15]
            };

            labResults.Add(result);
        }
        return labResults;
    }
}

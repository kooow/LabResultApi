namespace LabResultApi.Entities;

public class LabResult
{
    public int? CLINIC_NO { get; set; }
    public string? BARCODE { get; set; }
    public int? PATIENT_ID { get; set; }
    public string? PATIENT_NAME { get; set; }
    public DateOnly? DOB { get; set; }
    public char GENDER { get; set; }
    public DateOnly? COLLECTIONDATE { get; set; }
    public TimeOnly? COLLECTIONTIME { get; set; }
    public string? TESTCODE { get; set; }
    public string? TESTNAME { get; set; }
    public string? RESULT { get; set; }
    public string? UNIT { get; set; }
    public string? REFRANGELOW { get; set; }
    public string? REFRANGEHIGH { get; set; }
    public string? NOTE { get; set; }
    public string? NONSPECREFS { get; set; }
}
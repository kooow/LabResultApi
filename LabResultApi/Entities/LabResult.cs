using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LabResultApi.Entities;

public class LabResult
{
    [JsonPropertyName("Clinic number")]
    public int CLINIC_NO { get; set; }

    [Key]
    [JsonPropertyName("Barcode")]
    public string BARCODE { get; set; } = string.Empty;

    [JsonPropertyName("Patient id")]
    public int PATIENT_ID { get; set; }

    [JsonPropertyName("Patient name")]
    public string PATIENT_NAME { get; set; } = string.Empty;
    
    [JsonPropertyName("Date of birth")]
    public DateOnly DOB { get; set; }

    [JsonPropertyName("Gender")]
    public char GENDER { get; set; }

    [JsonPropertyName("Collection")]
    public DateTime COLLECTION { get; set; }

    [JsonPropertyName("TestCode")]
    public string TESTCODE { get; set; } = string.Empty;

    [JsonPropertyName("Test name")]
    public string TESTNAME { get; set; } = string.Empty;

    [JsonPropertyName("Result")]
    public string RESULT { get; set; } = string.Empty;

    [JsonPropertyName("Unit")]
    public string UNIT { get; set; } = string.Empty;

    [JsonPropertyName("Refrange low")]
    public string REFRANGELOW { get; set; } = string.Empty;

    [JsonPropertyName("Refrange high")]
    public string REFRANGEHIGH { get; set; } = string.Empty;
    [JsonPropertyName("Note")] 
    public string NOTE { get; set; } = string.Empty;

    [JsonPropertyName("NonSpecRefs")] 
    public string NONSPECREFS { get; set; } = string.Empty;
}
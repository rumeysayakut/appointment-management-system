using System.Net.Http.Json;
using AppointmentManagementSystem.Application.Interfaces.ExternalServices;

namespace AppointmentManagementSystem.Infrastructure.ExternalServices;

public class PatientPriorityService : IPatientPriorityService
{
    private readonly HttpClient _httpClient;

    public PatientPriorityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> IsPriorityPatientAsync(
        string identityNumber)
    {
        var response = await _httpClient.GetAsync(
            $"patient-priority/{identityNumber}");

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<PatientPriorityResponse>();

        return result?.IsPriority ?? false;
    }

    private class PatientPriorityResponse
    {
        public bool IsPriority { get; set; }
    }
}
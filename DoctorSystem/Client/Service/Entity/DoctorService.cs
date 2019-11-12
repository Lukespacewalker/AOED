using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DoctorSystem.Client.Exceptions;
using Microsoft.AspNetCore.Components.Authorization;
using DoctorSystem.Shared.Model.Entity;

namespace DoctorSystem.Client.Service.Entity
{
    public interface IDoctorService
    {
        Task<DoctorBlazor> GetDoctor(int id);
        Task<DoctorBlazor> AddOrUpdate(DoctorBlazor doctor);
    }
    public class DoctorService : IDoctorService
    {
        private HttpClient _httpClient;
        private AuthenticationStateProvider _authenticationStateProvider;

        public DoctorService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<DoctorBlazor> GetDoctor(int id)
        {
            var response = await _httpClient.GetAsync($"api/doctor/id/{id}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var doctor = JsonSerializer.Deserialize<DoctorBlazor>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return doctor;
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.NotFound) return new DoctorBlazor();
                throw new ApiServerErrorException(response.StatusCode);
            }
        }

        public async Task<DoctorBlazor> AddOrUpdate(DoctorBlazor doctor)
        {
            var loginAsJson = JsonSerializer.Serialize(doctor);
            var response = await _httpClient.PostAsync("api/doctor", new StringContent(loginAsJson, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.Conflict)
            {
                var result = JsonSerializer.Deserialize<DoctorBlazor>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (response.IsSuccessStatusCode)
                    return result;
                else throw new ApiConflictedException<DoctorBlazor>(result, doctor);
            }
            else
            {
                throw new ApiServerErrorException(response.StatusCode);
            }
        }
    }
}
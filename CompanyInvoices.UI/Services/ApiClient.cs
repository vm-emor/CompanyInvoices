using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CompanyInvoices.Contracts.Models;
using Newtonsoft.Json;

namespace CompanyInvoices.UI.Services;

public class ApiClient
{
    private readonly HttpClient _http;

    public ApiClient(string baseAddress)
    {
        _http = new HttpClient { BaseAddress = new Uri(baseAddress) };
    }

    public void SetToken(string token)
    {
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsync("api/auth/login", CreateJson(request));
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<LoginResponse>(json);
    }

    public async Task<List<CompanyView>> GetCompaniesAsync()
    {
        var response = await _http.GetAsync("api/companies");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<CompanyView>>(json) ?? new List<CompanyView>();
    }

    private static StringContent CreateJson(object model)
    {
        return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
    }
}

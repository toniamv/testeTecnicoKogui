using AplicativoTesteTecnicoKogui.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace AplicativoTesteTecnicoKogui.Services;

public class ColorApiService : IColorApiService
{
    private readonly HttpClient _http;

    public ColorApiService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress ??= new Uri("https://www.thecolorapi.com/");
    }

    public async Task<ColorInfo?> GetColorByHexAsync(string hex, CancellationToken ct = default)
    {
        string clean = (hex ?? "").Trim().TrimStart('#');
        if (string.IsNullOrWhiteSpace(clean)) return null;

        var resp = await _http.GetAsync($"id?hex={clean}", ct);
        if (!resp.IsSuccessStatusCode) return null;

        return await resp.Content.ReadFromJsonAsync<ColorInfo>(cancellationToken: ct);
    }
}
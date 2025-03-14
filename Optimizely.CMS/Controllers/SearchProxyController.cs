using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace Optimizely.CMS.Controllers;

public class SearchProxyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SearchProxyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("api/search/autocomplete")]
    public async Task<IActionResult> AutoCompleteProxy(string prefix, int size = 5)
    {
        using var httpClient = _httpClientFactory.CreateClient();
        var url =
            $"https://service.find.episerver.net/UCUHnQUWnBRDOFxzkwAFOmv4dJtwb2vH/eiromplays_eirik/_autocomplete?prefix={HttpUtility.UrlEncode(prefix)}&size={size}";

        var response = await httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return Content(content, "application/json");
    }
}
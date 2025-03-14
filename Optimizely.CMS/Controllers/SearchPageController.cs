using Microsoft.AspNetCore.Mvc;
using Optimizely.CMS.Models.Pages;
using Optimizely.CMS.Models.ViewModels;

namespace Optimizely.CMS.Controllers;

public class SearchPageController : PageControllerBase<SearchPage>
{
    public ViewResult Index(SearchPage currentPage, string q)
    {
        var model = new SearchContentModel(currentPage)
        {
            Hits = [],
            NumberOfHits = 0,
            SearchServiceDisabled = true,
            SearchedQuery = q
        };

        return View(model);
    }
}

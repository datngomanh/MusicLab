using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicLab.Frontend.Services.Interfaces;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;

namespace MusicLab.Frontend.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IApiCallerService apiCallerService;

        public SearchModel(IApiCallerService apiCallerService)
        {
            this.apiCallerService = apiCallerService;
        }

        public IList<Category> ListCategories { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            ListCategories = await apiCallerService.GetApi<List<Category>>("https://localhost:7054/api/get-all-categories", null);
            return Page();
        }
    }
}

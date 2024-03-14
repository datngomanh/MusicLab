using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicLab.Frontend.Services.Interfaces;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;
namespace MusicLab.Frontend.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IApiCallerService apiCallerService;

        public LoginModel(IApiCallerService apiCallerService)
        {
            this.apiCallerService = apiCallerService;
        }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            var loginUrl = "https://localhost:7054/api/login";

            var loginData = new LoginRequestModel
            {
                Username = username,
                Password = password
            };

            var response = await apiCallerService.PostApiWithReturn<LoginResponseModel>(loginUrl, loginData, null);

            if (response is null || response == default)
            {  
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("JwtToken", response.Token);
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(response.User));
                return RedirectToPage("/Home");
            }
        }
        public async Task<IActionResult> OnGetLogout() 
        {
            HttpContext.Session.Remove("JwtToken");
            HttpContext.Session.Remove("User");
            return RedirectToPage("/Home");
        }
    }
}

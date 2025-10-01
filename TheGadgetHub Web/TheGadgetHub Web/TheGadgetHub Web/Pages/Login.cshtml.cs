using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheGadgetHub_Web.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http; // For session

namespace TheGadgetHub_Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }

        public async Task<ActionResult> OnPost()
        {
            string url = "https://localhost:7239/api/User/login";
            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(Request.Form["btnLogin"]))
            {
                HttpContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(Login),
                    System.Text.Encoding.UTF8,
                    "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                    HttpContext.Session.SetString("JwtToken", result.Token);

                    TempData["success"] = "Login Successfully";
                    return RedirectToPage("/Products");
                }
                else
                {
                    TempData["fail"] = "Login failed. Please check your credentials.";
                    return Page();
                }
            }
            // If btnLogin is not present, just return the page
            return Page();
        }
    }
    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
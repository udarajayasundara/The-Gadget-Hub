using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TheGadgetHub_Web.Models;

namespace TheGadgetHub_Web.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public Signup Signup { get; set; }

        public async Task<ActionResult> OnPost()
        {
            string url = "https://localhost:7239/api/User/register";
            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(Request.Form["btnSignup"]))
            {
                HttpContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(Signup),
                    System.Text.Encoding.UTF8,
                    "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Registered Successfully";

                    return RedirectToPage("/Login");
                }
                else
                {
                    TempData["success"] = "Registration failed. Please try again.";
                    return Page();
                }
            }
            // If btnSignup is not present, just return the page
            return Page();
        }

    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore_2._0.Pages
{
    public class ErrorModel : PageModel
    {
    public string ErrorMessage { get; set; } = "An unexpected error has occurred.";

        public void OnGet(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}

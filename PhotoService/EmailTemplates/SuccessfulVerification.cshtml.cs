using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhotoService.EmailTemplates
{
    public class SuccessfulVerificationModel : PageModel
    {
        public string Email { get; set; }
        public void OnGet()
        {
        }
    }
}

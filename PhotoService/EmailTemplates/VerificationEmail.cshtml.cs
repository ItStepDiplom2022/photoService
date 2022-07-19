using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhotoService.EmailTemplates
{
    public class VerificationEmailModel : PageModel
    {
        public string  UserName { get; set; }
        public string Email { get; set; }
        public void OnGet()
        {
        }
    }
}

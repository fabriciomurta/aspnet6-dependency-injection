using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pjstub.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
          Console.WriteLine("Server-side 'get' triggered.");
        }
    }
}
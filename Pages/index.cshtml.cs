using Microsoft.AspNetCore.Mvc.RazorPages;

// These can be disabled for Asp.NET 6
using System;

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
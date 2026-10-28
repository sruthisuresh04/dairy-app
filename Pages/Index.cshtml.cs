using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiaryApp.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet() => RedirectToPage("/Entries/Index");
}

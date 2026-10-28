using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiaryApp.Pages.Entries;

public class CreateModel : PageModel
{
    private readonly DiaryContext _db;
    public CreateModel(DiaryContext db) => _db = db;

    [BindProperty]
    public DiaryEntry Entry { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Entry.Title) || string.IsNullOrWhiteSpace(Entry.Content))
        {
            ModelState.AddModelError("", "Please enter a title and some text.");
            return Page();
        }

        Entry.Date = DateTime.Now;
        _db.Entries.Add(Entry);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
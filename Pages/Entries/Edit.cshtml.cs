using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiaryApp.Pages.Entries;

public class EditModel : PageModel
{
    private readonly DiaryContext _db;
    public EditModel(DiaryContext db) => _db = db;

    [BindProperty]
    public DiaryEntry Entry { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var entry = await _db.Entries.FindAsync(id);
        if (entry == null) return NotFound();
        Entry = entry;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Entry.Title) || string.IsNullOrWhiteSpace(Entry.Content))
        {
            ModelState.AddModelError("", "Please enter a title and some text.");
            return Page();
        }

        var existing = await _db.Entries.FindAsync(Entry.Id);
        if (existing == null) return NotFound();

        existing.Title = Entry.Title.Trim();
        existing.Content = Entry.Content.Trim();
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
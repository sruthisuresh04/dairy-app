using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Pages.Entries;

public class IndexModel : PageModel
{
    private readonly DiaryContext _db;
    public IndexModel(DiaryContext db) => _db = db;

    public List<DiaryEntry> Entries { get; set; } = new();

    public async Task OnGetAsync()
    {
        Entries = await _db.Entries.OrderByDescending(e => e.Date).ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var entry = await _db.Entries.FindAsync(id);
        if (entry != null)
        {
            _db.Entries.Remove(entry);
            await _db.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}
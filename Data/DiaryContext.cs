using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data;

public class DiaryContext : DbContext
{
    public DiaryContext(DbContextOptions<DiaryContext> options) : base(options) { }

    public DbSet<DiaryEntry> Entries => Set<DiaryEntry>();
}
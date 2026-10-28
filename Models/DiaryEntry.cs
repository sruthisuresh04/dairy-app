namespace DiaryApp.Models;

public class DiaryEntry
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
}
using System.IO;

public static class ReasonsPage
{
    public static void MapReasonsPage(this WebApplication app)
    {
        app.MapGet("/reasons", () =>
        {
            var html = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "reasons.html"));
            return Results.Content(html, "text/html", System.Text.Encoding.UTF8);
        });
    }
}

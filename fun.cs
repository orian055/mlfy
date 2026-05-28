public static class FunEndpoints
{
    public static void MapFun(this WebApplication app)
    {
        app.MapGet("/fun", context =>
        {
            context.Response.Redirect("/fun.html");
            return Task.CompletedTask;
        });
    }
}

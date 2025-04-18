var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Poor practice: no logging/middleware setup
app.MapGet("/", () => "Hello from CopilotReviewPOC!");

app.Run();
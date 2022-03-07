using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpaStaticFiles(option => {
    if(builder.Environment.IsProduction()) {
        var workDir = AppDomain.CurrentDomain.BaseDirectory;
        if(!Directory.Exists(workDir + @"/ReactApp")) {
            throw new DirectoryNotFoundException("ReactApp direactory is required, you may need create it manually");
        }
        if(!File.Exists(workDir + @"/ReactApp/index.html")) {
            throw new FileNotFoundException("/ReactApp/index.html is required, you may need to created it manually");
        }
    }
    option.RootPath = "ReactApp";
});

var app = builder.Build();
app.MapGet("/test", () => "Hello World!"); // still is spa on /test ??? why
app.UseSpaStaticFiles();
app.UseSpa(option => {
    option.Options.SourcePath = "../client-app";
    if(app.Environment.IsDevelopment()) {
        option.UseReactDevelopmentServer("start");
    }
});

var url = app.Environment.IsProduction() ? "http://*:80" : "http://*:8885";
app.Run(url);
using Diploma.BusinessLogic;
using Diploma.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Dependency resolver
builder.Services.AddClientDependencies();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7233/") });

await builder.Build().RunAsync();

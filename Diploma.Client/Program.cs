using Blazored.LocalStorage;
using Diploma.BusinessLogic;
using Diploma.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Dependency resolver
builder.Services.AddClientDependencies();

await builder.Build().RunAsync();

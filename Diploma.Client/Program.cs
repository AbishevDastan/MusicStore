using Blazored.LocalStorage;
using Diploma.BusinessLogic;
using Diploma.Client;
using Diploma.Client.Services.AuthenticationService;
using Diploma.Client.Services.CartService;
using Diploma.Client.Services.CategoryService;
using Diploma.Client.Services.ItemService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Dependency resolver
builder.Services.AddClientDependencies();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

//Authentication state provider
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

await builder.Build().RunAsync();

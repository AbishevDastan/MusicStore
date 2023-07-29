using Blazored.LocalStorage;
using Diploma.BusinessLogic;
using Diploma.Client;
using Diploma.Client.Services.AuthenticationService;
using Diploma.Client.Services.CartService;
using Diploma.Client.Services.CategoryService;
using Diploma.Client.Services.ItemService;
using Diploma.Client.Services.OrderService;
using Diploma.Client.Services.UserService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Dependency resolver
builder.Services.AddClientDependencies();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();

//Authentication state provider
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

//MudBlazor
builder.Services.AddMudServices();
builder.Services.AddScoped<MudThemeProvider>();

await builder.Build().RunAsync();

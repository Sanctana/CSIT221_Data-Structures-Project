using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CSIT221_Data_Structures_Project;
using Services;
using System.Text.Json;
using Models;
using Utilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<TicketQueueService>();
builder.Services.AddSingleton<FlightService>();

var host = builder.Build();

try
{
    var http = host.Services.GetRequiredService<HttpClient>();

    host.Services.GetRequiredService<TicketQueueService>().Initialize(
        JsonSerializer.Deserialize<List<Ticket>>(await http.GetStringAsync("sample-data/tickets.json"), JsonOptions.Default));
    host.Services.GetRequiredService<FlightService>().Initialize(
        JsonSerializer.Deserialize<List<Flight>>(await http.GetStringAsync("sample-data/flights.json"), JsonOptions.Default));
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Startup init failed: {ex}");
}

await host.RunAsync();
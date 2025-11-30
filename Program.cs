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

var host = builder.Build();

try
{
    var http = host.Services.GetRequiredService<HttpClient>();
    var ticketService = host.Services.GetRequiredService<TicketQueueService>();

    var json = await http.GetStringAsync("sample-data/tickets.json");
    var tickets = JsonSerializer.Deserialize<List<Ticket>>(json, JsonOptions.Default);

    ticketService.Initialize(tickets);
}
catch
{

}

await host.RunAsync();
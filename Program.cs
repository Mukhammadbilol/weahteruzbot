using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUpdateHandler, UpdateHandler>();
builder.Services.AddHostedService<BotBackgroundTask>();
builder.Services.AddSingleton<ITelegramBotClient>(
    new TelegramBotClient(builder.Configuration.GetValue("BotApiKey", string.Empty)));
builder.Services.AddHttpClient("OpenMeteoClient", client => 
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue("OpenMeteoBaseUrl", string.Empty));
});

builder.Build().Run();
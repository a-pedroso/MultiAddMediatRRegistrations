using MediatR;
using Module01;
using Module02;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddModule01();
builder.Services.AddModule02();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/module01_weatherforecast", async (IMediator mediator) =>
{
    var dto = await mediator.Send(new Module01.WeatherForecastQuery());
    return new WeatherForecastModule01(dto.Date, dto.TemperatureC, dto.Summary);
})
.WithName("Module01_GetWeatherForecast")
.WithOpenApi();

app.MapGet("/module02_weatherforecast", async (IMediator mediator) =>
{
    var dto = await mediator.Send(new Module02.WeatherForecastQuery());
    return new WeatherForecastModule02(dto.Date, dto.TemperatureC, dto.Summary);
})
.WithName("Module02_GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecastModule01(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal record WeatherForecastModule02(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
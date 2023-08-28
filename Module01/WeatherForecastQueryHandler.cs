using MediatR;

namespace Module01;

public class WeatherForecastQueryHandler : IRequestHandler<WeatherForecastQuery, WeatherForecastDTO>
{
    public async Task<WeatherForecastDTO> Handle(WeatherForecastQuery query, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);

        return new WeatherForecastDTO(
            DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            Random.Shared.Next(-20, 55),
            "");
    }
}
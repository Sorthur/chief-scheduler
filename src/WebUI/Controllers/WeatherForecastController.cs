﻿using chief_schedule.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chief_schedule.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}

﻿using AzureCosmosDbWebApi.Models;
using AzureCosmosDbWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureCosmosDbWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    public readonly ICarCosmosService _carCosmosService;

    public CarController(ICarCosmosService carCosmosService)
    {
        _carCosmosService = carCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "SELECT * FROM Car";
        var result = await _carCosmosService.Get(sqlCosmosQuery);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Car newCar)
    {
        newCar.Id = Guid.NewGuid().ToString();
        var result = await _carCosmosService.AddAsync(newCar);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Car carToUpdate)
    {
        var result = await _carCosmosService.Update(carToUpdate);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id, string make)
    {
        await _carCosmosService.Delete(id, make);

        return Ok();
    }
}

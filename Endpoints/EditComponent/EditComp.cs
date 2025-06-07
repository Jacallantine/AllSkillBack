using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Database.AppDbContext;
using Api.Models;
using Api.Models.Dto;
using System.Text.Json;
using Google.Apis.Auth;

namespace Api.Routes{

public static class EditCompRoutes
{

        public static void MapEditCompRoutes(this WebApplication app)
{
    app.MapPost("/editcpu", [Authorize(Roles = "admin")] async (EditCpuDto cpuDto, AppDbContext db) =>
    {
        var existingCpu = await db.Cpu.FindAsync(cpuDto.Id);

        if (existingCpu == null)
        {
            return Results.NotFound($"CPU with ID {cpuDto.Id} not found.");
        }

        existingCpu.Name = cpuDto.Name;
        existingCpu.Price = cpuDto.Price;
        existingCpu.Url = cpuDto.Url;
        existingCpu.Type = cpuDto.Type;
        existingCpu.IsActive = cpuDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingCpu);
    });

    app.MapPost("/editgpu", [Authorize(Roles = "admin")] async (EditGpuDto gpuDto, AppDbContext db) =>
    {
        var existingGpu = await db.Gpu.FindAsync(gpuDto.Id);

        if (existingGpu == null)
        {
            return Results.NotFound($"GPU with ID {gpuDto.Id} not found.");
        }

        existingGpu.Name = gpuDto.Name;
        existingGpu.Price = gpuDto.Price;
        existingGpu.Url = gpuDto.Url;
        existingGpu.Type = gpuDto.Type;
        existingGpu.IsActive = gpuDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingGpu);
    });

    app.MapPost("/editmobo", [Authorize(Roles = "admin")] async (EditMoboDto moboDto, AppDbContext db) =>
    {
        var existingMobo = await db.Mobo.FindAsync(moboDto.Id);

        if (existingMobo == null)
        {
            return Results.NotFound($"Motherboard with ID {moboDto.Id} not found.");
        }

        existingMobo.Name = moboDto.Name;
        existingMobo.Price = moboDto.Price;
        existingMobo.Url = moboDto.Url;
        existingMobo.Type = moboDto.Type;
        existingMobo.IsActive = moboDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingMobo);
    });

    app.MapPost("/editcase", [Authorize(Roles = "admin")] async (EditCaseDto caseDto, AppDbContext db) =>
    {
        var existingCase = await db.Case.FindAsync(caseDto.Id);

        if (existingCase == null)
        {
            return Results.NotFound($"Case with ID {caseDto.Id} not found.");
        }

        existingCase.Name = caseDto.Name;
        existingCase.Price = caseDto.Price;
        existingCase.Url = caseDto.Url;
        existingCase.Type = caseDto.Type;
        existingCase.IsActive = caseDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingCase);
    });

    app.MapPost("/editram", [Authorize(Roles = "admin")] async (EditRamDto ramDto, AppDbContext db) =>
    {
        var existingRam = await db.Ram.FindAsync(ramDto.Id);

        if (existingRam == null)
        {
            return Results.NotFound($"RAM with ID {ramDto.Id} not found.");
        }

        existingRam.Name = ramDto.Name;
        existingRam.Price = ramDto.Price;
        existingRam.Url = ramDto.Url;
        existingRam.Type = ramDto.Type;
        existingRam.IsActive = ramDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingRam);
    });

    app.MapPost("/editpsu", [Authorize(Roles = "admin")] async (EditPsuDto psuDto, AppDbContext db) =>
    {
        var existingPsu = await db.Psu.FindAsync(psuDto.Id);

        if (existingPsu == null)
        {
            return Results.NotFound($"PSU with ID {psuDto.Id} not found.");
        }

        existingPsu.Name = psuDto.Name;
        existingPsu.Price = psuDto.Price;
        existingPsu.Url = psuDto.Url;
        existingPsu.Rating = psuDto.Rating;
        existingPsu.Watt = psuDto.Watt;
        existingPsu.IsActive = psuDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingPsu);
    });

    app.MapPost("/editstorage", [Authorize(Roles = "admin")] async (EditStorageDto storageDto, AppDbContext db) =>
    {
        var existingStorage = await db.Storage.FindAsync(storageDto.Id);

        if (existingStorage == null)
        {
            return Results.NotFound($"Storage with ID {storageDto.Id} not found.");
        }

        existingStorage.Name = storageDto.Name;
        existingStorage.Price = storageDto.Price;
        existingStorage.Url = storageDto.Url;
        existingStorage.Type = storageDto.Type;
        existingStorage.IsActive = storageDto.IsActive;

        await db.SaveChangesAsync();

        return Results.Ok(existingStorage);
    });
}



}


}
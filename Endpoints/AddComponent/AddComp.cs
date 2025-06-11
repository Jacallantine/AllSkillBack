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

public static class AddCompRoutes
{

            public static void MapAddCompRoutes(this WebApplication app)
    {
            app.MapPost("/addcpu", [Authorize(Roles = "admin")] async (AddCpuDto cpuDto, AppDbContext db)=>{

                        var newCpu = new Cpu 
                        {
                                Id = cpuDto.Id,
                                Price = cpuDto.Price,
                                Name = cpuDto.Name,
                                Url = cpuDto.Url,
                                Type = cpuDto.Type
                        };

                    db.Cpu.Add(newCpu);
                    await db.SaveChangesAsync();
                    return Results.Ok(newCpu);

            });



            app.MapPost("/addgpu", [Authorize(Roles = "admin")] async (AddGpuDto gpuDto, AppDbContext db)=>{

                        var newGpu = new Gpu 
                        {
                                Id = gpuDto.Id,
                                Price = gpuDto.Price,
                                Name = gpuDto.Name,
                                Url = gpuDto.Url,
                                Type = gpuDto.Type
                        };

                    db.Gpu.Add(newGpu);
                    await db.SaveChangesAsync();
                    return Results.Ok(newGpu);

            });




             app.MapPost("/addcase", [Authorize(Roles = "admin")] async (AddCaseDto caseDto, AppDbContext db)=>{

                        var newCase = new Case 
                        {
                                Id = caseDto.Id,
                                Price = caseDto.Price,
                                Name = caseDto.Name,
                                Url = caseDto.Url,
                                Type = caseDto.Type
                        };

                    db.Case.Add(newCase);
                    await db.SaveChangesAsync();
                    return Results.Ok(newCase);

            });



             app.MapPost("/addram", [Authorize(Roles = "admin")] async (AddRamDto ramDto, AppDbContext db)=>{

                        var newRam = new Ram 
                        {
                                Id = ramDto.Id,
                                Price = ramDto.Price,
                                Name = ramDto.Name,
                                Url = ramDto.Url,
                                Type = ramDto.Type
                        };

                    db.Ram.Add(newRam);
                    await db.SaveChangesAsync();
                    return Results.Ok(newRam);

            });


            app.MapPost("/addmobo", [Authorize(Roles = "admin")] async (AddMoboDto moboDto, AppDbContext db)=>{

                        var newMobo = new Ram 
                        {
                                Id = moboDto.Id,
                                Price = moboDto.Price,
                                Name = moboDto.Name,
                                Url = moboDto.Url,
                                Type = moboDto.Type
                        };

                    db.Mobo.Add(newMobo);
                    await db.SaveChangesAsync();
                    return Results.Ok(newMobo);

            });

                

                     app.MapPost("/addpsu", [Authorize(Roles = "admin")] async (AddPsuDto psuDto, AppDbContext db)=>{

                        var newPsu = new Psu 
                        {
                                Id = psuDto.Id,
                                Price = psuDto.Price,
                                Name = psuDto.Name,
                                Url = psuDto.Url,
                                Rating = psuDto.Rating,
                                Watt = psuDto.Watt
                        };

                        db.Psu.Add(newPsu);
                        await db.SaveChangesAsync();
                        return Results.Ok(newPsu);
                        });






            
                     
                     
                     
                     
                     app.MapPost("/addstorage",  async (AddStorageDto storageDto, AppDbContext db)=>{

                        var newStorage = new Storage 
                        {
                                Id = storageDto.Id,
                                Price = storageDto.Price,
                                Name = storageDto.Name,
                                Url = storageDto.Url,
                                Type = storageDto.Type 
                        };

                        db.Storage.Add(newStorage);
                        await db.SaveChangesAsync();
                        return Results.Ok(newStorage);
                    

            });




            
              



    }


}


}
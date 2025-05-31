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
using Api.Routes;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();




builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
        };

        // 👇 Read token from the cookie instead of the Authorization header
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Cookies.TryGetValue("token", out var token))
                {
                    context.Token = token;
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://68.62.246.66:3000", "http://localhost:3000","http://26.111.161.181:3000" ) 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); 
    });
});





var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); 
}

app.MapAuthRoutes();
app.MapAddCompRoutes();



app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/register", async (RegisterDto register, AppDbContext db) =>
{
    var existingUser = await db.Users.FirstOrDefaultAsync(u => u.email == register.email);
    if (existingUser != null)
    {
        return Results.BadRequest(new { message = "User already exists." });
    }

    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.password);

    var user = new User
    {
        id = register.id,
        firstName = register.firstName,
        lastName = register.lastName,
        email = register.email,
        password = hashedPassword,
        role = register.role
    };

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/users/{user.id}", new { user.id, user.email });
});

app.MapGet("/tickets", [Authorize(Roles = "admin")] async (AppDbContext db) =>
{
    var tickets = await db.Tickets
    .Where(t => t.IsComplete == 0)
    .OrderBy(t => t.Time)
    .Select(t => new TicketDto
    {
        Id = t.Id,
        Email = t.Email,
        IsClaimed = t.IsClaimed,
        IsComplete = t.IsComplete,
        WhoClaimed = t.WhoClaimed,
        PcOptiId = t.PcOptiId,
        PCId = t.PCId,
        InternetId = t.InternetId,
        Social = t.Social,
        Time = t.Time

    }).ToListAsync();
    return Results.Ok(tickets);
});

app.MapGet("/pc/{id}", [Authorize(Roles = "admin")] async (Guid Id, AppDbContext db)=>{
     var pc = await db.PCs
        .Include(p => p.Cpu)
        .Include(p => p.Gpu)
        .Include(p => p.Ram)
        .Include(p => p.Mobo)
        .Include(p => p.Psu)
        .Include(p => p.Case)     
        .Include(p => p.Storage)
        .FirstOrDefaultAsync(p => p.Id == Id);

    return pc is not null 
        ? Results.Ok(pc) 
        : Results.NotFound("PC with that Id is not found");
});


app.MapGet("/CustomPc", async (AppDbContext db)=>{

    var ram = await db.Ram.AsNoTracking().Where(r => r.IsActive == 1).ToListAsync();
    var gpu = await db.Gpu.AsNoTracking().Where(g => g.IsActive == 1).ToListAsync();
    var cpu = await db.Cpu.AsNoTracking().Where(c => c.IsActive == 1).ToListAsync();
    var mobo = await db.Mobo.AsNoTracking().Where(m => m.IsActive == 1).ToListAsync();
    var psu = await db.Psu.AsNoTracking().Where(p => p.IsActive == 1).ToListAsync();
    var storage = await db.Storage.AsNoTracking().Where(s => s.IsActive == 1).ToListAsync();
    var pcCase = await db.Case.AsNoTracking().Where(c => c.IsActive == 1).ToListAsync();

    var components = new {ram, gpu, cpu, mobo, psu, storage, pcCase};

    return Results.Ok(components);
});



app.MapGet("/tickets/completed", [Authorize(Roles = "admin")] async (AppDbContext db) =>
{
    var tickets = await db.Tickets
    .Where(t => t.IsComplete == 1)
    .Select(t => new TicketDto
    {
        Id = t.Id,
        Email = t.Email,
        IsClaimed = t.IsClaimed,
        IsComplete = t.IsComplete,
        Social = t.Social,
        Time = t.Time

    }).ToListAsync();
    return Results.Ok(tickets);
});
app.MapGet("/tickets/claimed", [Authorize(Roles = "admin")] async (AppDbContext db) =>
{
    var tickets = await db.Tickets
    .Where(t => t.IsClaimed == 1)
    .Select(t => new TicketDto
    {
        Id = t.Id,
        Email = t.Email,
        IsClaimed = t.IsClaimed,
        IsComplete = t.IsComplete,
        Social = t.Social,
        Time = t.Time

    }).ToListAsync();
    return Results.Ok(tickets);
});

app.MapPost("/tickets/claim", [Authorize(Roles = "admin")] async (TicketIdDto ticketDto, AppDbContext db) =>
{
    var ticket = await db.Tickets.FirstOrDefaultAsync(t => t.Id == ticketDto.Id);
    if(ticket == null)
    {
        return Results.BadRequest("Ticket not found");
    }
    if(ticket.IsClaimed == 0)
    {
        ticket.IsClaimed = 1;
        ticket.IsComplete = 0;
        ticket.WhoClaimed = ticketDto.FirstName;
    }
     else
    {
        return Results.BadRequest("Ticket is claimed (reload page for most up to date list)");
    }
    await db.SaveChangesAsync();

    return Results.Ok("Ticket Claimed");
    
});




app.MapPost("/tickets/complete", [Authorize(Roles = "admin")] async (TicketIdDto ticketDto, AppDbContext db) =>
{
    var ticket = await db.Tickets.FirstOrDefaultAsync(t => t.Id == ticketDto.Id);
    System.Console.WriteLine("Test:", ticket.IsComplete);
    if(ticket == null)
    {
        return Results.BadRequest("Ticket not found");
    }
    if(ticket.IsComplete == 0)
    {
        ticket.IsComplete = 1;
        ticket.IsClaimed = 0;
        ticket.WhoClaimed = ticketDto.FirstName;
    }
    else
    {
        return Results.BadRequest("Ticket is already complete (reload page for most up to date list)");
    }
    await db.SaveChangesAsync();

    return Results.Ok("Ticket marked as completed");
    
});


app.MapPost("/tickets/create", async (TicketDto ticketDto, AppDbContext db) =>
{
     PC? pc = null;

    if (ticketDto.PC is not null)
    {
        pc = new PC
        {
            CpuId = ticketDto.PC.CpuId,
            GpuId = ticketDto.PC.GpuId,
            RamId = ticketDto.PC.RamId,
            MoboId = ticketDto.PC.MoboId,
            PsuId = ticketDto.PC.PsuId,
            CaseId = ticketDto.PC.CaseId,
            StorageId = ticketDto.PC.StorageId
        };

        db.PCs.Add(pc);
        await db.SaveChangesAsync();
    }
      var ticket = new Ticket 
    {
        Id= ticketDto.Id,
        Email = ticketDto.Email,
        Time = ticketDto.Time,
        Social = ticketDto.Social,
        IsComplete = 0,
        IsClaimed = 0,
        WhoClaimed = ticketDto.WhoClaimed,
        PCId = pc?.Id,
        InternetId = ticketDto.InternetId,
        PcOptiId = ticketDto.PcOptiId
    };

    

    db.Tickets.Add(ticket);
    
    await db.SaveChangesAsync();

    return Results.Ok("Order Placed!");
    
});








app.Run();


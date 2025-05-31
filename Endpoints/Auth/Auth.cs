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

public static class AuthRoutes
{

            public static void MapAuthRoutes(this WebApplication app)
    {

                app.MapPost("/auth/google", async (HttpRequest request, HttpResponse response, IConfiguration config, AppDbContext db) =>
                        {
                            var body = await new StreamReader(request.Body).ReadToEndAsync();
                            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
                            var idToken = data["idToken"];

                            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, new GoogleJsonWebSignature.ValidationSettings
                            {
                                Audience = new[] { config["Google:ClientId"] }
                            });

                            var user = await db.Users.FirstOrDefaultAsync(u => u.email == payload.Email);
                            if (user == null)
                            {
                            user = new User
                                {
                                    id = Guid.NewGuid(),
                                    email = payload.Email,
                                    firstName = payload.GivenName,
                                    lastName = payload.FamilyName,
                                    role = "cust", 
                                    password = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString())
                                };

                                db.Users.Add(user);
                                await db.SaveChangesAsync();
                            }

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var claims = new[]
                            {
                            new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Email, user.email),
                            new Claim(JwtRegisteredClaimNames.Name, user.firstName), 
                            new Claim(ClaimTypes.Role, user.role), 
                            new Claim("role", user.role), 
                            new Claim("firstName", user.firstName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                            };

                            var token = new JwtSecurityToken(
                                issuer: config["Jwt:Issuer"],
                                audience: config["Jwt:Audience"],
                                claims: claims,
                                expires: DateTime.UtcNow.AddHours(1),
                                signingCredentials: creds
                            );

                            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                            response.Cookies.Append("token", tokenString, new CookieOptions
                            {
                                Domain = ".allskillnotalk.site",
                                HttpOnly = true,
                                Secure = true, 
                                SameSite = SameSiteMode.None,
                                Expires = DateTime.UtcNow.AddHours(1)
                            });

                            return Results.Ok(new { role = user.role });
                        });







            app.MapPost("/login", async (LoginDto login, AppDbContext db, IConfiguration config, HttpResponse response) =>
                        {
                            var user = await db.Users.FirstOrDefaultAsync(u => u.email == login.email);

                            if (user == null || !BCrypt.Net.BCrypt.Verify(login.password, user.password))
                            {
                                return Results.Unauthorized();
                            }

                            var jwtKey = config["Jwt:Key"];
                            var issuer = config["Jwt:Issuer"];
                            var audience = config["Jwt:Audience"];

                            var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Email, user.email),
                            new Claim(JwtRegisteredClaimNames.GivenName, user.firstName), 
                            new Claim(JwtRegisteredClaimNames.Name, user.firstName), 
                            new Claim(ClaimTypes.Role, user.role), 
                            new Claim("role", user.role), 
                            new Claim("firstName", user.firstName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var token = new JwtSecurityToken(
                                issuer: issuer,
                                audience: audience,
                                claims: claims,
                                expires: DateTime.UtcNow.AddHours(1),
                                signingCredentials: creds
                            );

                            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                            response.Cookies.Append("token", tokenString, new CookieOptions
                            {
                                Domain = ".allskillnotalk.site",
                                HttpOnly = true,
                                Secure = true,               // Set to true in production (requires HTTPS)
                                SameSite = SameSiteMode.None,
                                Expires = DateTime.UtcNow.AddHours(1),
                                Path = "/"
                            });


                            return Results.Ok(new { role = user.role });
                        });





    }


}


}


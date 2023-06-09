﻿using APICOFFE.Client.Dtos.Auth;
using APICOFFE.Database.Models;

namespace APICOFFE.Services.Concretes;
public interface IUserService
{
    public bool IsAuthenticated { get; }
    public User CurrentUser { get; }

    Task<bool> CheckPasswordAsync(string? email, string? password);
    string GetCurrentUserFullName();
    Task<string> SignInAsync(int id, string? role = null);
    Task<string> SignInAsync(string? email, string? password, string? role = null);
    Task CreateAsync(RegisterDto dto);
  
    Task<bool> CheckEmailConfirmedAsync(string? email);
}
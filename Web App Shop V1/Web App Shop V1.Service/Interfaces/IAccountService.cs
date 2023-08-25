using System;
using System.Security.Claims;
using Web_App_Shop_V1.Domain.Models;
using Web_App_Shop_V1.Domain.Response;
using Web_App_Shop_V1.Domain.ViewModels.Account;

namespace Web_App_Shop_V1.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
}


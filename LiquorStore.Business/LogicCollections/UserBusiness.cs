﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LiquorStore.Business.Dtos;
using LiquorStore.Business.LogicCollections;
using LiquorStore.Common.Entities;
using LiquorStore.Common.Exceptions;
using LiquorStore.Common.Helpers;
using LiquorStore.DAL.UnitOfWork;
using LiquourStore.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace LiquorStore.Business.LogicCollection
{
    /// <summary>
    /// The user business
    /// </summary>
    /// <seealso cref="LiquorStore.Business.LogicCollection.IUserBusiness" />
    public class UserBusiness : BaseBusiness<UserBusiness>, IUserBusiness
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserBusiness(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IRequestInfo requestInfo, ILoggerAdapter<UserBusiness> logger, 
            IHttpContextAccessor httpContextAccessor) : base(unitOfWorkFactory, mapper, requestInfo, logger)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<AuthenticationOutputDto> Authenticate(AuthenticationInputDto input)
        {
            var result = new AuthenticationOutputDto();
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var user = await unitOfWork.Users.Authenticate(input.Username, input.Password);
                if (user != null)
                {
                    result = new AuthenticationOutputDto()
                    {
                        UserId = user.Id
                    };
                    await GenerateCookieAsync(user.Id);
                }
                else
                {
                    throw new NotFoundException(new ErrorResponse("user not found"));
                }
            }

            return result;
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async Task GenerateCookieAsync(int userId)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", userId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using EView360.Data;
using EView360.Services.Summary;
using Common.ViewModel;

namespace EView360.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        Global _global { get; }

        public ILocalStorageService _localStorageService { get; }
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, Global global)
        {
            _localStorageService = localStorageService;
            _global = global;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var emailAddress = await _localStorageService.GetItemAsync<string>("userLogin");
            ClaimsIdentity identity;
            if (emailAddress != null && _global.stateAuthenticated)
            {
                identity = new ClaimsIdentity(new[]
                       {
                new Claim(ClaimTypes.Name, emailAddress),
            }, "apiauth_ype");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public async Task MarkUserAsAuthenticated(User user)
        {
            _global.stateAuthenticated = true;
            await _localStorageService.SetItemAsync("userLogin", user.UserLogin);

            var claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, user.UserLogin)
                            }, "apiauth_type");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            CurrentLoggedInUserService.AddActiveUser(new CurrentLoggedInUsersViewModel { UserName = user.UserLogin, LoggedInAt = DateTime.Now });

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            _global.stateAuthenticated = false;
            string userName = await _localStorageService.GetItemAsync<string>("userLogin");
            CurrentLoggedInUserService.RemoveActiveUser(userName);
            await _localStorageService.RemoveItemAsync("userLogin");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }
    }
}

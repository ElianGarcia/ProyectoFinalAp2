using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using ProyectoFinalAp2.Controllers;

namespace ProyectoFinalAp2.Pages.Login
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }

        private string getNivel(string paramUsername)
        {
            string nivel = UsuariosBLL.NivelUsuario(paramUsername);
            return nivel;
        }

        public async Task<IActionResult>
            OnGetAsync(string paramUsername, string paramPassword)
        {
            string ReturnUrl = Url.Content("~/");
            var claims = new List<Claim>();

            bool paso = false;
            try
            {
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch
            { 

            }
            try
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, paramUsername),
                    new Claim(ClaimTypes.Role, getNivel(paramUsername))
                };
            } catch(Exception)
            {

            }
            
            if (paramUsername == null || paramPassword == null)
            {
                return LocalRedirect(ReturnUrl);
            }

            string User = paramUsername;
            string Pass = UsuariosBLL.encode(paramPassword);

            paso = UsuariosBLL.VerificarExistenciaYClaveDelUsuario(User, Pass);

            if (!paso)
            {
                return LocalRedirect(ReturnUrl);
            } 

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
            try
            {
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return LocalRedirect(ReturnUrl);
        }
    }
}

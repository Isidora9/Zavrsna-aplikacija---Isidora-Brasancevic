using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija.App_Start;
using ZavrsnaAplikacija.Models;
using Microsoft.Owin.Security.Google;

namespace ZavrsnaAplikacija
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            app.UseFacebookAuthentication(
                appId: "778943660712158",
                appSecret: "1b87c6eee4fb8944c74264c071db3dfd");
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "281751939036-6mtdb663ii73o28s1dh8b6jm2fbps7id.apps.googleusercontent.com",
                ClientSecret = "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"
            });
            app.UseTwitterAuthentication(
                consumerKey: "kqiAPh6mNiQSqcsuDbhMncDA7",
                consumerSecret: "icl46MosS9wGm9gAfDRIskP83uxLcdrFpN5jU9SEUohpmSXcOh");
        }
    }
}
﻿using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(IdentityDemo.Startup1))]

namespace IdentityDemo
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions 
            { 
                AuthenticationType="AppCookie",
                LoginPath=new PathString("/Account/Login")
            }
            );

        
        }
    }
}

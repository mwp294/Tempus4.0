﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tempus4._0.Startup))]
namespace Tempus4._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
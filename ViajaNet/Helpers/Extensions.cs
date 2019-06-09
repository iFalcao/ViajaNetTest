using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajaNet.Helpers
{
    public static class Extensions
    {
        public static void ConfigureStaticFilesWithDefault(this IApplicationBuilder app)
        {
            DefaultFilesOptions defaultFileOptions = new DefaultFilesOptions();
            defaultFileOptions.DefaultFileNames.Clear();
            defaultFileOptions.DefaultFileNames.Add("home.html");
            app.UseDefaultFiles(defaultFileOptions);
            app.UseStaticFiles();
        }
    }
}

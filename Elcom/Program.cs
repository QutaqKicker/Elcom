using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Elcom.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Elcom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Актуализируем класс конфига
            ConfigSpace.UpdateConfig();
            // Актуализируем класс попапов и опшенлистов
            Options.UpdateAllOptions();
            // Запускаем хост
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
#if RELEASE
                .UseUrls("http://192.168.156.70:5000")
#endif
                .UseStartup<Startup>().UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseWebRoot("wwwroot");
    }
}

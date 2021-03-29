using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    public static class ConfigSpace
    {

        public static string PgSQLConnection;
        public static string PgSQLConnection2;
        public static string OracleConnection;
        public static string OracleTestConnection;
        public static string MySQLConnection;

        public static string TemplatesPath;
        public static string FilesPath;
        public static string ImportPath;

        public static void UpdateConfig()
        {
            // Этим классом будем шарить по конфигурации
            var builder = new ConfigurationBuilder();
            // Берем директорию и файл конфигурации и помещаем в билдер. (Работает если запускается из среды разработки)
            var dir = AppContext.BaseDirectory;
            builder.SetBasePath(dir);
            builder.AddJsonFile("appsettings.json");

            try
            {
                // Пытаемся построить.
                builder.Build();
            }
            catch (Exception)
            {
                // Построить не удалось, значит запуск идет уже развернутого проекта, раз файл конфигурации найти не удалось.
                // Тогда берем директорию развернутого проекта и ищем там файл конфигурации, далее работаем с ним. Если не пересоздать билдер, выплюнет ошибку.
                builder = new ConfigurationBuilder();
                dir = Directory.GetCurrentDirectory();
                builder.AddJsonFile("appsettings.json");
                builder.SetBasePath(dir);
            }

            // Сохраняем все строки подключения
            PgSQLConnection = builder.Build().GetConnectionString("PgSQLConnection");
            PgSQLConnection2 = builder.Build().GetConnectionString("PgSQLConnection2");
            OracleConnection = builder.Build().GetConnectionString("OracleConnection");
            OracleTestConnection = builder.Build().GetConnectionString("OracleTestConnection");
            MySQLConnection = builder.Build().GetConnectionString("MySQLConnection");

            // Ищем секцию путей и так же сохраняем все пути
#if !RELEASE
            TemplatesPath = dir + '/' + builder.Build().GetSection("Paths")["TemplatesPath"];
            FilesPath = dir + '/' + builder.Build().GetSection("Paths")["FilesPath"];
            ImportPath = dir + '/' + builder.Build().GetSection("Paths")["ImportPath"];
#else
            TemplatesPath = dir + builder.Build().GetSection("Paths")["TemplatesPath"];
            FilesPath = dir + builder.Build().GetSection("Paths")["FilesPath"];
            ImportPath = dir + builder.Build().GetSection("Paths")["ImportPath"];

#endif
            Console.WriteLine("Конфигурационные данные обновлены!");

            // Костыль на случай если конфиг не найден. Чтобы не мешало отладке
            if (OracleTestConnection is null)
            {
                Console.WriteLine("Считать данные с конфигурационного файла не удалось! Вбиты дефолтные данные.");
                Console.WriteLine("Нужно проверить корректность пути к конфигу. Сейчас он: " + dir + "appsettings.json");

                PgSQLConnection = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
                PgSQLConnection2 = "Host=172.16.0.97;Port=5432;Database=erz;Username=idev;Password=4dadsae3gc;Timeout=1024";
                OracleConnection = "Data Source =(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP) (HOST = 192.168.5.68) (PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = maconomy))); User Id = elco; Password = elcotestt;";
                OracleTestConnection = "Data Source =(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP) (HOST = 192.168.5.68) (PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = maconomy))); User Id = elco; Password = elcotestt;";

                TemplatesPath = dir + "\\wwwroot\\Templates\\";
                FilesPath = dir + "\\wwwroot\\Files\\";
                ImportPath = dir + "\\wwwroot\\Import\\";
            }
        }
    }
}

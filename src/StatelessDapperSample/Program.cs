
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatelessDapperSample.Domain;
using StatelessDapperSample.Domain.Data;
using StatelessDapperSample.Domain.ValueObj;
using StatelessDapperSample.Repository;
using System;
using System.IO;

namespace StatelessDapperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup to use an app settings file
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //setup dependency injection
            var serviceProvider = ConfigureServices(config);

            var connection = serviceProvider.GetRequiredService<ConnectionString>();
            var repository = new SampleRepository(connection);

            var insertData = new SampleData()
            {
                Status = StatusEnum.Wait
            };

            var insertResponse = repository.InsertData(insertData);
       
            var getData = repository.GetData();

            foreach (var data in getData)
            {
                try
                {
                    var preStatus = data.Status;
                    
                    data._machine.Fire(TriggerEnum.Retry);

                    Console.WriteLine("sucesso: "  + preStatus + " => " + data.Status);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private static ServiceProvider ConfigureServices(IConfiguration config)
        {
            var services = new ServiceCollection();
            var connectionString = config.GetSection("ConnectionString").Get<ConnectionString>();
            services.AddSingleton<ConnectionString>(connectionString);

            return services.BuildServiceProvider();
        }
    }
}

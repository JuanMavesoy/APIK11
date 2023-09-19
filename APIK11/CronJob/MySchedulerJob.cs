using Aplicacion.DTO;
using Dominio.Entidad;
using Infraestructura;

namespace APIK11.CronJob
{
    public class MySchedulerJob : CronBackgroundJob
    {
        private readonly ILogger<MySchedulerJob> _log;
        private int countPage = 1;
        private readonly IServiceProvider _serviceProvider;

        public MySchedulerJob(CronSettings<MySchedulerJob> settings, ILogger<MySchedulerJob> log, IServiceProvider serviceProvider)
            : base(settings.CronExpression, settings.TimeZone)
        {
            _log = log;
            _serviceProvider = serviceProvider;
        }

        protected override async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<ContextDb>();

                string url = $"https://reqres.in/api/users?page={countPage}";

                using var HttpClient = new HttpClient();

                UserResponse result = await HttpClient.GetFromJsonAsync<UserResponse>(url);

                List<User> Data = result.Data;

                if(Data.Count > 0)
                {
                    foreach (var item in Data)
                    {
                        item.id = 0;
                    }
                    _context.users.AddRange(Data);
                    _context.SaveChanges();

                    countPage++;

                    _log.LogInformation("dato del primer sujeto {0}", Data[0].first_name);
                }
            }
        }
    }
}

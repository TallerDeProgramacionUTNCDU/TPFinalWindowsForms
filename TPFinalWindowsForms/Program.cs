using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System.Collections.Specialized;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.IO;
using TPFinalWindowsForms.Visual;
using TPFinalWindowsForms.Quartz;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Quartz.Logging.OperationName;


namespace TPFinalWindowsForms
{   
        static class Program
        {

        public static async Task Alertas()
        {
        var job = JobBuilder.Create<BackgroundJob>()
        .WithIdentity(name: "RevisionAlerta", group: "JobGroup")
        .Build();
        var trigger = TriggerBuilder.Create()
                .WithIdentity(name: "RepeatingTrigger", group: "TriggerGroup")
                .WithSimpleSchedule(o => o
                    .RepeatForever()
                    .WithIntervalInSeconds(86400))
                .Build();
        var builder = Host.CreateDefaultBuilder()
        .ConfigureServices((cxt, services) =>
                {
                    services.AddQuartz(opt =>
                    {
                        opt.UsePersistentStore(s =>
                        {
                            s.UsePostgres("Host=kesavan.db.elephantsql.com;Port=5432;Database=mnseyzle;Username=mnseyzle;Password=EkX5Pe9VK0I8PH7PidcPaprUxT4Dii6x");
                        });
                    });
                    //services.AddQuartzHostedService(opt =>
                    //{
                    //    opt.WaitForJobsToComplete = true;
                    //});
                }).Build();
            LogProvider.IsDisabled = true;
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();
            await scheduler.ScheduleJob(job, trigger);
        }

 


        [STAThread]
        static void Main()
        {
            Login.log.Info("========================================================");
            Login.log.Info("==================INICIANDO APLICACIÓN==================");
            Login.log.Info("========================================================");
            ApplicationConfiguration.Initialize();            
            Application.Run(new Login());
   
        }        
    }
}

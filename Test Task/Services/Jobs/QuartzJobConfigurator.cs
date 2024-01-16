using Quartz;
using Quartz.Spi;

namespace Test_Task.Services.Jobs
{
    //public static class QuartzJobConfigurator
    //{
    //    public static void ConfigureJob<TJob>(this IServiceCollection services, string jobName, string triggerName, string cronExpression)
    //        where TJob : IJob
    //    {
    //        var jobKey = new JobKey(jobName);
    //        services.AddQuartz(q =>
    //        {
    //            q.UseMicrosoftDependencyInjectionJobFactory();

    //            q.AddJob<TJob>(opt => opt.WithIdentity(jobKey));

    //            q.AddTrigger(opt =>
    //                opt.ForJob(jobKey)
    //                    .WithIdentity(triggerName)
    //                    .WithCronSchedule(cronExpression));
    //        });
    //    }
    //}


    public static class QuartzJobConfigurator
    {
        public static void ConfigureJob<TJob>(this IServiceCollection services, string jobName, string triggerName, string cronExpression)
            where TJob : class, IJob, IJobFactory
        {
            var jobKey = new JobKey(jobName);
            services.AddQuartz(q =>
            {
                q.UseJobFactory<TJob>(opts =>
                {
                    // ... additional settings
                });

                q.AddJob<TJob>(opt => opt.WithIdentity(jobKey));

                q.AddTrigger(opt => opt.ForJob(jobKey)
                    .WithIdentity(triggerName)
                    .WithCronSchedule(cronExpression));
            });
        }
    }

}

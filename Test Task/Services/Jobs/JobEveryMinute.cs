using Quartz;
using Quartz.Spi;

namespace Test_Task.Services.Jobs
{
    public class JobEveryMinute : IJob, IJobFactory
    {
        public Task Execute(IJobExecutionContext context)
        {

            Console.WriteLine("Send jobs every minute" + DateTime.Now );

            return Task.FromResult(true);
        }


        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            Console.WriteLine("Send jobs every minute" + DateTime.Now);
            return new JobEveryMinute(); 
        }


        public void ReturnJob(IJob job)
        {
            // Remove a task from the container
            // Return the job to the job pool

        }
    }
}

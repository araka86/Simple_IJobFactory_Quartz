using Quartz;
using Quartz.Spi;

namespace Test_Task.Services.Jobs
{
    public class JobEveryMondayAt14Pm : IJob, IJobFactory
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Send jobs every monday at 14:00" + DateTime.Now);

            return Task.FromResult(true);
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            Console.WriteLine("Send jobs every monday at 14:00" + DateTime.Now);
            return new JobEveryMondayAt14Pm();
        }

        public void ReturnJob(IJob job)
        {
            // Remove a task from the container
            // Return the job to the job pool
        }
    }
}

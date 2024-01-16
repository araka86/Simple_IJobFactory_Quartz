using Test_Task.Data;
using Microsoft.EntityFrameworkCore;
using Test_Task.Services;
using Test_Task.Services.Jobs;
using Quartz;





var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Every minute job is running at: " + DateTime.Now);
//db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//repo
 builder.Services.AddScoped<IPersonRepository, PersonRepository>();




builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//mapper
builder.Services.AddAutoMapper(typeof(Program));


//builder.Services.AddQuartz(q => {

//    var jobKey = new JobKey("JobEveryMinute");
//    q.AddJob<JobEveryMinute>(opt=>opt.WithIdentity(jobKey));

//    q.AddTrigger(opt =>
//    opt.ForJob(jobKey)
//    .WithIdentity("everiMinute-job-trigger")
//    .WithCronSchedule("0 0/1 * * * ?"));

//});

//builder.Services.AddQuartz(q =>
//{

//    var mondayJobKey = new JobKey("JobEveryMondayAt14Pm");
//    q.AddJob<JobEveryMondayAt14Pm>(opt => opt.WithIdentity(mondayJobKey));

//    q.AddTrigger(opt =>
//        opt.ForJob(mondayJobKey)
//            .WithIdentity("monday-job-trigger")
//             .WithCronSchedule("0 0 14 ? * MON"));

//});

//jobs
builder.Services.ConfigureJob<JobEveryMinute>("JobEveryMinute", "everyMinute-job-trigger", "0 0/1 * * * ?");

builder.Services.ConfigureJob<JobEveryMondayAt14Pm>("JobEveryMondayAt14Pm", "monday-job-trigger", "0 0 14 ? * MON");



builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


var app = builder.Build();



//dataseed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        DbSeeder.SeedData(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

global using InterviewAPI.Models;
using InterviewAPI.Services.ApplicantService;
using InterviewAPI.Services.ApplicationStatusService;
using InterviewAPI.Services.DocumentService;
using InterviewAPI.Services.JobCategoryService;
using InterviewAPI.Services.JobPlatformService;
using InterviewAPI.Services.JobPositionService;
using InterviewAPI.Services.OrganizationService;
using InterviewAPI.Services.RecruiterService;
using InterviewAPI.Services.StepService;
using InterviewAPI.Services.TestService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicantsInterviewContext>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IJobCategoryService, JobCategoryService>();
builder.Services.AddScoped<IJobPlatformService, JobPlatformService>();
builder.Services.AddScoped<IJobPositionService, JobPositionService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IApplicationStatusService, ApplicationStatusService>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();

var app = builder.Build();

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

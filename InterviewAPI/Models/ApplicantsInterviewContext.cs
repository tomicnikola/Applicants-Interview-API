using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Models;

public partial class ApplicantsInterviewContext : DbContext
{
    public ApplicantsInterviewContext()
    {
    }

    public ApplicantsInterviewContext(DbContextOptions<ApplicantsInterviewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<ApplicantEvaluation> ApplicantEvaluations { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationDocument> ApplicationDocuments { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<ApplicationStatusChange> ApplicationStatusChanges { get; set; }

    public virtual DbSet<ApplicationTest> ApplicationTests { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<InterviewNote> InterviewNotes { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobCategory> JobCategories { get; set; }

    public virtual DbSet<JobPlatform> JobPlatforms { get; set; }

    public virtual DbSet<JobPosition> JobPositions { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<ProcessStep> ProcessSteps { get; set; }

    public virtual DbSet<Recruiter> Recruiters { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-L8CV5DJ\\SQLEXPRESS;Initial Catalog=applicantsInterview;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("answers_pk");

            entity.ToTable("answers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AnswerDetails).HasColumnName("answer_details");
            entity.Property(e => e.ApplicationTestId).HasColumnName("application_test_id");
            entity.Property(e => e.Pass).HasColumnName("pass");
            entity.Property(e => e.RecruiterId).HasColumnName("recruiter_id");
            entity.Property(e => e.TotalGrades)
                .HasMaxLength(10)
                .HasColumnName("total_grades");

            entity.HasOne(d => d.ApplicationTest).WithMany(p => p.Answers)
                .HasForeignKey(d => d.ApplicationTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("test_grades_application_test");

            entity.HasOne(d => d.Recruiter).WithMany(p => p.Answers)
                .HasForeignKey(d => d.RecruiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("test_grades_recruiters");
        });

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applicant_pk");

            entity.ToTable("applicant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.Summary).HasColumnName("summary");
        });

        modelBuilder.Entity<ApplicantEvaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applicant_evaluation_pk");

            entity.ToTable("applicant_evaluation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.Hired).HasColumnName("hired");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RecruiterId).HasColumnName("recruiter_id");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicantEvaluations)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("applicant_evaluations_applications");

            entity.HasOne(d => d.Recruiter).WithMany(p => p.ApplicantEvaluations)
                .HasForeignKey(d => d.RecruiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("applicant_evaluations_recruiters");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_pk");

            entity.ToTable("application");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.DateOfApplication)
                .HasColumnType("datetime")
                .HasColumnName("date_of_application");
            entity.Property(e => e.Education).HasColumnName("education");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.JobsId).HasColumnName("jobs_id");
            entity.Property(e => e.OtherInfo).HasColumnName("other_info");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("applications_applicants");

            entity.HasOne(d => d.Jobs).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("applications_jobs");
        });

        modelBuilder.Entity<ApplicationDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_document_pk");

            entity.ToTable("application_document");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationDocuments)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_document_applications");

            entity.HasOne(d => d.Document).WithMany(p => p.ApplicationDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_document_documents");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_status_pk");

            entity.ToTable("application_status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ApplicationStatusChange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_status_change_pk");

            entity.ToTable("application_status_change");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.ApplicationStatusId).HasColumnName("application_status_id");
            entity.Property(e => e.DateChanged)
                .HasColumnType("datetime")
                .HasColumnName("date_changed");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationStatusChanges)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_status_changes_applications");

            entity.HasOne(d => d.ApplicationStatus).WithMany(p => p.ApplicationStatusChanges)
                .HasForeignKey(d => d.ApplicationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_status_changes_application_status");
        });

        modelBuilder.Entity<ApplicationTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_test_pk");

            entity.ToTable("application_test");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationTests)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_test_applications");

            entity.HasOne(d => d.Test).WithMany(p => p.ApplicationTests)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_test_tests");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_pk");

            entity.ToTable("document");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Document1)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("document");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("interview_pk");

            entity.ToTable("interview");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Application).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interview_application");
        });

        modelBuilder.Entity<InterviewNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("interview_note_pk");

            entity.ToTable("interview_note");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.InterviewId).HasColumnName("interview_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Pass).HasColumnName("pass");
            entity.Property(e => e.RecruiterId).HasColumnName("recruiter_id");

            entity.HasOne(d => d.Interview).WithMany(p => p.InterviewNotes)
                .HasForeignKey(d => d.InterviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interview_notes_interview");

            entity.HasOne(d => d.Recruiter).WithMany(p => p.InterviewNotes)
                .HasForeignKey(d => d.RecruiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interview_notes_recruiter");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_pk");

            entity.ToTable("job");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.DatePublished)
                .HasColumnType("datetime")
                .HasColumnName("date_published");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.JobCategoryId).HasColumnName("job_category_id");
            entity.Property(e => e.JobPlatformId).HasColumnName("job_platform_id");
            entity.Property(e => e.JobPositionId).HasColumnName("job_position_id");
            entity.Property(e => e.JobStartDate)
                .HasColumnType("datetime")
                .HasColumnName("job_start_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NoOfVacancies).HasColumnName("no_of_vacancies");
            entity.Property(e => e.OrganizationsId).HasColumnName("organizations_id");
            entity.Property(e => e.ProcessId).HasColumnName("process_id");

            entity.HasOne(d => d.JobCategory).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jobs_job_categories");

            entity.HasOne(d => d.JobPlatform).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobPlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jobs_job_platforms");

            entity.HasOne(d => d.JobPosition).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jobs_job_positions");

            entity.HasOne(d => d.Organizations).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.OrganizationsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jobs_organizations");

            entity.HasOne(d => d.Process).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_process");
        });

        modelBuilder.Entity<JobCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_category_pk");

            entity.ToTable("job_category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<JobPlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_platform_pk");

            entity.ToTable("job_platform");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<JobPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_position_pk");

            entity.ToTable("job_position");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_pk");

            entity.ToTable("organization");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("process_pk");

            entity.ToTable("process");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RecruiterId).HasColumnName("recruiter_id");

            entity.HasOne(d => d.Recruiter).WithMany(p => p.Processes)
                .HasForeignKey(d => d.RecruiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("process_recruiter");
        });

        modelBuilder.Entity<ProcessStep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("process_step_pk");

            entity.ToTable("process_step");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.ProcessId).HasColumnName("process_id");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.StepId).HasColumnName("step_id");

            entity.HasOne(d => d.Process).WithMany(p => p.ProcessSteps)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("process_step_process");

            entity.HasOne(d => d.Step).WithMany(p => p.ProcessSteps)
                .HasForeignKey(d => d.StepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("process_step_step");
        });

        modelBuilder.Entity<Recruiter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recruiter_pk");

            entity.ToTable("recruiter");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("step_pk");

            entity.ToTable("step");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("test_pk");

            entity.ToTable("test");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MaxScore).HasColumnName("max_score");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

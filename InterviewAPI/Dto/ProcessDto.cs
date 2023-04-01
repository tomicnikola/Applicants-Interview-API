namespace InterviewAPI.Dto
{
    public class ProcessDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int RecruiterId { get; set; }

        public virtual Recruiter Recruiter { get; set; } = null!;
    }
}

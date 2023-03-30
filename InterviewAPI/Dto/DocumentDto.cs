namespace InterviewAPI.Dto
{
    public class DocumentDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public byte[]? Document1 { get; set; }

        public string? Url { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}

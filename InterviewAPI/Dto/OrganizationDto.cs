﻿namespace InterviewAPI.Dto
{
    public class OrganizationDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}

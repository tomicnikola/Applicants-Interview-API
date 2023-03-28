﻿using AutoMapper;
using InterviewAPI.Dto;

namespace InterviewAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Step, StepDto>();
        }
    }
}
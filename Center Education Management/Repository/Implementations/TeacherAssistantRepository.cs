﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Models;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class TeacherAssistantRepository : GenericRepository<TeacherAssistant>, ITeacherAssistantRepository
    {
        public TeacherAssistantRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

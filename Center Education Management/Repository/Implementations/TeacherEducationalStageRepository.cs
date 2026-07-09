﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Models;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class TeacherEducationalStageRepository : GenericRepository<TeacherEducationalStage>, ITeacherEducationalStageRepository
    {
        public TeacherEducationalStageRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

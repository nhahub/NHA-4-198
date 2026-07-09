﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Models;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class ExamAttemptRepository : GenericRepository<ExamAttempt>, IExamAttemptRepository
    {
        public ExamAttemptRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

﻿using Center_Education_Management.Model;

namespace Center_Education_Management.Repository.Interfaces
{
    // Interface خاص بـ ExamQuestion، ممكن تضيف فيه أي Query مخصوصة زيادة عن الـ Generic
    public interface IExamQuestionRepository : IGenericRepository<ExamQuestion>
    {
    }
}

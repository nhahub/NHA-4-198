﻿using Center_Education_Management.Models;

namespace Center_Education_Management.Repository.Interfaces
{
    // Interface خاص بـ Assignment، ممكن تضيف فيه أي Query مخصوصة زيادة عن الـ Generic
    public interface IAssignmentRepository : IGenericRepository<Assignment>
    {
    }
}

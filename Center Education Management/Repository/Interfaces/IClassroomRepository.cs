﻿using Center_Education_Management.Model;

namespace Center_Education_Management.Repository.Interfaces
{
    // Interface خاص بـ Classroom، ممكن تضيف فيه أي Query مخصوصة زيادة عن الـ Generic
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
    }
}

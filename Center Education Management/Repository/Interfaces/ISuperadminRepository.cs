﻿using Center_Education_Management.Models;

namespace Center_Education_Management.Repository.Interfaces
{
    // Interface خاص بـ Superadmin، ممكن تضيف فيه أي Query مخصوصة زيادة عن الـ Generic
    public interface ISuperadminRepository : IGenericRepository<Superadmin>
    {
    }
}

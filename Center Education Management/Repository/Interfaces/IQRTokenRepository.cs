﻿using Center_Education_Management.Models;

namespace Center_Education_Management.Repository.Interfaces
{
    // Interface خاص بـ QRToken، ممكن تضيف فيه أي Query مخصوصة زيادة عن الـ Generic
    public interface IQRTokenRepository : IGenericRepository<QRToken>
    {
    }
}

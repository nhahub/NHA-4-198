﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Model;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class QRTokenRepository : GenericRepository<QRToken>, IQRTokenRepository
    {
        public QRTokenRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

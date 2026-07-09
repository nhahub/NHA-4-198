﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Models;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class SuperadminRepository : GenericRepository<Superadmin>, ISuperadminRepository
    {
        public SuperadminRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

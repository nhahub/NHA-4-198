﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Models;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class CenterrequestRepository : GenericRepository<Centerrequest>, ICenterrequestRepository
    {
        public CenterrequestRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

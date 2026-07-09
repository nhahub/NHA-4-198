﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Model;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class ParentRepository : GenericRepository<Parent>, IParentRepository
    {
        public ParentRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

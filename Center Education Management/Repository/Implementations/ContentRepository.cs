﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Model;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(CenterDBContext context) : base(context)
        {
        }
    }
}

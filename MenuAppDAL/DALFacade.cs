using System;
using System.Collections.Generic;
using System.Text;
using MenuAppDAL.Context;
using MenuAppDAL.Repositories;
using MenuAppDAL.UOW;

namespace MenuAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get { return new VideoRepositoryEFMemory(new Context.InMemoryContext()); }
        }

        public IUnitOfWork UnitOfWork
        {
            get { return new UnitOfWorkMemory();}
        }
    }
}

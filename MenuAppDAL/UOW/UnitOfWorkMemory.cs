using System;
using System.Collections.Generic;
using System.Text;
using MenuAppDAL.Context;
using MenuAppDAL.Repositories;

namespace MenuAppDAL.UOW
{
    class UnitOfWorkMemory : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMemory()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}

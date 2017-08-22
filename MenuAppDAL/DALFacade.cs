using System;
using System.Collections.Generic;
using System.Text;
using MenuAppDAL.Repositories;

namespace MenuAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get { return new VideoRepositoryFakeDB();}
        }
    }
}

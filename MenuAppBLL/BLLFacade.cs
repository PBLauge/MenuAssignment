using System;
using System.Collections.Generic;
using System.Text;
using MenuAppBLL.Services;
using MenuAppDAL;

namespace MenuAppBLL
{
    public class BLLFacade
    {
        public IService GetService()
        {
            return new Service();
        }

        public IService Service
        {
            get { return new Service();}
        }
    }
}

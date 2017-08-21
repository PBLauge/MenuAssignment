﻿using System;
using System.Collections.Generic;
using System.Text;
using MenuAppEntity;

namespace MenuAppBLL
{
    public interface IService
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        Video Update(Video vid);
        //D
        Video Delete(int Id);
    }
}

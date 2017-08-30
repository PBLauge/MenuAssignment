using System;
using System.Collections.Generic;
using System.Text;
using MenuAppDAL.Entities;

namespace MenuAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        //No Update, It is a task for unit of work.
        //D
        Video Delete(int Id);
        //Search
        List<Video> FindVideoByTitle(string title);
    }
}

using System.Collections.Generic;
using MenuAppBLL.BO;

namespace MenuAppBLL
{
    public interface IService
    {
        //C
        VideoBO Create(VideoBO vid);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        //U
        VideoBO Update(VideoBO vid);
        //D
        VideoBO Delete(int Id);
        //Search
        List<VideoBO> FindVideoByTitle(string title);
        

    }
}

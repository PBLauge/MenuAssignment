using System;
using System.Collections.Generic;
using System.Linq;
using MenuAppDAL;
using MenuAppEntity;

namespace MenuAppBLL.Services
{
    class Service : IService
    {
        IVideoRepository repo;

        public Service(IVideoRepository repo)
        {
            this.repo = repo;
        }

        public Video Create(Video vid)
        {
            
            return this.repo.Create(vid);
        }

        public List<Video> GetAll()
        {
            return this.repo.GetAll();
        }

        public Video Get(int Id)
        {
            return this.repo.Get(Id);
        }

        public Video Update(Video vid)
        {
            var videoFromDB = Get(vid.Id);
            if (videoFromDB == null)
            {
                throw new InvalidOperationException("Video not found");
            }
            videoFromDB.Title = vid.Title;
            videoFromDB.Genre = vid.Genre;
            return videoFromDB;
        }

        public Video Delete(int Id)
        {
            return this.repo.Delete(Id);
        }

        public List<Video> FindVideoByTitle(string title)
        {
            return this.repo.FindVideoByTitle(title);
        }
    }
}

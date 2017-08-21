using System;
using System.Collections.Generic;
using System.Linq;
using MenuAppDAL;
using MenuAppEntity;

namespace MenuAppBLL.Services
{
    class Service : IService
    {
        public Video Create(Video vid)
        {
            Video newVid;
            FakeDB.videos.Add(newVid = new Video()
            {
                Id = FakeDB.Id++,
                Title = vid.Title,
                Genre = vid.Genre
            });
            return newVid;
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.videos);
        }

        public Video Get(int Id)
        {
            return FakeDB.videos.FirstOrDefault(x => x.Id == Id);
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
            var vid = Get(Id);
            FakeDB.videos.Remove(vid);
            return vid;
        }
    }
}

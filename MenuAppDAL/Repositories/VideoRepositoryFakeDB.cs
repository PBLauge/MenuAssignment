using System;
using System.Collections.Generic;
using System.Linq;
using MenuAppDAL.Entities;

namespace MenuAppDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        #region
        private static int Id = 1;
        private static List<Video> Videos = new List<Video>();
        #endregion
        
        public Video Create(Video vid)
        {
            Video newVid;
            Videos.Add(newVid = new Video()
            {
                Id = Id++,
                Title = vid.Title,
                Genre = vid.Genre
            });
            return newVid;
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            Videos.Remove(vid);
            return vid;
        }

        public List<Video> FindVideoByTitle(string title)
        {
            return Videos.Where(v => v.Title.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}

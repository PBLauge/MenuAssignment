using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuAppDAL.Context;
using MenuAppEntity;

namespace MenuAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext _context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }



        public Video Create(Video vid)
        {
            
            _context.Videos.Add(vid);
            return vid;
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == Id);
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            _context.Videos.Remove(vid);
            return vid;
        }

        public List<Video> FindVideoByTitle(string title)
        {
            return _context.Videos.Where(v => v.Title.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}

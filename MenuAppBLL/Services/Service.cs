using System;
using System.Collections.Generic;
using System.Linq;
using MenuAppDAL;
using MenuAppEntity;

namespace MenuAppBLL.Services
{
    class Service : IService
    {
        private DALFacade facade;

        public Service(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(vid);
                uow.Save();
                return newVid;
            }

        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public Video Update(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(vid.Id);
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                   
                }
                videoFromDB.Title = vid.Title;
                videoFromDB.Genre = vid.Genre;
                uow.Save();
                return videoFromDB;
            }
            
            
            
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Save();
                return newVid;
            }
        }

        public List<Video> FindVideoByTitle(string title)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.FindVideoByTitle(title);
            }
        }
    }
}

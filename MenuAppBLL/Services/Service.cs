using System;
using System.Collections.Generic;
using System.Linq;
using MenuAppBLL.BO;
using MenuAppBLL.Converters;
using MenuAppDAL;
using MenuAppDAL.Entities;

namespace MenuAppBLL.Services
{
    class Service : IService
    {
        VideoConverter conv = new VideoConverter();

        private DALFacade facade;

        public Service(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(conv.Convert(vid));
                uow.Save();
                return conv.Convert(newVid);
            }

        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public VideoBO Update(VideoBO vid)
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
                return conv.Convert(videoFromDB);
            }
            
            
            
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Save();
                return conv.Convert(newVid);
            }
        }

        public List<VideoBO> FindVideoByTitle(string title)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.FindVideoByTitle(title).Select(conv.Convert).ToList();
            }
        }

       
    }
}

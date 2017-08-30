using System;
using System.Collections.Generic;
using System.Text;
using MenuAppBLL.BO;
using MenuAppDAL.Entities;

namespace MenuAppBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Title = vid.Title,
                Genre = vid.Genre
            };
        }

        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                Title = vid.Title,
                Genre = vid.Genre
            };
        }
    }
}

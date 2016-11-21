using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFNewsRepository : INewsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<News> News
        {
            get { return context.News.OrderByDescending(n => n.ID); }
        }
        public void SaveNews(News news)
        {
            if (news.ID == 0)
            {
                context.News.Add(news);
            }
            else
            {
                News dbEntry = context.News.Find(news.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = news.Title;
                    dbEntry.Time = news.Time;
                    dbEntry.ImageData = news.ImageData;
                    dbEntry.ImageMimeType = news.ImageMimeType;
                    dbEntry.Content = news.Content;
                    dbEntry.Remark = news.Remark;
                }
            }
            context.SaveChanges();
        }
        public News DeleteNews(int newsID)
        {
            News dbEntry = context.News.Find(newsID);
            if (dbEntry != null)
            {
                context.News.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFResearchNewsRepository:IResearchNewsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<ResearchNews> ResearchNews
        {
            get { return context.ResearchNews.OrderByDescending(n => n.ID); }
        }
        public void SaveResearchNews(ResearchNews ResearchNews)
        {
            if (ResearchNews.ID == 0)
            {
                context.ResearchNews.Add(ResearchNews);
            }
            else
            {
                ResearchNews dbEntry = context.ResearchNews.Find(ResearchNews.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = ResearchNews.Title;
                    dbEntry.Time = ResearchNews.Time;
                    dbEntry.Content = ResearchNews.Content;
                    dbEntry.Remark = ResearchNews.Remark;
                }
            }
            context.SaveChanges();
        }
        public ResearchNews DeleteResearchNews(int ResearchNewsID)
        {
            ResearchNews dbEntry = context.ResearchNews.Find(ResearchNewsID);
            if (dbEntry != null)
            {
                context.ResearchNews.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

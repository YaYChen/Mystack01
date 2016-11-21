using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFInformRepository : IInformRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Informs> Informs
        {
            get { return context.Informs.OrderByDescending(n => n.ID); }
        }
        public void SaveInfroms(Informs Informs)
        {
            if (Informs.ID == 0)
            {
                context.Informs.Add(Informs);
            }
            else
            {
                Informs dbEntry = context.Informs.Find(Informs.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = Informs.Title;
                    dbEntry.Time = Informs.Time;
                    dbEntry.Content = Informs.Content;
                    dbEntry.Document = Informs.Document;
                    dbEntry.Remark = Informs.Remark;
                }
            }
            context.SaveChanges();
        }
        public Informs DeleteNews(int InformsID)
        {
            Informs dbEntry = context.Informs.Find(InformsID);
            if (dbEntry != null)
            {
                context.Informs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

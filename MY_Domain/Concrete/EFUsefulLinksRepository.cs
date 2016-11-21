using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFUsefulLinksRepository:IUsefulLinksRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<UsefulLinks> UsefulLinks
        {
            get { return context.UsefulLinks.OrderByDescending(n => n.ID); }
        }
        public void SaveUserfulLinks(UsefulLinks usefulLinks)
        {
            if (usefulLinks.ID == 0)
            {
                context.UsefulLinks.Add(usefulLinks);
            }
            else
            {
                UsefulLinks dbEntry = context.UsefulLinks.Find(usefulLinks.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = usefulLinks.Title;
                    dbEntry.Link = usefulLinks.Link;
                    dbEntry.Remark = usefulLinks.Remark;
                }
            }
            context.SaveChanges();
        }
        public UsefulLinks DeleteUsefulLinks(int usefulLinksID)
        {
            UsefulLinks dbEntry = context.UsefulLinks.Find(usefulLinksID);
            if (dbEntry != null)
            {
                context.UsefulLinks.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

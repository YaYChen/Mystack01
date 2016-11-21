using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;
namespace MY_Domain.Concrete
{
    public class EFActivitiesRepository:IActivitiesRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Activities> Activities
        {
            get { return context.Activities.OrderByDescending(n => n.ID); }
        }
        public void SaveActivities(Activities Activities)
        {
            if (Activities.ID == 0)
            {
                context.Activities.Add(Activities);
            }
            else
            {
                Activities dbEntry = context.Activities.Find(Activities.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = Activities.Title;
                    dbEntry.Time = Activities.Time;
                    dbEntry.Content = Activities.Content;
                    dbEntry.Remark = Activities.Remark;
                }
            }
            context.SaveChanges();
        }
        public Activities DeleteActivities(int ActivitiesID)
        {
            Activities dbEntry = context.Activities.Find(ActivitiesID);
            if (dbEntry != null)
            {
                context.Activities.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

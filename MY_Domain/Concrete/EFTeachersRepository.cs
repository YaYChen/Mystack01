using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFTeachersRepository:ITeachersRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Teachers> Teachers
        {
            get { return context.Teachers.OrderBy(n => n.ID); }
        }
        public void SaveTeachers(Teachers teachers)
        {
            if (teachers.ID == 0)
            {
                context.Teachers.Add(teachers);
            }
            else
            {
                Teachers dbEntry = context.Teachers.Find(teachers.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = teachers.Name;
                    dbEntry.Title = teachers.Title;
                    dbEntry.ImageData = teachers.ImageData;
                    dbEntry.ImageMimeType = teachers.ImageMimeType;
                    dbEntry.Tell = teachers.Tell;
                    dbEntry.E_Mail = teachers.E_Mail;
                    dbEntry.Direction = teachers.Direction;
                    dbEntry.Resume = teachers.Resume;
                    dbEntry.Remark = teachers.Remark;
                }
            }
            context.SaveChanges();
        }
        public Teachers DeleteTeachers(int teachersID)
        {
            Teachers dbEntry = context.Teachers.Find(teachersID);
            if (dbEntry != null)
            {
                context.Teachers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

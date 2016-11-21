using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Abstract;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFAllIntroduceRepository:IAllIntroduceRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<AllIntroduce> AllIntroduce
        {
            get { return context.AllIntroduce; }
        }
        public void SaveAllIntroduce(AllIntroduce AllIntroduce)
        {
            if (AllIntroduce.ID == 0)
            {
                context.AllIntroduce.Add(AllIntroduce);
            }
            else
            {
                AllIntroduce dbEntry = context.AllIntroduce.Find(AllIntroduce.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = AllIntroduce.Title;
                    dbEntry.Content = AllIntroduce.Content;
                    dbEntry.Remark = AllIntroduce.Remark;
                }
            }
            context.SaveChanges();
        }
        public AllIntroduce DeleteAllIntroduce(int AllIntroduceID)
        {
            AllIntroduce dbEntry = context.AllIntroduce.Find(AllIntroduceID);
            if (dbEntry != null)
            {
                context.AllIntroduce.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

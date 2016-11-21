using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MY_Domain.Entities;

namespace WebExercise04.Models
{
    public class AllIntroduceList
    {
        public IEnumerable<AllIntroduce> AllIntroduce { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
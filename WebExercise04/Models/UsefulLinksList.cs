using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MY_Domain.Entities;

namespace WebExercise04.Models
{
    public class UsefulLinksList
    {
        public IList<List<UsefulLinks>> UsefulLinksListGroup { get; set; }
        //public IEnumerable<UsefulLinks> UsefulLinks { get; set; }
        //public PageInfo PageInfo { get; set; }
    }
}
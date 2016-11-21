using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MY_Domain.Entities;

namespace WebExercise04.Models
{
    public class ActivitiesList
    {
        public IEnumerable<Activities> Activities { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
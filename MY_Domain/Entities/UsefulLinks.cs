using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_Domain.Entities
{
    public class UsefulLinks
    {
        public int ID { get; set; }//序号
        public string Title { get; set; }//标题
        public string Link { get; set; }//链接
        public string Remark { get; set; }//备注
    }
}

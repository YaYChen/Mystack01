using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_Domain.Entities
{
    public class Informs
    {
        public int ID { get; set; }//序号
        public string Title { get; set; }//标题
        public string Time { get; set; }//时间
        public string Content { get; set; }//新闻内容
        public string Document { get; set; }//附件
        public string Remark { get; set; }//备注
    }
}

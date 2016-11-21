using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_Domain.Entities
{
    public class News
    {
        public int ID { get; set; }//序号
        public string Title { get; set; }//标题
        public string Time { get; set; }//时间
        public byte[] ImageData { get; set; }//标题图片（数据）
        public string ImageMimeType { get; set; }//标题图片（类型）
        public string Content { get; set; }//新闻内容
        public string Remark { get; set; }//备注
    }
}

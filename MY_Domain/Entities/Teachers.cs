using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_Domain.Entities
{
    public class Teachers
    {
        public int ID { get; set; }//序号
        public string Name { get; set; }//姓名
        public byte[] ImageData { get; set; }//照片（数据）
        public string ImageMimeType { get; set; }//照片（类型）
        public string Title { get; set; }//职称
        public string Tell { get; set; }//电话
        public string E_Mail { get; set; }//邮箱
        public string Direction { get; set; }//研究方向
        public string Resume { get; set; }//个人简历
        public string Remark { get; set; }//备注
    }
}

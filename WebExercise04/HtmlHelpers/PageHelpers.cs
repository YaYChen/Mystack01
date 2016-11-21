using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExercise04.Models;

namespace WebExercise04.HtmlHelpers
{
    public static class PageHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,PageInfo pageInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for(int i=1;i<=pageInfo.TotalPages;i++){
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
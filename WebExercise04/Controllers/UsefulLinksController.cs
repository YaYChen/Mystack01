using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY_Domain.Abstract;
using MY_Domain.Concrete;
using MY_Domain.Entities;
using WebExercise04.Models;


namespace WebExercise04.Controllers
{
    public class UsefulLinksController : Controller
    {
        //
        // GET: /UsefulLinks/
        private IUsefulLinksRepository repository;
        public int PageSize = 15;
        public UsefulLinksController(IUsefulLinksRepository usefulLinksRepository)
        {
            this.repository = usefulLinksRepository;

        }

        public PartialViewResult List_All()
        {
            UsefulLinksList usefulLinksModel = new UsefulLinksList();
            int a = repository.UsefulLinks.Count() / 5;
            int b= repository.UsefulLinks.Count() % 5;
            for (int i=0;i<=a;i++)
            {
                List<UsefulLinks> UsefulLinks = repository.UsefulLinks.Skip(5 * i).Take(5).ToList<UsefulLinks>();
                usefulLinksModel.UsefulLinksListGroup.Add(UsefulLinks);
            }
            if (b!=0)
            {
                List<UsefulLinks> UsefulLinks = repository.UsefulLinks.Skip(5 * a).Take(b).ToList<UsefulLinks>();
                usefulLinksModel.UsefulLinksListGroup.Add(UsefulLinks);
            }
            return PartialView(usefulLinksModel);
        }

    }
}

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
    public class ResearchNewsController : Controller
    {
        private IResearchNewsRepository repository;
        public int PageSize = 15;
        public ResearchNewsController(IResearchNewsRepository ResearchNewsRepository) 
        {
            this.repository = ResearchNewsRepository;
           
        }
        //
        // GET: /ResearchNews/

        public ViewResult List_All(int page = 1)
        {
            ResearchNewsList ResearchNewsModel = new ResearchNewsList
            {
                ResearchNews = repository.ResearchNews.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.ResearchNews.Count()
                }
            };
            return View(ResearchNewsModel);
        }

        public PartialViewResult List_Prief()
        {
            ResearchNewsList ResearchNewsModel = new ResearchNewsList
            {
                ResearchNews = repository.ResearchNews.Take(7)
            };
            return PartialView(ResearchNewsModel);
        }
        public ActionResult List_Single(int ResearchNewsID)
        {
            ResearchNewsList ResearchNewsModel = new ResearchNewsList
            {
                ResearchNews = repository.ResearchNews.Where(n => n.ID == ResearchNewsID)
            };
            return PartialView(ResearchNewsModel);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY_Domain.Abstract;
using MY_Domain.Concrete;
using MY_Domain.Entities;
using WebExercise04.Models;

namespace WebExercise03.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository repository;
        public int PageSize = 15;
        public NewsController(INewsRepository newsRepository) 
        {
            this.repository = newsRepository;
           
        }

        public ViewResult List_All(int page = 1)
        {
            NewsList newsModel = new NewsList
            {
                News = repository.News.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems=repository.News.Count()
                }
            };
            return View(newsModel);
        }
        public PartialViewResult List_Prief()         
        {
            NewsList newsModel = new NewsList
            {
                News = repository.News.Take(7)
            };
            return PartialView(newsModel);
        }
        public PartialViewResult List_Single(int newsID)
        {
            NewsList NewsModel = new NewsList
            {
                News = repository.News.Where(n => n.ID == newsID)
            };
            return PartialView(NewsModel);
        }
    }
}

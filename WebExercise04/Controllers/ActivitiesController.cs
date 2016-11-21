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
    public class ActivitiesController : Controller
    {
        private IActivitiesRepository repository;
        public int PageSize = 15;
        public ActivitiesController(IActivitiesRepository ActivitiesRepository) 
        {
            this.repository = ActivitiesRepository;
           
        }
        //
        // GET: /Activities/

        public ViewResult List_All(int page = 1)
        {
            ActivitiesList ActivitiesModel = new ActivitiesList
            {
                Activities = repository.Activities.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Activities.Count()
                }
            };
            return View(ActivitiesModel);
        }

        public PartialViewResult List_Prief()
        {
            ActivitiesList ActivitiesModel = new ActivitiesList
            {
                Activities = repository.Activities.Take(7)
            };
            return PartialView(ActivitiesModel);
        }
        public ActionResult List_Single(int ActivitiesID)
        {
            ActivitiesList ActivitiesModel = new ActivitiesList
            {
                Activities = repository.Activities.Where(n => n.ID == ActivitiesID)
            };
            return PartialView(ActivitiesModel);
        }

    }
}

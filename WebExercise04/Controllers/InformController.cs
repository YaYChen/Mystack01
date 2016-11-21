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
    public class InformController : Controller
    {
        private IInformRepository repository;
        public int PageSize = 15;
        public InformController(IInformRepository InformsRepository) 
        {
            this.repository = InformsRepository;
           
        }
        // GET: Inform
        public ViewResult List_All(int page = 1)
        {
            InformList InformsModel = new InformList
            {
                Informs = repository.Informs.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Informs.Count()
                }
            };
            return View(InformsModel);
        }
      
        public PartialViewResult Inform_Prief()
        {
            InformList InformsModel = new InformList
            {
                Informs = repository.Informs.Take(7)
            };
            return PartialView(InformsModel);
        }
        public ActionResult List_Single(int informID)
        {
            InformList InformsModel = new InformList
            {
                Informs = repository.Informs.Where(n => n.ID == informID)
            };
            return PartialView(InformsModel);
        }
    }
}
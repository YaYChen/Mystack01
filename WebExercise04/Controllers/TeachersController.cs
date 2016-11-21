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
    public class TeachersController : Controller
    {
        private ITeachersRepository repository;
        public int PageSize = 5;
        public TeachersController(ITeachersRepository teachersRepository) 
        {
            this.repository = teachersRepository;
           
        }
        //
        // GET: /Teachers/
        public ViewResult List_All(int page = 1)
        {
            TeachersList teachersModel = new TeachersList
            {
                Teachers = repository.Teachers.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Teachers.Count()
                }
            };
            return View(teachersModel);
        }
        public ActionResult List_Single(int teachersID)
        {
            TeachersList TeachersModel = new TeachersList
            {
                Teachers = repository.Teachers.Where(n => n.ID == teachersID)
            };
            return PartialView(TeachersModel);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}

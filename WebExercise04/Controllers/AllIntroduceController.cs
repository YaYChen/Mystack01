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
    public class AllIntroduceController : Controller
    {
        //
        // GET: /AllIntroduce/
        private IAllIntroduceRepository repository;
        public AllIntroduceController(IAllIntroduceRepository AllIntroduceRepository) 
        {
            this.repository = AllIntroduceRepository;
           
        }
        public ViewResult Introduce()
        {
            AllIntroduceList AllIntroduceModel = new AllIntroduceList
            {
                AllIntroduce = repository.AllIntroduce
            };
            return View(AllIntroduceModel);
        }

    }
}

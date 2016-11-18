using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BashParser.Data.Repositories;
using BashModels.Models;

namespace BashPosts.Controllers
{
    public class CommentController : Controller
    {
        private UnitOfWork unitOfWork;

        public CommentController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public ActionResult Index(Post post)
        {
            return View(unitOfWork.Comments.GetElementsList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            unitOfWork.Comments.Create(comment);
            unitOfWork.Comments.Save();
            return RedirectToAction("Index");
        }


    }
}
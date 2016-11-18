using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using BashParser.Data.Repositories;
using BashModels.Models;




namespace BashPosts.Controllers
{

    public class PostController : Controller
    {
        private UnitOfWork unitOfWork;

        public PostController()
        {
            unitOfWork = new UnitOfWork();
        }

         [HttpGet]
        public ActionResult Details(int id)
        {
            return View("~/Views/Post/IdIndex.cshtml", unitOfWork.Posts.GetElement(id));
        }

        public ActionResult Index()
        {
            return View(unitOfWork.Posts.GetElementsList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View(unitOfWork.Posts.GetElement(id));
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConf(int id)
        {
            unitOfWork.Posts.Delete(id);
            unitOfWork.Posts.Save();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "user, admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public ActionResult Create([Bind(Include = "PostID,Rating,Date,PostName,Text")] Post post)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Posts.Create(post);
                unitOfWork.Posts.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.Posts.GetElement(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "PostID,Rating,Date,PostName,Text")] Post post)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Posts.Edit(post);
                unitOfWork.Posts.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Humanizer;
using Linterest.Models;
using Microsoft.AspNet.Identity;

namespace Linterest.Controllers
{
    public class LinsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lins
        public ActionResult ShowAllUserPins()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            var userid = User.Identity.GetUserId();
            var user = db.Users.Include(u => u.Lins).FirstOrDefault(u => u.Id == userid);
            var model = user.Lins.Select(l => new
            {
                Name = l.Author.Handle,
                Image = l.ImageUrl,
                LinId = l.Id,
               Linkimage =  l.PinImageUrl,
               CreatedOn = l.CreatedOn.Humanize(),
               Pintext = l.Text,
               NumofComments = l.Comments.Count()
            });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetLinDetails(int linId)
        {
            var lin = db.Lins.Find(linId);
            if (lin == null)
            {
                return HttpNotFound("No User Found");
            }

            var model = new
            {
                Name = lin.Author.Handle,
                image = lin.ImageUrl,
                LinId = lin.Id,
                linkimage = lin.PinImageUrl,
                CreatedOn = lin.CreatedOn.Humanize(),
                pintext = lin.Text,
                NumofComments = lin.Comments.Count(),
                Comments = lin.Comments.Select(l => new
                {
                    CommentId = l.Id,
                    Name = l.Author.Handle,
                    CreatedOn = l.CommentDate.Humanize(),
                    Text = l.CommentBody
                })
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveLin(CreateLinVM model)
        {
            if (!ModelState.IsValid)
                return Json(new {Message = "Try Again"});

            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);

            var lin = new Lin()
            {
                Author = user,
                CreatedOn = DateTime.UtcNow,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                PinImageUrl = string.IsNullOrEmpty(model.PinImageUrl) ? model.ImageUrl : model.PinImageUrl
            };

            db.Lins.Add(lin);
            db.SaveChanges();

            var result = new
            {
                Owner = lin.Author.Handle,
                lin.ImageUrl,
                lin.PinImageUrl,
                LinId = lin.Id,
                lin.Text,
                CreatedOn = lin.CreatedOn.Humanize(),
                NumOfComments = lin.Comments.Count()
            };
            return Json(model);
        }
    }
}
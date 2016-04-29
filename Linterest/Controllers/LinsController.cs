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
            var userid = User.Identity.GetUserId();
            var user = db.Users.Include(u => u.Lins).FirstOrDefault(u => u.Id == userid);
            var model = user.Lins.Select(l => new
            {
                Name = l.Author.Handle,
               image =  l.PinImageUrl,
               createdOn = l.CreatedOn.Humanize(),
               pintext = l.Text,
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
                Image = lin.ImageUrl,
                date = lin.CreatedOn.Humanize(),
                Lintext = lin.Text,
                NumofComments = lin.Comments.Count(),
                LinComments = lin.Comments.Select(l => new
                {
                    Name = l.Author.Handle,
                    Createdby = l.CommentDate.Humanize(),
                    Text = l.CommentBody
                })
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
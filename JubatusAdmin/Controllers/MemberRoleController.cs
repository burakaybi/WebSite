using JubatusAdmin.Models;
using JubatusAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JubatusAdmin.Controllers
{
    public class MemberRoleController : Controller
    {
        JAdminEntities db = new JAdminEntities();
        public ActionResult Index()
        {
            MemberRoleViewModel memberRoleViewModel = new MemberRoleViewModel();
            memberRoleViewModel.MemberRoleList = db.MemberRole.ToList();
            return View(memberRoleViewModel);
        }
        public ActionResult NewRole()
        {
            var model = new MemberRoleViewModel()
            {
                MemberRole = new MemberRole()
            };
            return View(model);
        }
        public ActionResult AddRole(MemberRole role)
        {
            role.IsActive = 1;
            var checkRole = db.MemberRole.Where(x => x.MemberRoleDesc == role.MemberRoleDesc).SingleOrDefault();
            if(checkRole==null)
            {
                if (!ModelState.IsValid)
                {
                    var model = new MemberRoleViewModel();
                    return RedirectToAction("NewRole", model);
                }
                db.MemberRole.Add(role);
                db.SaveChanges();
                ViewBag.Mesaj = "Ekleme işlemi başarılı...";
            }
            else if (checkRole.MemberRoleDesc == role.MemberRoleDesc)
            {
                ViewBag.Mesaj = "Eklemeye çalıştığınız Rol sistemde mevcut...";
            }
            return RedirectToAction("Index");
        }
        public ActionResult ShowRole(int id)
        {
            var memberRoleViewModel = new MemberRoleViewModel()
            {
                MemberRole = db.MemberRole.Find(id)
            };
            return PartialView(memberRoleViewModel);
        }
        [HttpPost]
        public ActionResult UpdateRole(MemberRole memberrole)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                db.Entry(memberrole).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
        }
        public ActionResult ShowActiveOrPassiveQuestion(int id)
        {
            var memberRoleViewModel = new MemberRoleViewModel()
            {
                MemberRole = db.MemberRole.Find(id)
            };
            return PartialView(memberRoleViewModel);
        }
        [HttpPost]
        public ActionResult UpdateActiveOrPassive(MemberRole memberrole)
        {
            if(memberrole.IsActive==0)
            {
                memberrole.IsActive = 1;
            }
            else
            {
                memberrole.IsActive = 0;
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                db.Entry(memberrole).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
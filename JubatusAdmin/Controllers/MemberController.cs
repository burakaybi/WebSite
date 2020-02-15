using JubatusAdmin.Models;
using JubatusAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JubatusAdmin.Controllers
{
    public class MemberController : Controller
    {
        JAdminEntities db = new JAdminEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewMember()
        {
            MemberViewModel model = new MemberViewModel()
            {
                Roles = db.MemberRole.Where(s => s.IsActive != 0).ToList()
            };
            return View("MemberAdd", model);
        }
        [HttpPost]
        public ActionResult MemberAdd(Member member)
        {
            member.IsActive = db.MemberRole.Where(x => x.MemberRoleId == member.MemberRoleId).Select(s => s.IsActive).FirstOrDefault();
            member.Password = Membership.GeneratePassword(6, 1).ToUpper();
            var checkEmail = db.Member.Where(x => x.Email == member.Email).SingleOrDefault();
            var model = new MemberViewModel();
            model.Roles = db.MemberRole.ToList();
            if (checkEmail == null)
            {
                if (!ModelState.IsValid)
                {
                    return View("MemberAdd", model);
                }
                db.Member.Add(member);
                db.SaveChanges();
                ViewBag.Mesaj = "Ekleme işlemi başarılı...";
            }
            else if (checkEmail.Email == member.Email)
            {
                ViewBag.Mesaj = "Eklemeye çalıştığınız E-mail adresi sistemde mevcut...";
            }
            return View("MemberAdd", model);
        }
        public ActionResult MemberList()
        {
            MemberDetailViewModel memberDetailViewModel = new MemberDetailViewModel();
            memberDetailViewModel.MemberList = (from a in db.Member join b in db.MemberRole on a.MemberRoleId equals b.MemberRoleId select new MemberDetail { Email = a.Email, IsActive = b.IsActive, MemberId = a.MemberId, MemberRoleDesc = b.MemberRoleDesc, MemberRoleId = a.MemberRoleId, Password = a.Password }).ToList();
            return View("MemberList", memberDetailViewModel);
        }
        public ActionResult ShowUpdate(int id)
        {
            MemberDetailViewModel memberDetailViewModel = new MemberDetailViewModel();
            memberDetailViewModel.UpdatedMember = (from a in db.Member join b in db.MemberRole on a.MemberRoleId equals b.MemberRoleId where a.MemberId == id select new MemberDetail { Email = a.Email, IsActive = b.IsActive, MemberId = a.MemberId, MemberRoleDesc = b.MemberRoleDesc, MemberRoleId = a.MemberRoleId, Password = a.Password }).First();
            memberDetailViewModel.Roles = db.MemberRole.Where(s => s.IsActive != 0).ToList();
            return PartialView(memberDetailViewModel);
        }
        //Kaydetme işleminde hata veriyor.
        [HttpPost]
        public ActionResult Update(MemberDetailViewModel memberDetail)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("MemberList");
            }
            else
            {
                var updatedUser = db.Member.SingleOrDefault(x => x.MemberId == memberDetail.UpdatedMember.MemberId);
                updatedUser.Email = memberDetail.UpdatedMember.Email;
                updatedUser.IsActive = memberDetail.UpdatedMember.IsActive;
                updatedUser.MemberId = memberDetail.UpdatedMember.MemberId;
                updatedUser.MemberRoleId = memberDetail.UpdatedMember.MemberRoleId;
                updatedUser.Password = memberDetail.UpdatedMember.Password;
                db.Entry(updatedUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MemberList");
            }
        }
        public ActionResult ShowDelete(int id)
        {
            var memberViewModel = new MemberViewModel()
            {
                MemberId = db.Member.Where(s => s.MemberId == id).Select(s => s.MemberId).First()
            };
            return PartialView(memberViewModel);
        }
        [HttpPost]
        public ActionResult Delete(MemberViewModel memberViewModel)
        {
            Member silinecekKullanici = db.Member.Where(s => s.MemberId == memberViewModel.MemberId).First();
            if (silinecekKullanici == null)
                return HttpNotFound();
            db.Member.Remove(silinecekKullanici);
            db.SaveChanges();
            return RedirectToAction("MemberList");
        }
    }
}
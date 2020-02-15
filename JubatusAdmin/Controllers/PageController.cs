using JubatusAdmin.Models;
using JubatusAdmin.ViewModels;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Web.Security;

namespace JubatusAdmin.Controllers
{
    public class PageController : Controller
    {
        JAdminEntities db = new JAdminEntities();

        public ActionResult Login()
        {
            MemberViewModel memberViewModel = new MemberViewModel();
            return View(memberViewModel);
        }
        //Email:admin@jubatus.com.tr Şifre:12345
        [HttpPost] //anasayfa-kullanıcı yönetimi-kategori yönetimi- çıkış sol bar ve tap bar. Shared 
        public ActionResult Login(MemberViewModel member)
        {
            var memberInDb = db.Member.FirstOrDefault(x => x.Email == member.Email && x.Password == member.Password);
            if (memberInDb != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
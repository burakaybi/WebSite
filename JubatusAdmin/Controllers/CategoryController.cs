using JubatusAdmin.Models;
using JubatusAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JubatusAdmin.Controllers
{
    public class CategoryController : Controller
    {
        JAdminEntities db = new JAdminEntities();

        public ActionResult CategoryList()
        {
            var category = db.Categories.ToList();
            return View(category);
        }


        public ActionResult AddCategory()
        {
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            categoriesViewModel.CategorieName = "";
            return View(categoriesViewModel);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoriesViewModel categoryViewModel)
        {
            Categories category = new Categories();
            category.CategorieName = categoryViewModel.CategorieName;
            category.CreatedBy = 1;
            category.CreateTime = DateTime.Now;
            category.IsEnabled = true;
            db.Categories.Add(category);
            db.SaveChanges();
            categoryViewModel.ResultMessage = "Başarıyla eklendi.";

            return View(categoryViewModel);
        }

        public ActionResult RemoveCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
       
        public ActionResult ShowCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View("ShowCategory", category);
        }
        
        public ActionResult CategoryUpdate(Categories cat)
        {
            var category = db.Categories.Find(cat.CategorieId);
            category.CategorieName = cat.CategorieName;
            category.IsEnabled = cat.IsEnabled;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }


    }






}
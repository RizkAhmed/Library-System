using MVC_DEMO_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DEMO_2.Controllers
{
    public class ProductController : Controller
    {
        static public BikeStoresEntities context = new BikeStoresEntities();

         SelectList brandList = new SelectList(context.brands.ToList(), "brand_id", "brand_name");
        SelectList categoryList = new SelectList(context.categories.ToList(), "category_id", "category_name");
        // GET: Product
        public ActionResult Index()
        {
            return View(context.products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var pro = context.products.FirstOrDefault(e => e.product_id==id);
            return View(pro);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
           
            ViewBag.brandList = brandList;
            ViewBag.categoryList = categoryList;

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product pro)
        {
            try
            {
                // TODO: Add insert logic here
                context.products.Add(pro);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var pro = context.products.FirstOrDefault(e => e.product_id == id);
            ViewBag.brandList = brandList;
            ViewBag.categoryList = categoryList;
            return View(pro);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product pro)
        {
            try
            {
                // TODO: Add update logic here
                var temp = context.products.FirstOrDefault(e => e.product_id == id);
                temp.product_name = pro.product_name;
                temp.brand_id = pro.brand_id;
                temp.category_id = pro.category_id;
                temp.model_year = pro.model_year;
                temp.list_price = pro.list_price;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var pro = context.products.FirstOrDefault(e => e.product_id == id);
            return View(pro);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var pro = context.products.FirstOrDefault(e => e.product_id == id);
                context.products.Remove(pro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

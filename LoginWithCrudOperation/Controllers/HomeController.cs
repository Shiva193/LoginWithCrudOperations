using LoginWithCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  LoginWithCrudOperation.Database_Access_Layer;
using System.IO;
using System.Web.UI.WebControls;

namespace LoginWithCrudOperation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Database_Access_Layer.db1 dblayer = new Database_Access_Layer.db1();
        public ActionResult ProductIndex()
        {
            return View(dblayer.GetPruducts.ToList());
        }
        public ActionResult ProductDetails(string id)
        {
            return View(dblayer.GetPruducts.Single(x=>x.ProductId==id));
        }
        public ActionResult AddProduct()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p, IEnumerable<HttpPostedFileBase> file)
        {
            string filename = "";
            string tempfilename="";
            foreach (var item in file)
            {
                if (item != null && item.ContentLength > 0)
                {
                    tempfilename = Path.GetFileName(item.FileName);
                    filename = filename + Path.GetFileName(item.FileName);
                    string fileext = Path.GetExtension(filename);
                    if (fileext == ".jpg" || fileext == ".png")
                    {
                        string filepath = Path.Combine(Server.MapPath("~/Images"), tempfilename);
                        item.SaveAs(filepath);
                        filename = filename + ":";
                    }

                }
            }
            filename = filename.TrimEnd(':');
            string[] imagearray = filename.Split(':');
            p.ImagePath = imagearray[0].ToString();
            p.ImagePath2 = imagearray[1].ToString();
            p.ImagePath3 = imagearray[2].ToString();
            p.ImagePath4 = imagearray[3].ToString();
            dblayer.AddProduct(p);
            return RedirectToAction("ProductIndex");
        }
        public ActionResult UpdateProduct(string id)
        {
            return View(dblayer.GetPruducts.Single(x => x.ProductId == id));
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product p, IEnumerable<HttpPostedFileBase> file)
        {
            string filename = "";
            string tempfilename = "";
            foreach (var item in file)
            {
                if (item != null && item.ContentLength > 0)
                {
                    tempfilename = Path.GetFileName(item.FileName);
                    filename = filename + Path.GetFileName(item.FileName);
                    string fileext = Path.GetExtension(filename);
                    if (fileext == ".jpg" || fileext == ".png")
                    {
                        string filepath = Path.Combine(Server.MapPath("~/Images"), tempfilename);
                        item.SaveAs(filepath);
                        filename = filename + ":";
                    }
                }
            }
            if (filename != "")
            {
                string[] imagearray = filename.Split(':');
                p.ImagePath = imagearray[0].ToString();
                p.ImagePath2 = imagearray[1].ToString();
                p.ImagePath3 = imagearray[2].ToString();
                p.ImagePath4 = imagearray[3].ToString();
            }
            dblayer.UpdateProduct(p);
            return RedirectToAction("ProductIndex");
        }
        public ActionResult DeleteProduct(string id)
        {
            dblayer.DeleteProduct(id);
            return RedirectToAction("ProductIndex");
        }
        public ActionResult Index()
        {
            return View(dblayer.EmpList.ToList());
        }

        public ActionResult Details(int? id)
        {
            return View(dblayer.EmpList.Single(x => x.EmpId == id));
        }
        public ActionResult AddRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRecord(Employee emp, HttpPostedFileBase file)
        {
            string filename = "";
            if (file != null && file.ContentLength > 0)
            {
                filename = Path.GetFileName(file.FileName);
                string fileext = Path.GetExtension(filename);
                if (fileext == ".jpg" || fileext == ".png")
                {
                    string filepath = Path.Combine(Server.MapPath("~/Images"),filename);
                    file.SaveAs(filepath);
                }
            }
            dblayer.AddRecord(emp, filename);
            return RedirectToAction("Index");
        }
       
        public ActionResult Edit(int id)
        {
            return View(dblayer.EmpList.Single(x => x.EmpId == id));
        }
        [HttpPost]
        public ActionResult Edit(Employee emp,HttpPostedFileBase file)
        {
            string filename = "";
            if (file != null && file.ContentLength > 0)
            {
                 filename = Path.GetFileName(file.FileName);
                string fileext = Path.GetExtension(filename);
                if (fileext == ".jpg" || fileext == ".png")
                {
                    string filepath = Path.Combine(Server.MapPath("~/Images"), filename);
                    file.SaveAs(filepath);
                }
            }
            dblayer.UpdateRecord(emp, filename);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            dblayer.DeleteRecord(id);
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            //dblayer.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
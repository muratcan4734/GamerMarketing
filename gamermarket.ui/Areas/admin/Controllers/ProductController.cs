using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using GamerMarket.Service.Service.TransferObjects.VM;
using GamerMarket.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamerMarket.Service.Service.TransferObjects.DTO;


namespace GamerMarket.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        CategoryService _categoryService;
        ProductService _productService;

        public ProductController()
        {
            _categoryService = new CategoryService();
            _productService = new ProductService();
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            //Ürün girişinde kategori seçileceği için view boş gönderilmez.
            return View(_categoryService.GetActive());
        }

        [HttpPost]
        public ActionResult Add(Product data, HttpPostedFileBase Image)
        {
            //ImageUploader Utility katmanında.

            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            //Eğer 0 veya 1 veya 2 geldiyse bir hata almışızdır. o durumda gidip default bir image tanımlayalım.

            if (data.ImagePath=="0" || data.ImagePath =="1" || data.ImagePath=="2")
            {
                //Varsayılan görsel
                data.ImagePath = "/Uploads/gamer_logo.png";
            }
            _productService.Add(data);


            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(_productService.GetActive());
        }
        public ActionResult Delete(Guid id)
        {
            _productService.Remove(id);

            return RedirectToAction("List");
        }
        
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            ProductUpdateVM model = new ProductUpdateVM();

            Product itemToBeUpdated = _productService.GetById(id);

            model.Product.ID = itemToBeUpdated.ID;
            model.Product.Name = itemToBeUpdated.Name;
            model.Product.Price = itemToBeUpdated.Price;
            model.Product.UnitsInStock = itemToBeUpdated.UnitsInStock;
            model.Product.Quantity = itemToBeUpdated.Quantity;
            model.Product.ImagePath = itemToBeUpdated.ImagePath;
            model.Product.CategoryID = itemToBeUpdated.CategoryID;
            model.Product.DisplayOnWeb = itemToBeUpdated.DisplayOnWeb;
            model.Product.DisplayOnMobile = itemToBeUpdated.DisplayOnMobile;

            //View'e gidecek bu modelin ürün bölümünü tamamladık. Sıra tüm kaktegorileri göndermede.
            //Kategorierde direk entity tipinde değil, categoryDTO tipinde olduğu için, select ile atamaları gerçekleştiriyoruz.

            //model.Categories = _categoryService.GetActive();

            model.Categories = _categoryService.GetActive().Select(c => new CategoryDTO
            {
                ID=c.ID,
                Name=c.Name,
                Description=c.Description

            }).ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(ProductDTO data, HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            Product itemToBeUpdated = _productService.GetById(data.ID);

            if (data.ImagePath!="0" && data.ImagePath!= "1" && data.ImagePath!="2")
            {
                //Eğer bu hatalardan biri alınmadıysa, kullanıcı yeni bir görsel eklemiştir.
                itemToBeUpdated.ImagePath = data.ImagePath;
            }

            itemToBeUpdated.Name = data.Name;
            itemToBeUpdated.Price = data.Price;
            itemToBeUpdated.UnitsInStock = data.UnitsInStock;
            itemToBeUpdated.Quantity = data.Quantity;
            itemToBeUpdated.CategoryID = data.CategoryID;
            itemToBeUpdated.DisplayOnWeb = data.DisplayOnWeb;
            itemToBeUpdated.DisplayOnMobile = data.DisplayOnMobile;

            _productService.Update(itemToBeUpdated);

            return RedirectToAction("List");
        }

    }
}
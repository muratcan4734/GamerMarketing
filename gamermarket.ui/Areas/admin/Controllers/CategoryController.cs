using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using GamerMarket.Service.Service.TransferObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            //Aynı isimde kategori oluşturulmasın
            if (_categoryService.Any(x => x.Name == data.Name)) return RedirectToAction("List");
            //İsterseniz viewbag ile bu adın kullanımda olduğunu mesaj olarak dönebilirsiniz. List metoduna yönlendirmeye gerek kalmaz.

            _categoryService.Add(data);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(_categoryService.GetActive());
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.Remove(id);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            //Id boş ise alttaki işlemleri yapmaz. tekrar liste ekranına döner.
            if (id == null) return RedirectToAction("List");

            Category guncellenecek = _categoryService.GetById((Guid)id);

            //Bu data transfer object sınıfları sayesinde çok daha az veriyi gönderiyoruz ve işlerimizi hızlandırıyoruz.
            //İstersek bu sınıfa belirli kurallar ekleyebilirdik(Requiried vea maxlength vb) ve bu kurallar veri tabanı sınıfına yani entity sınıfına eklenmediği için db tarafında bir değişiklik yaratmazdı.
            //Başka bir artısı ise view içerisine tek model gönderebiliyoruz ama bu dto sınıfları sayesinde içerisine birçok farklı tipte değer atabiliriz ve istediğimiz kadar veriyi view tarafına taşıyabiliriz.

            CategoryDTO model = new CategoryDTO();
            model.ID = guncellenecek.ID;
            model.Name = guncellenecek.Name;
            model.Description = guncellenecek.Description;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Category data)
        {
            //Tablodan doğru kaydı bulduk. Onun üzerine post edilen data değerlerini attık ve güncelleme işlemini tamamladık.
            Category guncellenecek = _categoryService.GetById(data.ID);
            guncellenecek.Name = data.Name;
            guncellenecek.Description = data.Description;
            _categoryService.Update(guncellenecek);

            return RedirectToAction("List");
        }

    }
}
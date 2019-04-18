using GamerMarket.Service.Service.TransferObjects.DTO;
using System.Collections.Generic;


namespace GamerMarket.Service.Service.TransferObjects.VM
{
    public class ProductUpdateVM
    {

        //Bu sınıfta hem güncellenme izni verilen product özelliklerini , hem de güncelleme yapılacağı için tüm kategori listesini gönderebileceğim bir model sınıfı oluşturuyorum. View içerisine gönderilecek custom bir model olduğundan sınıf isminde hem adını, hem de view model olduğunu gösteren vm bölümünü eklıyoruz.

        public ProductUpdateVM()
        {
            Categories = new List<CategoryDTO>();
            Product = new ProductDTO();
        }

        public ProductDTO Product{ get; set; }
        public List<CategoryDTO> Categories{ get; set; }
    }
}
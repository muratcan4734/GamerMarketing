using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GamerMarket.Utility
{
    //Hata Kodları:
    //0 => Dosya Yok
    //1 => O Dosya Zaten Var Hatası
    //2 => Uzantı Hatası
    public class ImageUploader
    {
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                //Kullanıcının gönderdiği dosyanın adını değiştirmek için (kendi dosya/klasör yolu ile birlikte gelecektir. O şekilde kaydetmek istemeyiz :D) altta değişken oluşturuyoruz.
                var uniqueName = Guid.NewGuid();
                //Server yolunda ~ işaretleri kalmasın diye onları yok ediyoruz.
                serverPath = serverPath.Replace("~", string.Empty);

                string[] fileArray = file.FileName.Split('.');

                //Dosyanın uzantısını yakalıyoruz.
                string extension = fileArray[fileArray.Length - 1].ToLower();

                //Bize gönderilen dosyanın ismini değiştirp, uzantısını sakladık ki, dosya hatasız kullanılmaya devam edebilsin. Tipini bozmayalım :D

                string filename = uniqueName + "." + extension;

                //Uzantı Kontrolü => Eğer kabul ettiğimiz uzantılardan birinde değilse, hata kodu gönder.
                if (extension=="jpg" || extension=="png" || extension=="jpeg" || extension=="gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+filename)))
                    {
                        //Eğer dosya zaten varsa 
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath+filename);
                        file.SaveAs(filePath);
                        //Dosyayı parametrede belirttiğim klasöre kaydediyorum ve yolu geriye döndürüyorum. Bu sayede veritabanında biz image yolunu tutabileceğiz.
                        return serverPath + filename;
                    }
                }
                else
                {
                    //Dosya uzantısı hatası
                    return "2";
                }
            }
            else
            {

                return "0";
            }
        }
    }
}
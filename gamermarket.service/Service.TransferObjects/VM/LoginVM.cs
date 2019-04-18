using System.ComponentModel.DataAnnotations;

namespace GamerMarket.Service.Service.TransferObjects.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola Giriniz")]
        public string Password { get; set; }
    }
}

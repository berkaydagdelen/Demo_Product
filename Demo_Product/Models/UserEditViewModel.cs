using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserEditViewModel
    {

        [Required(ErrorMessage = "Lütfen isim değeri giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisim değeri giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı değeri giriniz.")]

        public string Mail { get; set; }


        [Required(ErrorMessage = "Lütfen cinsiyet seçiniz.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Lütfen şifre değeri giriniz.")]
        public string Password { get; set; }    

        [Required(ErrorMessage = "Lütfen şifre değeri giriniz.")]
        [Compare("Password", ErrorMessage = "Lütfen şifrelerin eşlediğinden emin olun.")]
        public string ConfirmPassword { get; set; }

    }
}

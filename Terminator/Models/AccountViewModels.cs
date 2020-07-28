using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerminiDostave.Models
{

    public class LoginViewModel
    {
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Email naslov")]
        [EmailAddress(ErrorMessage = "Vnesi pravilen email naslov!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [DataType(DataType.Password)]
        [Display(Name = "Geslo")]
        public string Password { get; set; }

        [Display(Name = "Zapomni si me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage="To polje je obvezno!")]
        [Display( Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Priimek")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Podjetje")]
        public string Company { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Telefonska številka")]
        [RegularExpression("[0-9 -]+",ErrorMessage ="Telefonska številka lahko sestoji le iz številk")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [EmailAddress(ErrorMessage = "Vnesite pravilen email naslov!")]
        [Display(Name = "Email naslov")]
        public string Email { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [StringLength(100, ErrorMessage = "{0} mora imeti vsaj {2} znakov.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(".*[a-zA-Z].*[0-9].*|.*[0-9].*[a-zA-Z].*", ErrorMessage = "Geslo mora vsebovati tako črke kot številke!")]
        [Display(Name = "Geslo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [DataType(DataType.Password)]
        [Display(Name = "Potrdi geslo")]
        [Compare("Password", ErrorMessage = "Gesli se ne ujemata.")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email naslov")]
        public string Email { get; set; }
    }
}

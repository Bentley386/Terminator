using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace TerminiDostave.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} mora imeti vsaj {2} znakov.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Novo geslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potrdi novo geslo")]
        [Compare("NewPassword", ErrorMessage = "Gesli se ne ujemata.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutno geslo")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} mora imeti vsaj {2} znakov.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(".*[a-zA-Z].*[0-9].*|.*[0-9].*[a-zA-Z].*", ErrorMessage = "Novo geslo mora vsebovati tako črke kot številke!")]
        [Display(Name = "Novo geslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potrdi novo geslo")]
        [Compare("NewPassword", ErrorMessage = "Gesli se ne ujemata.")]
        public string ConfirmPassword { get; set; }
    }

   
}
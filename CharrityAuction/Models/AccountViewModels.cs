using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharrityAuction.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceName= "RegistrationErrorMessage", ErrorMessageResourceType =typeof(Resource))]
        [EmailAddress]
        [Display(ResourceType =typeof(Resource), Name ="RegistrationEmail")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "RegistrationErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationName")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "RegistrationErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationLastName")]
        public string LastName { get; set; }
        [Required(ErrorMessageResourceName = "RegistrationErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationPhone")]
        public string Phone { get; set; }
        [Required(ErrorMessageResourceName = "RegistrationErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationNickname")]
        public string Nickname { get; set; }
        [Required(ErrorMessageResourceName = "RegistrationErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceName = "RegistrationPasswordError",ErrorMessageResourceType = typeof(Resource), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationPassword")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationConfirmPassword")]
        [Compare("Password", ErrorMessageResourceName = "RegistrationPasswordNotMatching", ErrorMessageResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "RegistrationPasswordError", ErrorMessageResourceType = typeof(Resource), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessageResourceName = "RegistrationPasswordNotMatching", ErrorMessageResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

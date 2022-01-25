using Meta.IntroApp.Localizations.DataAnnotations;
using Meta.IntroApp.Localizations.Tokens;

using System.ComponentModel.DataAnnotations;

namespace Meta.IntroApp.APIModels
{
    public class ResetPasswordAPIModel
    {
        [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Email))]
        [Required(ErrorMessageResourceType = typeof(Tokens), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        //[RegularExpression(AppRuntimeConstants.PhoneNumberRegularExpression, ErrorMessageResourceType = typeof(Tokens), ErrorMessageResourceName = nameof(Tokens.NotAcceptableErrorTemplate))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Tokens), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        [MinLength(5, ErrorMessageResourceType = typeof(Tokens), ErrorMessageResourceName = nameof(DataAnnotations.PasswordMustBeAtLeast))]
        [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.NewPassword))]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Tokens), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.ConfirmationCode))]
        public string Code { get; set; }

    }

}

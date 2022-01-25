using Meta.IntroApp.Localizations.DataAnnotations;
using Meta.IntroApp.Localizations.Tokens;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meta.IntroApp.DTOs
{
    public class AddAboutUSDTO
    {
        [Display(Name = nameof(Tokens.Title), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public string Title { get; set; }

        [Display(Name = nameof(Tokens.Description), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public string Description { get; set; }

        [Display(Name = nameof(Tokens.Address), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public string Address { get; set; }

        [Display(Name = nameof(Tokens.Images), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public List<string> Images { get; set; }
    }


    //public class EditAboutUsDTO : AddAboutUSDTO
    //{
    //    [Display(Name = nameof(Tokens.Id), ResourceType = typeof(Tokens))]
    //    [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
    //    //public int? Id { set; get; }
    //}
}
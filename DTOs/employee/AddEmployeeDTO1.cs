using Meta.IntroApp.Localizations.DataAnnotations;
using Meta.IntroApp.Localizations.Tokens;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meta.IntroApp.DTOs
{
    public class ListEmployeeDTO
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public List<string> Images { get; set; }
    }

    public class UpdateEmployeeDTO
    {
        [Display(Name = nameof(Tokens.Id), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public int? Id { get; set; }

        [Display(Name = nameof(Tokens.FullName), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public string FullName { get; set; }

        [Display(Name = nameof(Tokens.Posiiton), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public string Position { get; set; }

        [Display(Name = nameof(Tokens.Images), ResourceType = typeof(Tokens))]
        [Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        public List<string> Images { get; set; }
    }
}
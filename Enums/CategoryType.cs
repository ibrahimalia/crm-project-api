using Meta.IntroApp.Localizations.Tokens;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Meta.IntroApp.Enums
{
    public enum CategoryType
    {
        [Display(Name = nameof(Tokens.Individual), ResourceType = typeof(Tokens))]
        Individual = 1,

        [Display(Name = nameof(Tokens.Company), ResourceType = typeof(Tokens))]
        Company = 2,
    }
}

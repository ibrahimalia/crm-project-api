using Meta.IntroApp.Localizations.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Enums
{
    public enum RequestStatus
    {
        [Display(Name = nameof(Tokens.Pending), ResourceType = typeof(Tokens))]
        Pending = 1,

        [Display(Name = nameof(Tokens.Active), ResourceType = typeof(Tokens))]
        Active = 2,
    }
}

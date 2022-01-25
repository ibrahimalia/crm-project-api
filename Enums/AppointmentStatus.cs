using Meta.IntroApp.Localizations.Tokens;

using System.ComponentModel.DataAnnotations;

namespace Meta.IntroApp.Enums
{
    public enum AppointmentStatus
    {
        [Display(Name = nameof(Tokens.Pending), ResourceType = typeof(Tokens))]
        Pending = 1,

        [Display(Name = nameof(Tokens.Cancelled), ResourceType = typeof(Tokens))]
        Cancelled = 2,

        [Display(Name = nameof(Tokens.Arrived), ResourceType = typeof(Tokens))]
        Arrived = 3,

        [Display(Name = nameof(Tokens.Done), ResourceType = typeof(Tokens))]
        Done = 4,
    };
}
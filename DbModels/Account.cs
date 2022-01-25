using Meta.IntroApp.DbModels;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta.IntroApp
{
    public enum AccountType
    {
        
        Admin = 1,
        Client = 2,
        
    }

    public class Account : IdentityUser<long>
    {
        public Account()
        {
            Appointments = new HashSet<MobAppointment>();
            FeedBacks = new HashSet<MobFeedBack>();
            MobRequests = new HashSet<MobRequest>();
        }

        public AccountType AccountType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetName() => FirstName + " " + LastName;
        public string Image { get; set; }
        public string MerchantId { get; set; }

        public virtual MobMerchant Merchant { get; set; }

        public virtual ICollection<MobAppointment> Appointments { get; set; }
        public virtual ICollection<MobFeedBack> FeedBacks { get; set; }
        public virtual ICollection<MobRequest> MobRequests { get; set; }
        public bool IsActive { get; set; }
        public string ConfirmationCode { get; set; }

        public DateTime? ConfirmationCodeEndDate { get; set; }
        public bool IsCodeConfirmed { get; set; }
    }


    public partial class Role : IdentityRole<long>
    {
        public Role()
        {
        }

    }



    [Table("AccountLogins")]
    public class AccountLogin : IdentityUserLogin<long>
    {
        [Key]
        public long Id { get; set; }
    }

    [Table("AccountRoles")]
    public class AccountRole : IdentityUserRole<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }

    [Table("RoleCalims")]
    public class RoleCalim : IdentityRoleClaim<long>
    {
    }

    [Table("AccountClaims")]
    public class AccountClaim : IdentityUserClaim<long>
    {
    }

    [Table("AccountTokens")]
    public class AccountToken : IdentityUserToken<long>
    {
        [Key]
        public long Id { get; set; }
    }
}
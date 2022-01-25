using Meta.IntroApp.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Meta.IntroApp.Services
{
    public class BaseService
    {
        private IHttpContextAccessor _httpContextAccessor;

        protected readonly MetaITechDbContext AppDbContext;

        public ILogger Logger {get;}
        public string CurrentMerchantId { get; }
        public int? CurrentBranchId { get; }
        public long? CurrentUserId { get; set; }

        public BaseService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            AppDbContext = context;
            Logger = _httpContextAccessor.HttpContext.RequestServices.GetService<ILogger<BaseService>>();

            CurrentMerchantId = MerchantDetecterHelper.GetCurrentMerchantId(_httpContextAccessor.HttpContext);
            CurrentBranchId = MerchantDetecterHelper.GetCurrentBranchId(_httpContextAccessor.HttpContext);
            CurrentUserId = MerchantDetecterHelper.GetCurrentUserId(_httpContextAccessor.HttpContext);
        }
    }
}
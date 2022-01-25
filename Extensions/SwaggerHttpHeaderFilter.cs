using Meta.IntroApp.Attributes;
using Meta.IntroApp.Helpers;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

using System.Collections.Generic;
using System.Reflection;

namespace API.Extensions
{
    public class SwaggerHttpHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            if (context.MethodInfo.GetCustomAttribute<IgnoreHeaderMearchantInfoAttribute>() == null)
            {

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = MerchantDetecterHelper.Merchant_ID_Header_Key,
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    }
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = MerchantDetecterHelper.Branch_ID_Header_Key,
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = MerchantDetecterHelper.User_ID_Header_Key,
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    }
                });
            }



            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                }
            });
            //context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo);
            ////adding authorization or not
            //context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo);
            //var hasAuthorize =
            //          methodInfo.GetCustomAttributes<AuthorizeAttribute>(true)
            //          .Any();
            //if (hasAuthorize)
            //{
            //    operation.Parameters.Add(new OpenApiParameter
            //    {
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Required = true,
            //        Schema = new OpenApiSchema
            //        {
            //            Type = "string",
            //        }
            //    });
            //}
        }
    }
}
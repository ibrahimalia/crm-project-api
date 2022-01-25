using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Threading.Tasks;

namespace API.Extensions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IWebHostEnvironment _env;

        public ILogger Logger { get; }

        public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionHandlingMiddleware> Logger)
        {
            this._next = next;
            this._env = env;
            this.Logger = Logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ApplicationException ex)
            {
                Logger.LogCritical(ex?.Message + ex?.StackTrace);
                //error response
                var result = new BaseAPIResult
                {
                    IsSuccess = false,
                    Message = ex?.Message ?? AppExceptions.UnExpectedError ?? AppExceptions.MerchantNotFound
                };
                context.Response.OnStarting((state) =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    return Task.FromResult(0);
                }, null);
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result, serializerSettings));
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                if (this._env.EnvironmentName == Environments.Development)
                    throw;
                Logger?.LogCritical(ex?.Message + ex?.StackTrace);
                //error response
                //toDo: remove the exception message
                var result = new BaseAPIResult
                {
                    IsSuccess = false,
                    Message = ex?.Message + ex?.InnerException?.Message + ex?.StackTrace ?? (this._env.EnvironmentName == Environments.Development ? ex.Message + ex.StackTrace : AppExceptions.UnExpectedError)
                };
                context.Response.OnStarting((state) =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    return Task.FromResult(0);
                }, null);

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result, serializerSettings));
                await Task.CompletedTask;
            }
        }
    }
}
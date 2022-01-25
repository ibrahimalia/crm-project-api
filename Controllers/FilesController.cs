
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.UploadFile;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Services.UploadFiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Meta.IntroApp.Controllers
{
    public class FilesController : BaseController
    {
        private readonly IUploadFileService _filesService;

        public FilesController(IUploadFileService filesService)
        {
            this._filesService = filesService;
        }
        
        /// <summary>
        /// Action to upload image file
        /// </summary>
        [HttpPost("UploadImage")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(APIResult<UploadFileDTO>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(BaseAPIResult))]
        public async Task<APIResult<UploadFileDTO>> UploadImage(IFormFile file)
        {
            file ??= Request.Form.Files.FirstOrDefault();
            if (file == null)
                throw new ApplicationException(AppExceptions.ImageIsRequired);
            return SuccessResponse(new UploadFileDTO
            {
                Url = $"{(await _filesService.UploadFileAsync(file)).WrapContentUrl()}"
            });
        }

        /// <summary>
        /// Action to upload image file
        /// </summary>
        [HttpPost("UploadImages")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(BaseAPIResult))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(APIResult<UploadFilesDTO>))]
        public async Task<APIResult<UploadFilesDTO>> UploadImages(List<IFormFile> files)
        {
            files ??= Request.Form.Files.ToList();
            var tasks = Request.Form.Files.Select(f => _filesService.UploadFileAsync(f));
            var urls = await Task.WhenAll(tasks.ToArray());
            return SuccessResponse(new UploadFilesDTO
            {
                Urls = urls.Select(url=> url.WrapContentUrl())
            });

        }


        /// <summary>
        /// Action to upload file
        /// </summary>
        [HttpPost("UploadFile")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(APIResult<UploadFileDTO>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(BaseAPIResult))]
        public async Task<APIResult<UploadFileDTO>> UploadFile(IFormFile file)
        {
            file ??= Request.Form.Files.FirstOrDefault();
            if (file == null)
                throw new ApplicationException(AppExceptions.ImageIsRequired);
            return SuccessResponse(new UploadFileDTO
            {
                Url = $"{(await _filesService.UploadAttachement(file)).WrapContentUrl()}"
            });
        }


        /// <summary>
        /// Action to upload list of files
        /// </summary>
        [HttpPost("UploadFiles")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(APIResult<List<UploadFilesDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(BaseAPIResult))]
        public async Task<APIResult<UploadFilesDTO>> UploadFiles(List<IFormFile> files)
        {
            files ??= Request.Form.Files.ToList();
            var tasks = Request.Form.Files.Select(f => _filesService.UploadAttachement(f));
            var urls = await Task.WhenAll(tasks.ToArray());
            return SuccessResponse(new UploadFilesDTO
            {
                Urls = urls.Select(url => url.WrapContentUrl())
            });

        }

    }
}

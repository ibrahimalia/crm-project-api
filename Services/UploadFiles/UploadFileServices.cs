
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.FixedValues;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PdfSharp.Pdf.IO;
using iTextSharp.text.pdf;
using System.Net.Http;

namespace Meta.IntroApp.Services.UploadFiles
{
    public class UploadFileServices : BaseService, IUploadFileService
    {
        public UploadFileServices(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }


        /// <summary>
        /// Upload file async
        /// </summary>
        /// <returns></returns>
        public Task<string> UploadFileAsync(IFormFile file)
        {
            return Task.Run(() =>
            {
                try
                {
                    string extension = Path.GetExtension(file.FileName);
                    string fileName = "File_" + Guid.NewGuid() + DateTime.Now.Ticks + extension;
                    string contentUrl = AppRuntimeConstants.ImagesSiteUrl;
                    string fileDirectoryPath = $"{CurrentMerchantId}/{CurrentBranchId}";
                    string fileRelativePath = $"{fileDirectoryPath}/{fileName}";
                    string fileFullPath = $"{AppRuntimeConstants.ContentFolderPhysicalPath}/{fileDirectoryPath}/{fileName}";

                    if (!Directory.Exists(AppRuntimeConstants.ContentFolderPhysicalPath))
                        throw new ApplicationException("The specified upload flder in configuration is not valid!");
                    else if (!Directory.Exists(AppRuntimeConstants.ContentFolderPhysicalPath + "/" + fileDirectoryPath))
                        Directory.CreateDirectory(AppRuntimeConstants.ContentFolderPhysicalPath + "/" + fileDirectoryPath);
                    var stream = new MemoryStream();
                    using (var image = new Bitmap(Image.FromStream(file.OpenReadStream())))
                    {
                        int width, height;
                        int fixedWIdthHeight = 700;
                        if (image.Width > image.Height)
                        {
                            width = fixedWIdthHeight;
                            height = Convert.ToInt32(image.Height * fixedWIdthHeight / (double)image.Width);
                        }
                        else
                        {
                            width = Convert.ToInt32(image.Width * fixedWIdthHeight / (double)image.Height);
                            height = fixedWIdthHeight;
                        }
                        var resized = new Bitmap(width, height);
                        using (var graphics = Graphics.FromImage(resized))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighSpeed;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.CompositingMode = CompositingMode.SourceCopy;
                            graphics.DrawImage(image, 0, 0, width, height);
                            using (var fileStream = File.Open(fileFullPath, FileMode.Create))
                            {
                                var qualityParamId = Encoder.Quality;
                                var encoderParameters = new EncoderParameters(1);
                                var quality = 90;
                                encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);
                                var codec = ImageCodecInfo.GetImageDecoders()
                                    .FirstOrDefault(code => extension.Split(".").LastOrDefault()?.ToLower() == "png" ? code.FormatID == ImageFormat.Png.Guid : code.FormatID == ImageFormat.Jpeg.Guid);
                                resized.Save(fileStream, codec, encoderParameters);
                                fileStream.Close();
                            }
                        }
                    }
                    return $"/{fileRelativePath}";
                }
                catch (ApplicationException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    Logger.LogCritical("Error in uploading image file", ex);
                    throw;
                }
            });

        }

        public Task<string> UploadAttachement(IFormFile file)
        {
            return Task.Run(() =>
            {
                try
                {
                    var client = new HttpClient();
                    string extension = Path.GetExtension(file.FileName);
                    string fileName = "File_" + Guid.NewGuid() + DateTime.Now.Ticks + extension;
                    string contentUrl = AppRuntimeConstants.ImagesSiteUrl;
                    string fileDirectoryPath = $"{CurrentMerchantId}/{CurrentBranchId}";
                    string fileRelativePath = $"{fileDirectoryPath}/{fileName}";
                    string fileFullPath = $"{AppRuntimeConstants.ContentFilesFolderPhysicalPath}/{fileDirectoryPath}/{fileName}";

                    if (!Directory.Exists(AppRuntimeConstants.ContentFilesFolderPhysicalPath))
                        throw new ApplicationException("The specified upload flder in configuration is not valid!");
                    else if (!Directory.Exists(AppRuntimeConstants.ContentFilesFolderPhysicalPath + "/" + fileDirectoryPath))
                        Directory.CreateDirectory(AppRuntimeConstants.ContentFilesFolderPhysicalPath + "/" + fileDirectoryPath);

                    //if (extension == ".pdf")
                    //{
                    //    byte[] docAsBytes;
                    //    using (var ms = new MemoryStream())
                    //    {
                    //        file.CopyTo(ms);
                    //        docAsBytes = ms.ToArray();
                    //    }

                    //    iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(docAsBytes);
                    //    MemoryStream m = new MemoryStream();
                    //    PdfStamper outStamper = new PdfStamper(pdfReader, m);
                    //    ByteArrayContent FileBytes = new ByteArrayContent(docAsBytes);
                    //    client.PostAsync(fileFullPath, FileBytes);
                    //}
                    //else
                    //{

                        using (FileStream stream = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write))
                        {
                        file.CopyTo(stream);
                            stream.Close();
                        };
                    //}

                    return $"/{fileRelativePath}";
                }
                catch (ApplicationException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    Logger.LogCritical("Error in uploading file", ex);
                    throw;
                }
            });

        }
    }
}
//using Meta.IntroApp.Models;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    //public class ImageController : ControllerBase
    //{
    //    //inject the repositories and dbcontext class

    //    private readonly I_Image _images;
    //    private readonly metaitec_constuctiondbContext context;
    //    public ImageController(I_Image images, metaitec_constuctiondbContext context)
    //    {
    //        _images = images;
    //        this.context = context;
    //    }
    //    /// <summary>
    //    /// get images for specific component
    //    /// </summary>
    //    /// <param name="userId"></param>
    //    /// <param name="branchName"></param>
    //    /// <param name="componentName"></param>
    //    /// <param name="goal"></param>
    //    /// <returns></returns>
    //    [HttpGet]
    //    [Route("GetImages")]
    //    public async Task<IActionResult> GetImages(string userId, string componentName, int componentId)
    //    {
    //        try
    //        {
    //            List<MobImage> result = await _images.GetImages(userId, componentN,);
    //            if (result == null)
    //            {
    //                DTO_Response Response1 = new DTO_Response(false, HttpStatusCode.NoContent, "NoContent!! there is no images", null);
    //                return Ok(Response1);
    //            }

    //            var Response = new DTO_Response(true, HttpStatusCode.OK, "SUCCESS!! Those are existing images", result);
    //            return Ok(Response);

    //        }
    //        catch (Exception)
    //        {
    //            var Response = new DTO_Response(false, HttpStatusCode.BadRequest, "failed!! there is an error in some where !! please send right request", null);
    //            return Ok(Response);
    //        }
    //    }

    //    /// <summary>
    //    /// update image for specific component
    //    /// </summary>
    //    /// <param name="userId"></param>
    //    /// <param name="branchName"></param>
    //    /// <param name="componentName"></param>
    //    /// <param name="goal"></param>
    //    /// <param name="newImage"></param>
    //    /// <returns></returns>
    //    [HttpPut]
    //    [Route("UpdateImage")]
    //    public async Task<IActionResult> UpdateImage(string userId, string branchName, string componentName, string goal, MobImage newImage)
    //    {
    //        var result = await _images.UpdateImage(userId, branchName, componentName, goal, newImage);

    //        if (result == 1)
    //        {
    //            var Response = new DTO_Response(true, HttpStatusCode.OK, "SUCCESS", null);
    //            return Ok(Response);
    //        }

    //        else
    //        {
    //            var Response = new DTO_Response(false, HttpStatusCode.NoContent, "failed", null);
    //            return Ok(Response);
    //        }
    //    }

    //    /// <summary>
    //    /// Delete imagefor specific component
    //    /// </summary>
    //    /// <param name="userId"></param>
    //    /// <param name="branchName"></param>
    //    /// <param name="ComponentName"></param>
    //    /// <param name="goal"></param>
    //    /// <returns></returns>
    //    [HttpDelete]
    //    [Route("DeleteImage")]
    //    public async Task<ActionResult> DeleteImage(string userId, string branchName, string ComponentName, string goal)
    //    {
    //        int result = await _images.DeleteImage(userId, branchName, ComponentName, goal);
    //        if (result == 0)
    //        {
    //            var Response = new DTO_Response(false, HttpStatusCode.NoContent, "failed", null);
    //            return Ok(Response);
    //        }
    //        else
    //        {
    //            var Response = new DTO_Response(true, HttpStatusCode.OK, "SUCCESS", null);
    //            return Ok(Response);
    //        }
    //    }
    //}
}
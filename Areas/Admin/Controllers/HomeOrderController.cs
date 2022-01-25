namespace Meta.IntroApp.Areas.Admin.Controllers
{
    //[Route("api/V1/[controller]")]
    //[ApiController]
    //public class HomeOrderController : Controller
    //{
    //        //inject the repositories and dbcontext class

    //        private readonly I_HomeOrder order;
    //        private readonly metadbContext context;
    //        public HomeOrderController(I_HomeOrder order, metadbContext context)
    //        {
    //            this.order = order;
    //            this.context = context;
    //        }

    ///// <summary>
    /////
    ///// </summary>
    ///// <param name="MerchantId"></param>
    ///// <returns></returns>
    //        [HttpGet]
    //        [Route("GetHomeOrder")]
    //        public async Task<IActionResult> GetHomeOrder(string MerchantId)
    //    {
    //            try
    //            {
    //            MobHomeOrder result = await order.GetHomeOrder(MerchantId);
    //                if (result == null)
    //                {
    //                    DTO_Response Response1 = new DTO_Response(false,204, "NoContent!! there is no data for this user", null);
    //                    return Ok(Response1);
    //                }

    //                var Response = new DTO_Response(true, 200, "SUCCESS!! Those are the components order ", result);
    //                return Ok(Response);

    //            }
    //            catch (Exception)
    //            {
    //                var Response = new DTO_Response(false, 400, "failed!! there is an error in some where !! please send right request", null);
    //                return Ok(Response);
    //            }
    //        }

    //        /// <summary>
    //        ///
    //       /// </summary>
    //       /// <param name="MerchantId"></param>
    //         /// <param name="homeOrder"></param>
    //          /// <returns></returns>
    //        [HttpPost]
    //        [Route("AddHomeOrder")]
    //        public async Task<IActionResult> AddHomeOrder(string MerchantId, MobHomeOrder homeOrder)
    //    {
    //            try
    //            {
    //            await order.AddHomeOrder(MerchantId, homeOrder);

    //                var Response = new DTO_Response(true, 201, "SUCCESS!! The order has been added successfully !!", null);
    //                return Ok(Response);

    //            }

    //            catch (Exception)
    //            {
    //                var Response = new DTO_Response(false, 400, "failed!! There was some error.Please send right request", null);
    //                return Ok(Response);
    //            }
    //        }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="MerchantId"></param>
    //    /// <param name="homeOrder"></param>
    //    /// <returns></returns>
    //        [HttpPut]
    //        [Route("UpdateHomeOrder")]
    //        public async Task<IActionResult> UpdateHomeOrder(string MerchantId, MobHomeOrder homeOrder)
    //    {
    //        var result = await order.UpdateHomeOrder(MerchantId, homeOrder);

    //            if (result == 1)
    //            {
    //                var Response = new DTO_Response(true, 201, "SUCCESS!! the order has been updated successfully!", null);
    //                return Ok(Response);
    //            }

    //            else
    //            {
    //                var Response = new DTO_Response(false, 400, "failed!! there is an error in some where!! please send right request", null);
    //                return Ok(Response);
    //            }
    //        }

    //        /// <summary>
    //        ///
    //        /// </summary>
    //        /// <param name="MerchantId"></param>
    //        /// <returns></returns>
    //        [HttpDelete]
    //        [Route("DeleteHomeOrder")]
    //        public async Task<ActionResult> DeleteHomeOrder(string MerchantId)
    //    {
    //        int result = await order.DeleteHomeOrder(MerchantId);
    //            if (result == 0)
    //            {
    //                var Response = new DTO_Response(false, 400, "failed to delete !!", null);
    //                return Ok(Response);
    //            }
    //            else
    //            {
    //                var Response = new DTO_Response(true, 200, "SUCCESS!! the order has been deleted.", null);
    //                return Ok(Response);
    //            }
    //        }
    //    }
}
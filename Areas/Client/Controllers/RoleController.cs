using Meta.IntroApp.DTOs;
using Meta.IntroApp.Localizations.AppExceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    //public class RoleController : BaseClientController
    //{
    //    private readonly RoleManager<IdentityRole> _roleManager;

    //    public RoleController(RoleManager<IdentityRole> roleManager)
    //    {
    //        _roleManager = roleManager;
    //    }

    //    [HttpPost]
    //    public async Task<BaseAPIResult> CreateRole(RoleDTO model)
    //    {
    //        var result = await _roleManager.CreateAsync(new IdentityRole
    //        {
    //            Name = model.RoleName
    //        });
    //        if (result.Succeeded)
    //            return BaseSuccessResponse();
    //        else
    //            return ErrorResponse(result.Errors.FirstOrDefault().Description);
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="model"></param>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    //[Authorize]
    //    [HttpPut]
    //    public async Task<BaseAPIResult> EditRole(string id, RoleDTO model)
    //    {
    //        var role = await _roleManager.FindByIdAsync(id);
    //        if (role != null)
    //        {
    //            role.Name = model.RoleName;
    //            var result = await _roleManager.UpdateAsync(role);

    //            if (result.Succeeded)
    //                return BaseSuccessResponse();
    //            return ErrorResponse();
    //        }
    //        else
    //            return ErrorResponse(AppExceptions.RoleNotFound);
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="Id"></param>
    //    /// <returns></returns>
    //    [HttpDelete]
    //    //[Authorize]
    //    public async Task<IActionResult> Roles(string Id)
    //    {
    //        try
    //        {
    //            var role = await _roleManager.FindByIdAsync(Id);

    //            if (role != null)
    //            {
    //                var result = await _roleManager.DeleteAsync(role);

    //                if (result.Succeeded)
    //                {
    //                    return Ok();
    //                }
    //                else

    //                { return BadRequest(); }
    //            }
    //            else return BadRequest();
    //        }
    //        catch (Exception)
    //        {
    //            return BadRequest();
    //        }
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpGet]
    //    public IActionResult Roles()
    //    {
    //        var roles = _roleManager.Roles;
    //        return Ok(roles);
    //    }
    //}
}
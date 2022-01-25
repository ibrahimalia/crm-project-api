using Meta.IntroApp.DTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class RoleController : BaseAdminController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Roles(RoleDTO createRoleViewModel)
        {
            try
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = createRoleViewModel.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="createRoleViewModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Roles(RoleDTO createRoleViewModel, string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);

                if (role != null)
                {
                    role.Name = createRoleViewModel.RoleName;
                    var result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else

                    { return BadRequest(); }
                }
                else return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        //[Authorize]
        public async Task<IActionResult> Roles(string Id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id);

                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else

                    { return BadRequest(); }
                }
                else return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }
    }
}
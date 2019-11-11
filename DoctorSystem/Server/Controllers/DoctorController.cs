using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoctorSystem.Server.Adapter;
using DoctorSystem.Server.Database;
using DoctorSystem.Shared.Model;
using DoctorSystem.Shared.Model.Entity;
using DoctorSystem.Shared.Model.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DoctorController : ParentControllerBase<Doctor, Doctor, int>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ApplicationDbContext _dbContext;
        //public DoctorController(ApplicationDbContext dbContext, IEntityAdapterFactory factory) : base(factory)
        //{
        //    this._dbContext = dbContext;
        //}
        public DoctorController(IEntityAdapterFactory factory, UserManager<ApplicationUser> userManager) : base(factory)
        {
            _userManager = userManager;
        }

        protected override Doctor InsertOrUpdateAdaptationOverride(Doctor dto)
        {
            var userTask = GetCurrentUserAsync(); userTask.RunSynchronously();
            ApplicationUser user = userTask.Result;
            dto.ApplicationUserId = user.Id;
            return base.InsertOrUpdateAdaptationOverride(dto);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}

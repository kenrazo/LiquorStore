using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Business.Helpers;
using LiquorStore.Business.LogicCollections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LiquorStore.ActionFilters
{
    /// <summary>
    /// Setup request info
    /// </summary>
    public class SetupRequestInfo : ActionFilterAttribute
    {
        private readonly IRequestInfo _requestInfo;
        private readonly IClaimAccessor _claimAccessor;

        public SetupRequestInfo(IClaimAccessor claimAccessor, IRequestInfo requestInfo)
        {
            _claimAccessor = claimAccessor;
            _requestInfo = requestInfo;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
            }
            else
            {
                var isAllowedAnonymous = false;

                if (actionContext.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    isAllowedAnonymous = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
                }

                if (!isAllowedAnonymous)
                {
                    var requestInformation = await _claimAccessor.GetClaims();
                    _requestInfo.SetCurrent(requestInformation);
                }

                await next();
            }
        }
    }
}

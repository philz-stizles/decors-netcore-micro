using Cart.Application.Contracts.Repositories;
using Cart.Application.Contracts.Services;
using Cart.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cart.API.Filters
{
    public class AuditFilterAttribute : ActionFilterAttribute
    {
        private readonly IAuditRepository _auditRepository;
        private readonly IUserAccessor _userAccessor;
        public AuditFilterAttribute(IUserAccessor userAccessor, IAuditRepository auditRepository)
        {
            _userAccessor = userAccessor;
            _auditRepository = auditRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var objaudit = new Audit();

            var controllerName = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.ControllerName;

            var actionName = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.ActionName;

            var actionDescriptorRouteValues = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.RouteValues;

//            if (actionDescriptorRouteValues.ContainsKey("area"))
//            {
//                var area = actionDescriptorRouteValues["area"];
//                if (area != null)
//                {
//                    objaudit.Area = Convert.ToString(area);
//                }
//            }

            var request = filterContext.HttpContext.Request;

            //            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session.GetInt32(AllSessionKeys.LangId))))
            //            {
            //                objaudit.LangId = Convert.ToString(filterContext.HttpContext.Session.GetInt32(AllSessionKeys.LangId));
            //            }
            //            else
            //            {
            //                objaudit.LangId = "";
            //            }

                        var userId = _userAccessor.GetCurrentUserId();
                        if (!string.IsNullOrEmpty(userId))
                            objaudit.UserId = userId;

            //            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session.GetInt32(AllSessionKeys.RoleId))))
            //            {
            //                objaudit.RoleId = Convert.ToString(filterContext.HttpContext.Session.GetInt32(AllSessionKeys.RoleId));
            //            }
            //            else
            //            {
            //                objaudit.RoleId = "";
            //            }


            //            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session.GetString(AllSessionKeys.IsFirstLogin))))
            //            {
            //                objaudit.IsFirstLogin = Convert.ToString(filterContext.HttpContext.Session.GetString(AllSessionKeys.IsFirstLogin));
            //            }
            //            else
            //            {
            //                objaudit.IsFirstLogin = "";
            //            }

            //            objaudit.SessionId = filterContext.HttpContext.Session.Id; ; // Application SessionID // User IPAddress 

            var userIp = _userAccessor.GetCurrentUserIp();
            if (!string.IsNullOrEmpty(userIp))
                objaudit.IpAddress = userIp;

//            objaudit.PageAccessed = Convert.ToString(filterContext.HttpContext.Request.Path); // URL User Requested 

//            objaudit.LoginStatus = "A";
            objaudit.ControllerName = controllerName;
            objaudit.ActionName = actionName;

            RequestHeaders header = request.GetTypedHeaders();
            Uri uriReferer = header.Referer;

            if (uriReferer != null)
            {
                objaudit.UrlReferrer = header.Referer.AbsoluteUri;
            }

            _auditRepository.AddAsync(objaudit).Wait();
        }
    }
}

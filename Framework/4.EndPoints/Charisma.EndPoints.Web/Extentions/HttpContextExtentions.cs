﻿using Framework.Core.Contracts.ApplicationServices.Commands;
using Framework.Core.Contracts.ApplicationServices.Events;
using Framework.Core.Contracts.ApplicationServices.Queries;
using Microsoft.AspNetCore.Http;
using Zamin.Utilities;

namespace Charisma.EndPoints.Web.Extentions
{
    public static class HttpContextExtensions
    {
        public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
            (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

        public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
            (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));
        public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
            (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));
        public static ZaminServices ZaminApplicationContext(this HttpContext httpContext) =>
            (ZaminServices)httpContext.RequestServices.GetService(typeof(ZaminServices));
    }
}

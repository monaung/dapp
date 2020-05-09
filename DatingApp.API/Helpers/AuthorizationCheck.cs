using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
namespace DatingApp.API.Helpers
{
    public class AuthorizationCheck : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = int.Parse(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var id = context.HttpContext.Request.RouteValues.Keys;
            var resultContext = await next();
            
        }
    }
}
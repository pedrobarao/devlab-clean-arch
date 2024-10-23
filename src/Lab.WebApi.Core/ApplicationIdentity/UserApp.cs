using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Lab.WebApi.Core.ApplicationIdentity;

public class UserApp : IUserApp
{
    private readonly IHttpContextAccessor _accessor;

    public UserApp(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => _accessor.HttpContext.User.Identity.Name;

    public Guid? GetUserId()
    {
        if (!IsAuthenticated()) return null;

        var userId = _accessor.HttpContext.User.GetUserId();

        if (string.IsNullOrEmpty(userId)) return null;

        return Guid.Parse(userId);
    }

    public string GetUserEmail()
    {
        if (!IsAuthenticated()) return string.Empty;

        return _accessor.HttpContext.User.GetUserEmail() ?? "";
    }

    public string GetUserToken()
    {
        return IsAuthenticated() ? _accessor.HttpContext.User.GetUserToken() : "";
    }

    public string GetUserRefreshToken()
    {
        return IsAuthenticated() ? _accessor.HttpContext.User.GetUserRefreshToken() : "";
    }

    public bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public bool IsInRole(string role)
    {
        return _accessor.HttpContext.User.IsInRole(role);
    }

    public IEnumerable<Claim> GetClaims()
    {
        return _accessor.HttpContext.User.Claims;
    }

    public HttpContext GetHttpContext()
    {
        return _accessor.HttpContext;
    }
}
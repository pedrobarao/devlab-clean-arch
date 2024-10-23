using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Lab.WebApi.Core.ApplicationIdentity;

public interface IUserApp
{
    string Name { get; }
    Guid? GetUserId();
    string GetUserEmail();
    string GetUserToken();
    string GetUserRefreshToken();
    bool IsAuthenticated();
    bool IsInRole(string role);
    IEnumerable<Claim> GetClaims();
    HttpContext GetHttpContext();
}
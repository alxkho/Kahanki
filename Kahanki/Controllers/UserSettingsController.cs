using System.Security.Claims;
using Kahanki.Data;
using Kahanki.Models;
using Kahanki.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kahanki.Controllers;

[Route("[controller]")]
public class UserSettingsController : GenericController<UserSettings>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserSettingsService _userSettingsService;


    public UserSettingsController(
        ApplicationDbContext db, 
        IHttpContextAccessor httpContextAccessor, 
        IUserSettingsService userSettingsService) : base(db)
    {
        _httpContextAccessor = httpContextAccessor;
        _userSettingsService = userSettingsService;
    }

    [HttpGet("GetCurrentUserSettings")]
    public UserSettings? GetCurrentUserSettings()
    {
        var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return _userSettingsService.GetUserSettingsByUserId(currentUserId);
    }

    [HttpGet("GetCurrentUserId")]
    public string GetCurrentUser()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
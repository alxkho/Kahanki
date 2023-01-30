using System.Security.Claims;
using Kahanki.Models;
using Kahanki.Services;
using Kahanki.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kahanki.Controllers;

[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChatController(
        IChatService chatService, 
        IHttpContextAccessor httpContextAccessor)
    {
        _chatService = chatService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("GetChatList")]
    public List<UserShortProfile> GetChatList()
    {
        var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return _chatService.GetChatListByUserId(currentUserId);
    }

    [HttpGet("GetChatByTargetUserId")]
    public Chat GetChatByTargetUserId(string targetUserId)
    {
        var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = _chatService.GetChat(currentUserId, targetUserId);

        result.Messages = result.Messages.OrderBy(c => c.Created).ToList();

        return result;
    }
}
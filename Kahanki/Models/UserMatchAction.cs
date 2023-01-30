using System.ComponentModel.DataAnnotations;

namespace Kahanki.Models;

public class UserMatchAction : BaseEntity
{
    public string ActedUserId { get; set; }

    public ApplicationUser ActedUser { get; set; }


    public string TargetUserId { get; set; }

    public ApplicationUser TargetUser { get; set; }


    public int ActionId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace RankList.Forms;

public class LoginForm
{
    [Required]
    public string? Username { get; set; }
}
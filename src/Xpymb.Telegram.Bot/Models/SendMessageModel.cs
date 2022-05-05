using System.ComponentModel.DataAnnotations;

namespace Xpymb.Telegram.Bot.Models;

public class SendMessageModel
{
    [Required] public string Text { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace SteamNews.FunctionApp;

public class Webhook
{
    [Key]
    public string WebhookUrl { get; set; }
}
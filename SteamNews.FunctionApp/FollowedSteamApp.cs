using System.ComponentModel.DataAnnotations;

namespace SteamNews.FunctionApp;

public class FollowedSteamApp
{
    [Key]
    public int AppId { get; set; }

    public string Webhook { get; set; }
}
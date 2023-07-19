using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using SteamDatabase;

namespace SteamNews.FunctionApp;

public class GetAndSendSteamNews
{
    private const string HARDCODED_WEBHOOK_URL = "https://discord.com/api/webhooks/1128491571294245055/aUJ892Ak3fjUdyUlI-gFp_Ell5VSQ2pe3l0krNiqtO0LB-RA60p_wdVK7gmbnil-ABPa";
    private readonly SteamNewsDatabaseContext _context;
    
    public GetAndSendSteamNews(SteamNewsDatabaseContext context)
    {
        _context = context;
    }

    [FunctionName("GetAndSendSteamNews")]
    public void Run([TimerTrigger("%TimerTriggerTime%", RunOnStartup = true)] TimerInfo myTimer)
    {
        var webhookClient = new Discord.Webhook.DiscordWebhookClient(HARDCODED_WEBHOOK_URL);
        
        DbSet<FollowedSteamApp> followedSteamApps = _context.FollowedSteamApps;
        
        foreach (FollowedSteamApp followedSteamApp in followedSteamApps) 
            webhookClient.SendMessageAsync(followedSteamApp.AppId.ToString());
    }
}
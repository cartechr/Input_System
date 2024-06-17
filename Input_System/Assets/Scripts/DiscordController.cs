using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;

public class DiscordController : MonoBehaviour
{
    private bool appQuitting;

    private bool activityEnabled;

    // Variables for ActivityAssets in "Core" script
    public string status_LargeImage;
    public string status_SmallImage;
    public string status_LargeText;
    public string status_SmallText;

    public string status_State;
    public string status_Details;

    // Singleton Instance
    public static DiscordController instance { get; private set; }

    public Discord.Discord discord;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Discord Controller in the game.");
            Destroy(gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        // Initialize Discord SDK
        this.discord = new Discord.Discord(34394049039430, (UInt64)Discord.CreateFlags.NoRequireDiscord);

        // Register the application quitting event
        Application.quitting += this.Application_Quitting;
    }

    private void OnDisable()
    {
        // Unregister the application quitting event
        Application.quitting -= this.Application_Quitting;

        // Dispose of Discord resources
        discord.Dispose();
    }

    private void Application_Quitting()
    {
        this.appQuitting = true;
    }

    private void Update()
    {
        try
        {
            // Keeps the SDK responsive
            this.discord.RunCallbacks();
        }
        catch
        {
            Destroy(this);
        }
    }

    private void UpdateStatus()
    {
        try
        {
            ActivityManager activityManager = this.discord.GetActivityManager();
            // Reference to Activity struct in "Core" script
            Activity activity = default(Activity);
            activity.Details = this.status_Details;
            activity.State = this.status_State;
            activity.Assets.LargeImage = this.status_LargeImage;
            activity.Assets.LargeText = this.status_LargeText;
            activity.Assets.SmallImage = this.status_SmallImage;
            activity.Assets.SmallText = this.status_SmallText;
        }
        catch
        {
            Destroy(this);
        }
    }
}

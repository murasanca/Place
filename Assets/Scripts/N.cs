// Murat Sancak

using System;
using Unity.Notifications.Android;
using UnityEngine;

namespace murasanca
{
    public class N : MonoBehaviour // N: Notification.
    {
        private static DateTime dT; // dT: Date Time.

        // Murat Sancak

        private void Awake()
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.RegisterNotificationChannel
            (
                new("P", "Place", "There's no place like Place.", Importance.High)
                {
                    CanBypassDnd = true,
                    CanShowBadge = true,
                    // Description="There's no place like Place.",
                    EnableLights = true,
                    EnableVibration = true,
                    // Id="P",
                    // Importance=Importance.High,
                    LockScreenVisibility = LockScreenVisibility.Public,
                    // Name="Place",
                    VibrationPattern = new long[8] { 0, 1, 2, 4, 8, 16, 32, 64 }
                }
            );
            _ = AndroidNotificationCenter.SendNotification
            (
                new("Place", "There's no place like Place.", dT = DateTime.Now.AddDays(1), new(864000000000), "s") // 864.000.000.000
                {
                    Color = new(1, .25f, 0),
                    CustomTimestamp = dT,
                    // FireTime=dT=DateTime.Now.AddDays(1),
                    Group = "Murat Sancak",
                    GroupAlertBehaviour = GroupAlertBehaviours.GroupAlertAll,
                    GroupSummary = true,
                    IntentData = "Place",
                    LargeIcon = "l",
                    Number = 1,
                    // RepeatInterval=new(864000000000), // 864.000.000.000
                    ShouldAutoCancel = false,
                    ShowTimestamp = false,
                    // SmallIcon="s",
                    SortKey = "Place",
                    Style = NotificationStyle.BigTextStyle,
                    // Text="There's no place like Place.",  
                    // Title="Place",
                    UsesStopwatch = false
                },
                "P"
            );

            AndroidNotificationCenter.SendNotificationWithExplicitID
            (
                new("Place", "Place has started.", dT = DateTime.Now.AddMinutes(10))
                {
                    Color = new(1, .25f, 0),
                    CustomTimestamp = dT,
                    // FireTime=dT=DateTime.Now.AddMinutes(10),
                    Group = "Murat Sancak",
                    GroupAlertBehaviour = GroupAlertBehaviours.GroupAlertAll,
                    GroupSummary = true,
                    IntentData = "Place",
                    LargeIcon = "l",
                    Number = 1,
                    RepeatInterval = null,
                    ShouldAutoCancel = false,
                    ShowTimestamp = false,
                    SmallIcon = "s",
                    SortKey = "Place",
                    Style = NotificationStyle.BigTextStyle,
                    // Text="Place has started.",
                    // Title="Place",
                    UsesStopwatch = false
                },
                "P",
                8
            );
        }

        // Murat Sancak

        public static void USN() // USN: Update Scheduled Notification.
        {
            if (0 < PP.T)
                AndroidNotificationCenter.UpdateScheduledNotification
                (
                    8
                    ,
                    new("Place", "Place has started.", dT = DateTime.Now.AddSeconds(PP.T))
                    {
                        Color = new(1, .25f, 0),
                        CustomTimestamp = dT,
                        // FireTime=dT=DateTime.Now.AddSeconds(PP.T),
                        Group = "Murat Sancak",
                        GroupAlertBehaviour = GroupAlertBehaviours.GroupAlertAll,
                        GroupSummary = true,
                        IntentData = "Place",
                        LargeIcon = "l",
                        Number = 1,
                        RepeatInterval = null,
                        ShouldAutoCancel = false,
                        ShowTimestamp = false,
                        SmallIcon = "s",
                        SortKey = "Place",
                        Style = NotificationStyle.BigTextStyle,
                        // Text=dT.ToString(),
                        // Title="Place",
                        UsesStopwatch = false
                    },
                    "P"
                );
            else
                AndroidNotificationCenter.UpdateScheduledNotification
                (
                    8
                    ,
                    new("Place", "Place has started.", dT = DateTime.Now.AddMinutes(10))
                    {
                        Color = new(1, .25f, 0),
                        CustomTimestamp = dT,
                        // FireTime=dT=DateTime.Now.AddMinutes(10),
                        Group = "Murat Sancak",
                        GroupAlertBehaviour = GroupAlertBehaviours.GroupAlertAll,
                        GroupSummary = true,
                        IntentData = "Place",
                        LargeIcon = "l",
                        Number = 1,
                        RepeatInterval = null,
                        ShouldAutoCancel = false,
                        ShowTimestamp = false,
                        SmallIcon = "s",
                        SortKey = "Place",
                        Style = NotificationStyle.BigTextStyle,
                        // Text="Place has started.",
                        // Title="Place",
                        UsesStopwatch = false
                    },
                    "P"
                );
        }
    }
}

// Murat Sancak
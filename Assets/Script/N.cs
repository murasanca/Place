// Murat Sancak

using Unity.Notifications.Android;

namespace murasanca
{
    /// <summary>
    /// Notification
    /// </summary>
    public class N:UnityEngine.MonoBehaviour
    {
        /// <summary>
        /// Date Time
        /// </summary>
        private static System.DateTime dT;

        // Murat Sancak

        private void Awake()
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.RegisterNotificationChannel
            (
                new("P","Place","There's no place like Place.",Importance.High)
                {
                    CanBypassDnd=true,
                    CanShowBadge=true,
                    // Description="There's no place like Place.",
                    EnableLights=true,
                    EnableVibration=true,
                    // Id="P",
                    // Importance=Unity.Notifications.Android.Importance.High,
                    LockScreenVisibility=LockScreenVisibility.Public,
                    // Name="Place",
                    VibrationPattern=new long[8]{0,1,2,4,8,16,32,64}
                }
            );
            _=AndroidNotificationCenter.SendNotification
            (
                new("Place","There's no place like Place.",dT=System.DateTime.Now.AddDays(1),new(864000000000),"s") // 864B
                {
                    Color=new(1,.25f,0),
                    CustomTimestamp=dT,
                    // FireTime=dT=System.DateTime.Now.AddDays(1),
                    Group="Murat Sancak",
                    GroupAlertBehaviour=GroupAlertBehaviours.GroupAlertAll,
                    GroupSummary=true,
                    IntentData="Place",
                    LargeIcon="l",
                    Number=1,
                    // RepeatInterval=new(864000000000), // 864B
                    ShouldAutoCancel=false,
                    ShowTimestamp=false,
                    // SmallIcon="s",
                    SortKey="Place",
                    Style=NotificationStyle.BigTextStyle,
                    // Text="There's no place like Place.",
                    // Title="Place",
                    UsesStopwatch=false
                },
                "P"
            );

            AndroidNotificationCenter.SendNotificationWithExplicitID
            (
                new("Place","Place has started.",dT=System.DateTime.Now.AddMinutes(10))
                {
                    Color=new(1,.25f,0),
                    CustomTimestamp=dT,
                    // FireTime=dT=System.DateTime.Now.AddMinutes(10),
                    Group="Murat Sancak",
                    GroupAlertBehaviour=GroupAlertBehaviours.GroupAlertAll,
                    GroupSummary=true,
                    IntentData="Place",
                    LargeIcon="l",
                    Number=1,
                    RepeatInterval=null,
                    ShouldAutoCancel=false,
                    ShowTimestamp=false,
                    SmallIcon="s",
                    SortKey="Place",
                    Style=NotificationStyle.BigTextStyle,
                    // Text="Place has started.",
                    // Title="Place",
                    UsesStopwatch=false
                },
                "P",
                8
            );
        }

        // Murat Sancak

        /// <summary>
        /// Update Scheduled Notification
        /// </summary>
        public static void USN()
        {
            if(0<PP.T)
                AndroidNotificationCenter.UpdateScheduledNotification
                (
                    8
                    ,
                    new("Place","Place has started.",dT=System.DateTime.Now.AddSeconds(PP.T))
                    {
                        Color=new(1,.25f,0),
                        CustomTimestamp=dT,
                        // FireTime=dT=System.DateTime.Now.AddSeconds(PP.T),
                        Group="Murat Sancak",
                        GroupAlertBehaviour=GroupAlertBehaviours.GroupAlertAll,
                        GroupSummary=true,
                        IntentData="Place",
                        LargeIcon="l",
                        Number=1,
                        RepeatInterval=null,
                        ShouldAutoCancel=false,
                        ShowTimestamp=false,
                        SmallIcon="s",
                        SortKey="Place",
                        Style=NotificationStyle.BigTextStyle,
                        // Text=dT.ToString(),
                        // Title="Place",
                        UsesStopwatch=false
                    },
                    "P"
                );
            else
                AndroidNotificationCenter.UpdateScheduledNotification
                (
                    8
                    ,
                    new("Place","Place has started.",dT=System.DateTime.Now.AddMinutes(10))
                    {
                        Color=new(1,.25f,0),
                        CustomTimestamp=dT,
                        // FireTime=dT=System.DateTime.Now.AddMinutes(10),
                        Group="Murat Sancak",
                        GroupAlertBehaviour=GroupAlertBehaviours.GroupAlertAll,
                        GroupSummary=true,
                        IntentData="Place",
                        LargeIcon="l",
                        Number=1,
                        RepeatInterval=null,
                        ShouldAutoCancel=false,
                        ShowTimestamp=false,
                        SmallIcon="s",
                        SortKey="Place",
                        Style=NotificationStyle.BigTextStyle,
                        // Text="Place has started.",
                        // Title="Place",
                        UsesStopwatch=false
                    },
                    "P"
                );
        }
    }
}

// Murat Sancak
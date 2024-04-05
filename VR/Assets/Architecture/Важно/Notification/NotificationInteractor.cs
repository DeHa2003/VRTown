using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class NotificationInteractor : Interactor
    {
        public Notification notificationPref { get; private set; }
        private NotificationControl notificationControl;

        private Notification spawnNotification;

        public void SetData(Notification notification, NotificationControl notificationControl)
        {
            this.notificationPref = notification;
            this.notificationControl = notificationControl;
        }

        public void CreateNotification(string hand, string description)
        {
            if (spawnNotification != null) 
            {
                DestroyNotification();
            }

            spawnNotification = notificationControl.SetNotificationPanel(notificationPref);
            spawnNotification.Initialize();
            spawnNotification.SetText(hand, description);
            spawnNotification.OpenPanel();
        }

        private void DestroyNotification()
        {
            spawnNotification.ClosePanel();
            spawnNotification = null;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationControl : MonoBehaviour
{
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Transform pos;

    private Notification notificationPanel;

    public Notification SetNotificationPanel(Notification notificationPanel)
    {
        this.notificationPanel = Instantiate(notificationPanel);
        this.notificationPanel.transform.SetParent(canvasTransform);
        this.notificationPanel.transform.position = pos.position;
        this.notificationPanel.transform.localScale = Vector3.one;
        this.notificationPanel.transform.rotation = canvasTransform.rotation;
        return this.notificationPanel;
    }
}

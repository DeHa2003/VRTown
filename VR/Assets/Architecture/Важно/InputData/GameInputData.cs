using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputData : MonoBehaviour
{
    [Header("Notification")]
    [SerializeField] protected NotificationControl notificationControl;
    [SerializeField] protected Notification notification;

    [Header("Audio")]
    [SerializeField] protected AudioManager audioManager;

    private NotificationInteractor notificationInteractor;
    private AudioInteractor audioInteractor;
    private SettingsInteractor settingsInteractor;

    public virtual void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();

        audioInteractor.SetData(audioManager, "Game");
        notificationInteractor.SetData(notification, notificationControl);
        settingsInteractor.SetData(audioManager);
    }
}

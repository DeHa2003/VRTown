using UnityEngine;
using DG.Tweening;

public class PlayerMenuControl : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Transform posMenu;

    [Header("Time to spawn/delete menu")]
    [SerializeField] private float time;

    private HandButtons handButtons;
    private PanelsControl menuPref;
    private PanelsControl currentMenu = null;
    private Tween tween;

    public void Initialize(HandButtons handButtons)
    {
        this.handButtons = handButtons;
    }

    private void CheckMenuPanel()
    {
        if(currentMenu != null)
        {
            DeleteMenuPanel();
        }
        else
        {
            InstantiateMenuPanel();
        }
    }

    public void InstantiateMenuPanel()
    {
        tween?.Kill();
        currentMenu = Instantiate(menuPref, posMenu.position, posMenu.rotation);
        currentMenu.Initialize();
        tween = currentMenu.transform.DOScale(0.01f, time);
    }

    public void DeleteMenuPanel()
    {
        tween?.Kill();
        currentMenu.transform.DOScale(0f, time).OnComplete(() => Destroy(currentMenu.gameObject));
    }

    public void ActivateMenuControl(PanelsControl menuPref)
    {
        this.menuPref = menuPref;
        handButtons.AddActionToRightHand(CheckMenuPanel);
    }

    public void DiactivateMenuControl()
    {
        handButtons.RemoveActionToRightHand(CheckMenuPanel);
    }
}

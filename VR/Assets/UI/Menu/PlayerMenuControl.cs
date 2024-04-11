using UnityEngine;
using DG.Tweening;

public class PlayerMenuControl : MonoBehaviour
{
    //[SerializeField] private PanelsControl menuPrefDefault;
    //[SerializeField] private PanelsControl menuPrefFailed;
    //[SerializeField] private PanelsControl menuPrefSuccess;
    [SerializeField] private Transform posMenu;
    [SerializeField] private float time;

    private HandButtons handButtons;
    private UIObject currentMenuPref;
    private UIObject currentMenu = null;
    //private TypeMenu typeMenu;
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
        currentMenu = Instantiate(currentMenuPref, posMenu.position, posMenu.rotation);
        currentMenu.Initialize();
        currentMenu.Activate();
    }

    public void DeleteMenuPanel()
    {
        currentMenu.Deactivate();
    }

    public void SetMenuPrefab(TypeMenu typeMenu)
    {

    }

    public void ActivateMenuControl()
    {
        handButtons.AddActionToRightHand(CheckMenuPanel);
    }

    public void DiactivateMenuControl()
    {
        handButtons.RemoveActionToRightHand(CheckMenuPanel);
    }
}

public enum TypeMenu
{
    Default, Failed, Successed 
}

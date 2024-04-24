using UnityEngine;
using DG.Tweening;

public class PlayerMenuControl : MonoBehaviour
{
    [SerializeField] private Menu menuPrefDefault;
    [SerializeField] private Menu menuPrefFailed;
    [SerializeField] private Menu menuPrefSuccess;
    [SerializeField] private Transform posMenu;

    private HandButtons handButtons;
    private Menu currentMenuPref;
    private Menu currentMenu = null;

    private MenuProperties menuProperties;
    private TypeMenu typeMenu;

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
        currentMenu = Instantiate(currentMenuPref, posMenu.position, posMenu.rotation);
        currentMenu.Initialize();
        currentMenu.SetData(menuProperties);
        currentMenu.Activate();
    }

    public void DeleteMenuPanel()
    {
        currentMenu.Deactivate();
    }

    public void SetMenuData(TypeMenu typeMenu, MenuProperties menuProperties = null)
    {
        this.menuProperties = menuProperties;
        this.typeMenu = typeMenu;

        switch(this.typeMenu)
        {
            case TypeMenu.Default:
                currentMenuPref = menuPrefDefault;
                break;

            case TypeMenu.Successed:
                currentMenuPref = menuPrefSuccess;
                break;

            case TypeMenu.Failed: 
                currentMenuPref = menuPrefFailed;
                break;
        }
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

public class MenuProperties
{
    public string description { get; private set; }

    public void SetData(string descroption = null)
    {
        this.description = descroption;
    }
}

using UnityEngine;
using DG.Tweening;

public class PlayerMenuControl : MonoBehaviour
{
    [SerializeField] private Menu menuPrefDefault;
    [SerializeField] private Menu menuPrefFailed;
    [SerializeField] private Menu menuPrefSuccess;
    [SerializeField] private Transform posMenu;

    //private HandButtons handButtons;
    private Menu currentMenuPref;
    private Menu currentMenu = null;

    private MenuProperties menuProperties;
    private TypeMenu typeMenu;

    public void Initialize()
    {
        //this.handButtons = handButtons;
    }

    public void CheckMenuPanel()
    {
        if(currentMenu != null)
        {
            DestroyMenu();
        }
        else
        {
            InstantiateMenu();
        }
    }

    public void InstantiateMenu()
    {
        if(currentMenu != null)
        {
            currentMenu.Deactivate();
            currentMenu = null;
        }
        currentMenu = Instantiate(currentMenuPref, posMenu.position, posMenu.rotation);
        currentMenu.Initialize();
        currentMenu.SetData(menuProperties);
        currentMenu.Activate();
    }

    public void DestroyMenu()
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

    //public void ActivateMenuControl()
    //{
    //    handButtons.AddActionToUpperButton_RightHand(CheckMenuPanel);
    //}

    //public void DiactivateMenuControl()
    //{
    //    handButtons.RemoveActionToUpperButton_RightHand(CheckMenuPanel);
    //}
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

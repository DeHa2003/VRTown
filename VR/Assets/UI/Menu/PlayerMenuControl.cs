using UnityEngine;
using DG.Tweening;

public class PlayerMenuControl : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Transform posMenu;

    [Header("Time to spawn/delete menu")]
    [SerializeField] private float time;

    private HandButtons handButtons;
    private GameObject menuPref;
    private GameObject currentMenu = null;
    private Tween tween;

    public void Initialize(HandButtons handButtons)
    {
        this.handButtons = handButtons;
    }

    //private void OnEnable()
    //{
    //    HandButtons.OnClickRightHandMenu += CheckMenuPanel;
    //}

    //private void OnDisable()
    //{
    //    HandButtons.OnClickRightHandMenu -= CheckMenuPanel;
    //}

    //public void ActivateDeactivate(bool isActive)
    //{
    //    if(isActive)
    //    {
    //        gameObject.GetComponent<MenuPanel>().enabled = true;
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<MenuPanel>().enabled = false;
    //    }
    //}

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
        tween = currentMenu.transform.DOScale(0.01f, time);
    }
    public void DeleteMenuPanel()
    {
        tween?.Kill();
        currentMenu.transform.DOScale(0f, time).OnComplete(() => Destroy(currentMenu));
    }

    public void ActivateMenuControl(GameObject menuPref)
    {
        this.menuPref = menuPref;
        handButtons.AddActionToRightHand(CheckMenuPanel);
    }

    public void DiactivateMenuControl()
    {
        handButtons.RemoveActionToRightHand(CheckMenuPanel);
    }
}

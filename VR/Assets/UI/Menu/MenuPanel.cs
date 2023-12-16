using UnityEngine;
using DG.Tweening;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPref;

    [Header("Positions")]
    [SerializeField] private Transform posMenu;

    [Header("Time to spawn/delete menu")]
    [SerializeField] private float time;

    private GameObject menu = null;
    private Tween tween;

    private void OnEnable()
    {
        HandButtons.OnClickRightHandMenu += CheckMenuPanel;
    }

    private void OnDisable()
    {
        HandButtons.OnClickRightHandMenu -= CheckMenuPanel;
    }

    public void ActivateDeactivate(bool isActive)
    {
        if(isActive)
        {
            gameObject.GetComponent<MenuPanel>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MenuPanel>().enabled = false;
        }
    }

    public void InstantiateMenuPanel()
    {
        if(tween != null) { tween.Kill(); }

        menu = Instantiate(menuPref, posMenu.position, posMenu.rotation);
        tween = menu.transform.DOScale(0.01f, time);
    }
    public void DeleteMenuPanel()
    {
        if (tween != null) { tween.Kill(); }

        menu.transform.DOScale(0f, time).OnComplete(() => Destroy(menu));
    }

    private void CheckMenuPanel()
    {
        if(menu != null)
        {
            DeleteMenuPanel();
        }
        else
        {
            InstantiateMenuPanel();
        }
    }
}

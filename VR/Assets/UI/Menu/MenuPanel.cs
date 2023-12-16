using UnityEngine;
using System;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPref;
    [SerializeField] private Transform posSpawn;

    private GameObject menu = null;
    private void OnEnable()
    {
        HandButtons.OnClickRightHandMenu += CheckMenuPanel;
    }

    private void OnDisable()
    {
        HandButtons.OnClickRightHandMenu -= CheckMenuPanel;
    }

    //private void InstantiateMenuPanel()
    //{
    //    menu = Instantiate(menuPref, posSpawn.position, posSpawn.rotation);
    //}

    //private void DeleteMenuPanel()
    //{
    //    Destroy(menu);
    //}

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
        AudioManager.instance.Play("OpenMenu");

        menu = Instantiate(menuPref, posSpawn.position, posSpawn.rotation);
        //    menu.transform.DOMove(posMenu.position, timeSpawn);
        //    menu.transform.DOScale(0.01f, timeSpawn);
        //}
    }
    public void DeleteMenuPanel()
    {
        AudioManager.instance.Play("CloseMenu");

        //menu.transform.DOScale(0f, timeSpawn);
        //menu.transform.
        //    DOMove(posDelete.position, timeSpawn).
        //    OnComplete(() => {
        //        Destroy(menu);
        //    });
        Destroy(menu);
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

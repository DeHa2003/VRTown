using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuPanel : Panel
{
    [SerializeField] private List<BoxCollider> buttonsColliders;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = true;
        }
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = false;
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);

        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        //while (!asyncOperation.isDone)
        //{
        //    yield return null;
        //}
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    //private void OnEnable()
    //{
    //    for (int i = 0; i < buttonsColliders.Count; i++)
    //    {
    //        buttonsColliders[i].enabled = true;
    //    }
    //}

    //private void OnDisable()
    //{
    //    for (int i = 0; i < buttonsColliders.Count; i++)
    //    {
    //        buttonsColliders[i].enabled = false;
    //    }
    //}
}

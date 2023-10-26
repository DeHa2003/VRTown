using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCarController : MonoBehaviour
{
    [SerializeField] List<SvetoforController> potok1;
    [SerializeField] List<GameObject> zebs1;
    [SerializeField] List<SvetoforController> potok2;
    [SerializeField] List<GameObject> zebs2;

    private void Start()
    {
        Play();
    }

    private void Play()
    {
        StartPotok(potok1);
        ActivateZebs(zebs1, true);
        StopPotok(potok2);
        ActivateZebs(zebs2, false);

        Invoke(nameof(Stop), 20);
    }

    private void Attention()
    {
        AttentionPotok(potok1);
        AttentionPotok(potok2);
        ActivateZebs(zebs1, true);
        ActivateZebs(zebs2, true);

        Invoke(nameof(Play), 2);
    }

    private void Stop()
    {
        StopPotok(potok1);
        ActivateZebs(zebs1, false);
        StartPotok(potok2);
        ActivateZebs(zebs2, true);

        Invoke(nameof(Attention), 20);
    }

    private void StartPotok(List<SvetoforController> potok)
    {
        for (int i = 0; i < potok.Count; i++) 
        {
            potok[i].StartMoveCars();
        }
    }

    private void AttentionPotok(List<SvetoforController> potok)
    {
        for (int i = 0; i < potok.Count; i++)
        {
            potok[i].Attention();
        }
    }

    private void StopPotok(List<SvetoforController> potok)
    {
        for (int i = 0; i < potok.Count; i++)
        {
            potok[i].StopMoveCars();
        }
    }

    private void ActivateZebs(List<GameObject> zebs, bool isActivate)
    {
        if (isActivate)
        {
            for (int i = 0; i < zebs.Count; i++) 
            {
                zebs[i].SetActive(true);
            }  
        }
        else
        {
            for (int i = 0; i < zebs.Count; i++)
            {
                zebs[i].SetActive(false);
            }
        }
    }


}

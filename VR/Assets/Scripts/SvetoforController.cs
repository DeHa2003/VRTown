using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvetoforController : MonoBehaviour
{
    [Header("0 - Red, 1 - Yellow, 2 - Green")]
    [SerializeField] private List<GameObject> colors;

    [SerializeField] GameObject zebra;
    
    public void StartMoveCars()
    {
        OffAllColors();
        colors[2].SetActive(true);
        StartCoroutine(ZebraActivate());
    }

    public void Attention()
    {
        OffAllColors();
        colors[1].SetActive(true);
    }

    public void StopMoveCars()
    {
        OffAllColors();
        colors[0].SetActive(true);
        zebra.SetActive(true);
    }

    private void OffAllColors()
    {
        for (int i = 0; i < colors.Count; i++)
        {
            colors[i].SetActive(false);
        }    
    }

    private IEnumerator ZebraActivate()
    {
        yield return new WaitForSeconds(Random.Range(0, 2));
        zebra.SetActive(false);
    }
}

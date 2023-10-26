using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeshehodGame : MonoBehaviour
{
    [SerializeField] private PlayerComponents playerComponents;

    [SerializeField] private GameObject plaingPanel;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    [SerializeField] private List<string> numberLevel;
    [SerializeField] private List<Sprite> imagesTown;

    [SerializeField] private List<BoxCollider> buttonsColliders;

    private int sceneNumber;

    private void OnEnable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = true;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = false;
        }
    }

    public void ViborGame(int level)
    {
        if(!plaingPanel.activeSelf)
            plaingPanel.SetActive(true);
        image.sprite = imagesTown[level-1];
        textMeshPro.text = numberLevel[level-1];
        sceneNumber = level;
    }

    public void OpenStartPanel(GameObject panel)
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
    }

    public void PlayGame()
    {
        if(sceneNumber != 0)
        {
            playerComponents.LoadScene(sceneNumber);
        }
    }
}

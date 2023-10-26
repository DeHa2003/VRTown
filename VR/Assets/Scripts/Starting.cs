using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(0);
    }
}

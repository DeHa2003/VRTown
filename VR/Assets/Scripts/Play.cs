using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    private Animator anim;
    private string[] strings = new string[] {"Play1", "Play2", "Play3"};
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool(strings[Random.Range(0, strings.Length)], true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.speed = 0;
        }
    }
}

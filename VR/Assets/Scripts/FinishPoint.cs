using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private GameObject LookAtJoint;
    [SerializeField] private Vector3 vectorRotate;
    [SerializeField] private Vector3 vectorTranslate;
    [SerializeField] private float speed;
    [SerializeField] private float timeTranslate;
    public float time;
    private bool isUp = true;
    private void Start()
    {
        material.SetColor("_TintColor", GetRandomColor());
        time = timeTranslate;
    }

    private void OnEnable()
    {
        PlayerTrigger.OnCompletedGame += CompletedLevel;
    }

    private void OnDisable()
    {
        PlayerTrigger.OnCompletedGame -= CompletedLevel;
    }

    private Color GetRandomColor()
    {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
    }

    private void Update()
    {
        LookAtJoint.transform.Rotate(vectorRotate * Time.deltaTime * speed);
        if (isUp)
            LookAtJoint.transform.Translate(vectorTranslate * Time.deltaTime);
        else
            LookAtJoint.transform.Translate(-vectorTranslate * Time.deltaTime);


        time -= Time.deltaTime;
        if (time <= -timeTranslate)
        {
            time = timeTranslate;
            isUp = !isUp;
        }
    }

    private void CompletedLevel()
    {
        Destroy(gameObject);
    }
}

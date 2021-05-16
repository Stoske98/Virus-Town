using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebdenje : MonoBehaviour
{
    [Range(0, 20)]
    public float frequncy = 1;
    public float speedFrequancy = 2;

    void Start()
    {
        Destroy(gameObject, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.up * (Mathf.Sin(Time.time * speedFrequancy) ) * (frequncy / 100);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int number;
    private Rigidbody rb;
    private bool hasStopped = false;
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStopped && rb.IsSleeping())
        {
            Debug.Log(number);
            hasStopped = true; // もう実行しないようにする
        }
    }
}

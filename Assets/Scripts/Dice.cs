using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int number;
    Dice_System DS;
    public GameObject Dice_System;
    private Rigidbody rb;
    private bool hasStopped = false;
    void Start()
    {
        Dice_System = GameObject.Find("Dice_System");
        rb = GetComponent<Rigidbody>();
        DS = Dice_System.GetComponent<Dice_System>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStopped && rb.IsSleeping())
        {
            //止まった瞬間に一度だけ実行される
            DS.dice = number;
            DS.diceTimes++;
            hasStopped = true; // もう実行しないようにする
        }
    }
}

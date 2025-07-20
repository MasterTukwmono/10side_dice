using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Suface: MonoBehaviour
{
    public int Side;
    public GameObject Dice;
    Dice diceComponent;


    void Start()
    {
        diceComponent = Dice.GetComponent<Dice>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        diceComponent.number = Side;
    }
}

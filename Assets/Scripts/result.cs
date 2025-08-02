using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    //public GameObject Dice_Systems;
    //public Role_jugiment RJ;
    void Start()
    {
        //RJ = gameObject.GetComponent<Role_jugiment>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Role_jugiment.Final_score = 0;
            Role_jugiment.DiceTimes_Time = 0;

            Role_jugiment.Confirmdfirst = "";
            Role_jugiment.ConfirmdSecond = "";
            Role_jugiment.ConfirmdThird = "";

            Role_jugiment.First = "";
            Role_jugiment.Second = "";
            Role_jugiment.Third = "";

            Role_jugiment.one = 0;
            Role_jugiment.two = 0;
            Role_jugiment.three = 0;

            SceneManager.LoadScene("Main");
        }
    }
}

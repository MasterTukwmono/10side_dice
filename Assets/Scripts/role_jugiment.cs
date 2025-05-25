using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class Role_jugiment : MonoBehaviour
{
    public GameObject role_system;
    private Dice_System dice_System;
    public Text roleText;
    public Text point;
    public Button diceButton;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        dice_System = gameObject.GetComponent<Dice_System>();
    }

    // Update is called once per frame
    void Update()
    {
        point.text=score.ToString();
    }

    public void dice_jugiment()
    {
        if(dice_System.dice == 1)
        {
                roleText.text = "ロイヤルホームセンター";
                Debug.Log("ロイヤルホームセンター");
                score = score +500;
        }
        else
        {
            roleText.text = "no";
            score = score + dice_System.dice;
        }
    }

    public void result()
    {
        SceneManager.LoadScene("Result");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;
using System.Linq;

public class Role_jugiment : MonoBehaviour
{
    public GameObject role_system;
    private Dice_System dice_System;
    public Text roleText;
    public Text point;
    public Button diceButton;
    public static int score = 0;
    public static string role;

    int a; int b; int c;
    void Start()
    {
      dice_System = gameObject.GetComponent<Dice_System>();
    }

    // Update is called once per frame
    void Update()
    {
        point.text = score.ToString();
    }

    int[] Prime = { 2, 3, 5, 7, 11 };
    int[] twoTimes = { 2, 4, 6, 8, 10, 12 };
    int[] threeTimes = { 3, 6, 9, 12 };
    int[] fiveTimes = { 5, 10 };
    public void dice_jugiment()
    {
        Debug.Log(a); Debug.Log(b); Debug.Log(c);
        Array.Sort(dice_System.Roles);
        int[] roles = dice_System.Roles;
        a = dice_System.Roles[0];
        b = dice_System.Roles[1];
        c = dice_System.Roles[2];

        if (a == 1 && b == 1 && c == 1)
        {
            roleText.text = "アルティメットストレートフラッシュ";
            Debug.Log("アルティメットストレートフラッシュ");
            score = score + 2500;
        }
        else
        if (a == b && b == c && Prime.Contains(a))
        {
            roleText.text = "プレミヤストレートフラッシュ";
            Debug.Log("プレミヤストレートフラッシュ");
            score = score + a * 300;
        }
        else
        if (a == b && b == c)
        {
            roleText.text = "ストレートフラッシュ";
            Debug.Log("ストレートフラッシュ");
            score = score + a * 100;
        }
        else
        if ((twoTimes.Contains(a) && a == b && twoTimes.Contains(c)) || (twoTimes.Contains(a) && a == c && twoTimes.Contains(b)) || (twoTimes.Contains(b) && b == c && twoTimes.Contains(a)) ||
            (fiveTimes.Contains(a) && a == b && fiveTimes.Contains(c)) || (fiveTimes.Contains(a) && a == c && fiveTimes.Contains(b)) || (fiveTimes.Contains(b) && b == c && fiveTimes.Contains(a)) ||
            (threeTimes.Contains(a) && a == b && threeTimes.Contains(c)) || (threeTimes.Contains(a) && a == c && threeTimes.Contains(b)) || (threeTimes.Contains(b) && b == c && threeTimes.Contains(a)))
        {
            roleText.text = "フルハウス";
            Debug.Log("フルハウス");
            score = score + roles[2] * 50;
        }
        else
        if (roles[2] == roles[1] + 1 && roles[1] == roles[0] + 1)
        {
            roleText.text = "ストレート";
            Debug.Log("ストレート");
            score = score + roles[2] * 25;
        }
        else
        if (Prime.Contains(a) && Prime.Contains(b) && Prime.Contains(c))
        {
            roleText.text = "プレミア";
            Debug.Log("ストレート");
            score = score + roles[2] * 15;
        }
        else
        if (a == b && b == c && a == c)
        {
            roleText.text = "ペア";
            Debug.Log("ペア");
            score = score + roles[2] * 10;
        }
        else
        {
            roleText.text = "チョンボ";
            Debug.Log("チョンボ");
            score = score + roles[2];
        }


    }

    public void result()
    {
        SceneManager.LoadScene("Result");
    }
}

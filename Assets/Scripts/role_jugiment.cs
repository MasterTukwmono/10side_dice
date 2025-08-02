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
    public string roleText;
    public Text point;
    public Button diceButton;
    public static int score = 0;
    public static int DiceTimes_Time = 0;
    public static string Confirmdfirst = "";
    public static string ConfirmdSecond = "";
    public static string ConfirmdThird = "";

    int a; int b; int c;
    public static string First;
    public Text First_Role;
    public static string Second;
    public Text Second_Role;
    public static string Third;
    public Text Third_Role;
    void Start()
    {
        dice_System = gameObject.GetComponent<Dice_System>();
    }

    void Update()
    {
        point.text = score.ToString();
        if (DiceTimes_Time == 1)
        {

            if (!string.IsNullOrEmpty(Confirmdfirst))
            {
                First = Confirmdfirst;
            }
            else if (string.IsNullOrEmpty(roleText))
            {
                First = "ダイスを振れ！";
            }
            else
            {
                First = roleText;
                Confirmdfirst = roleText;
            }
            First_Role.text = First;

        }

        if (DiceTimes_Time == 2)
        {
            if (!string.IsNullOrEmpty(ConfirmdSecond))
            {
                Second = ConfirmdSecond;
            }
            else if (string.IsNullOrEmpty(roleText))
            {
                Second = "ダイスを振れ！";
            }
            else
            {
                Second = roleText;
                ConfirmdSecond = roleText;
            }

            First = !string.IsNullOrEmpty(Confirmdfirst) ? Confirmdfirst : "ダイスを振れ！";

            First_Role.text = First;
            Second_Role.text = Second;
        }

        if (DiceTimes_Time == 3)
        {
            if (!string.IsNullOrEmpty(ConfirmdThird))
            {
                Third = ConfirmdThird;
            }
            else if (string.IsNullOrEmpty(roleText))
            {
                Third = "ダイスを振れ！";
            }
            else
            {
                Third = roleText;
                ConfirmdThird = roleText;
            }

            First = !string.IsNullOrEmpty(Confirmdfirst) ? Confirmdfirst : "ダイスを振れ！";
            Second = !string.IsNullOrEmpty(ConfirmdSecond) ? ConfirmdSecond : "ダイスを振れ！";

            First_Role.text = First;
            Second_Role.text = Second;
            Third_Role.text = Third;
        }
    }

    int[] Prime = { 2, 3, 5, 7, 11 };
    int[] twoTimes = { 2, 4, 6, 8, 10, 12 };
    int[] threeTimes = { 3, 6, 9, 12 };
    int[] fiveTimes = { 5, 10 };
    public void dice_jugiment()
    {
        Debug.Log(dice_System.Roles[0]); Debug.Log(dice_System.Roles[1]); Debug.Log(dice_System.Roles[2]);
        Array.Sort(dice_System.Roles);
        int[] roles = dice_System.Roles;
        a = dice_System.Roles[0];
        b = dice_System.Roles[1];
        c = dice_System.Roles[2];

        if (a == 1 && b == 1 && c == 1)
        {
            roleText = "アルティメットストレートフラッシュ";
            Debug.Log("アルティメットストレートフラッシュ");
            score = score + 2500;
        }
        else
        if (a == b && b == c && Prime.Contains(a))
        {
            roleText = "プレミヤストレートフラッシュ";
            Debug.Log("プレミヤストレートフラッシュ");
            score = score + a * 300;
        }
        else
        if (a == b && b == c)
        {
            roleText = "ストレートフラッシュ";
            Debug.Log("ストレートフラッシュ");
            score = score + a * 100;
        }
        else
        if ((twoTimes.Contains(a) && a == b && twoTimes.Contains(c)) || (twoTimes.Contains(a) && a == c && twoTimes.Contains(b)) || (twoTimes.Contains(b) && b == c && twoTimes.Contains(a)) ||
            (fiveTimes.Contains(a) && a == b && fiveTimes.Contains(c)) || (fiveTimes.Contains(a) && a == c && fiveTimes.Contains(b)) || (fiveTimes.Contains(b) && b == c && fiveTimes.Contains(a)) ||
            (threeTimes.Contains(a) && a == b && threeTimes.Contains(c)) || (threeTimes.Contains(a) && a == c && threeTimes.Contains(b)) || (threeTimes.Contains(b) && b == c && threeTimes.Contains(a)))
        {
            roleText = "フルハウス";
            Debug.Log("フルハウス");
            score = score + roles[2] * 50;
        }
        else
        if (roles[2] == roles[1] + 1 && roles[1] == roles[0] + 1)
        {
            roleText = "ストレート";
            Debug.Log("ストレート");
            score = score + roles[2] * 25;
        }
        else
        if (Prime.Contains(a) && Prime.Contains(b) && Prime.Contains(c))
        {
            roleText = "プレミア";
            Debug.Log("プレミア");
            score = score + roles[2] * 15;
        }
        else
        if (a == b || b == c || a == c)
        {
            roleText = "ペア";
            Debug.Log("ペア");
            score = score + roles[2] * 10;
        }
        else
        {
            roleText = "チョンボ";
            Debug.Log("チョンボ");
            score = score + roles[2];
        }

        if (DiceTimes_Time == 0)
        {
            First = roleText;
            Confirmdfirst = roleText;
            First_Role.text = First;
        }
        else if (DiceTimes_Time == 1)
        {
            Second = roleText;
            ConfirmdSecond = roleText;
            Second_Role.text = Second;
        }
        else if (DiceTimes_Time == 2)
        {
            Third = roleText;
            ConfirmdThird = roleText;
            Third_Role.text = Third;
        }

    }

    public void result()
    {
        DiceTimes_Time++;
        StartCoroutine(Go_Next(3f));
    }

    IEnumerator Go_Next(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (DiceTimes_Time == 3)
        {
            SceneManager.LoadScene("Result");
        }
        else
        {
            
            SceneManager.LoadScene("Main");
        }

    }
}

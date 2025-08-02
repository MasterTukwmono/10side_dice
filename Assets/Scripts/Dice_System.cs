using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice_System : MonoBehaviour
{
    public int dice = 0;
    public int diceTimes = 0;
    public int[] Roles = new int[3];
    public GameObject dices;
    public Button dice_Button;
    private Role_jugiment role_Jugiment;
    // Start is called before the first frame update
    void Start()
    {
        role_Jugiment = gameObject.GetComponent<Role_jugiment>();
    }

    private bool hasStopped1 = false;   
    private bool hasStopped2 = false;   
    private bool hasStopped3 = false;

    void Update()
    {
        if (diceTimes == 1 && !hasStopped1)
        {
            Roles[0] = dice;
            //Debug.Log(Roles[0]);
            hasStopped1 = true;
        }

        if (diceTimes == 2 && !hasStopped2)
        {
            Roles[1] = dice;
            //Debug.Log(Roles[1]);
            hasStopped2 = true;
        }

        if (diceTimes == 3 && !hasStopped3)
        {
            Roles[2] = dice;
            role_Jugiment.dice_jugiment();
            role_Jugiment.result();
            //Debug.Log(Roles[2]);
            hasStopped3 = true;
        }

        if (push == 3)
        {
            Destroy(dice_Button);
        }
        
    }

    public int push = 0;

    public void Dice()
    {
        push++;
        // ランダムな位置
        Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(6.0f, 16.0f), Random.Range(-5.0f, 10.0f));

        // ランダムな回転角度
        Quaternion randomRotation = Random.rotation;

        // サイコロを生成
        GameObject diceObject = Instantiate(dices, spawnPosition, randomRotation);

        // Rigidbody に初速と回転力を加える
        Rigidbody rb = diceObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 上向き＋ランダム方向に力を加える
            Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)).normalized;
            float forceMagnitude = Random.Range(5f, 10f);
            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

            // ランダムなトルク（回転力）
            Vector3 torque = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            rb.AddTorque(torque, ForceMode.Impulse);

        }

        //過去の遺物たち  
        //diceTimes ++;
        //dice = Random.Range(1,13);
        //diceroleText.text = dice.ToString();
        //role_Jugiment.dice_jugiment();
    }
}

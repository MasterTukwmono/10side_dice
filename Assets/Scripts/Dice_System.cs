using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice_System : MonoBehaviour
{
    public int dice = 0;
    public int diceTimes = 0;
    public Text diceroleText;
    public GameObject role_system;
    public GameObject dices;
    private Role_jugiment role_Jugiment;
    // Start is called before the first frame update
    void Start()
    {
        role_Jugiment = gameObject.GetComponent<Role_jugiment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(diceTimes == 3)
        {
            role_Jugiment.result();
        }
        
    }

    public void Dice()
    {
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

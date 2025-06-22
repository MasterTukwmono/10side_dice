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
        //for (int i = 0; i < 3; i++)
        {
        transform.position = new Vector3(Random.Range(-10.0f,10.0f) , Random.Range(6.0f,16.0f) , Random.Range(-5.0f,10.0f));
        Instantiate(dices,transform.position,transform.rotation);
        }

        diceTimes ++;
        dice = Random.Range(1,12);
        diceroleText.text = dice.ToString();
        role_Jugiment.dice_jugiment();
    }
}

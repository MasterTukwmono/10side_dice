using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rule : MonoBehaviour
{
    public GameObject backgroundImage;
    public GameObject text1;
    public GameObject text2;
    public GameObject showButton;

    public int state = 0;

    void Start()
    {
        // 最初は全部非表示（ボタン以外）
        backgroundImage.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
    }

    public void OnShowButtonClicked()
    {
        backgroundImage.SetActive(true);
        text1.SetActive(true);
        text2.SetActive(false);
        showButton.SetActive(false); // ボタンを非表示に
        state = 1;
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space))
    {
            Debug.Log("あああ");
        if (state == 1)
            {
                text1.SetActive(false);
                text2.SetActive(true);
                state = 2;
            }
            else if (state == 2)
            {
                text2.SetActive(false);
                backgroundImage.SetActive(false);
                showButton.SetActive(true);
                state = 0;
            }
    }

    }
}


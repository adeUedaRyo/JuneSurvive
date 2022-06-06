using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int killCount = 0;
    TextMeshProUGUI killText;
    TextMeshProUGUI timerText;
    [SerializeField] string kCText = "KILL";
    float timer = 0;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        killText = GameObject.Find("Kill Count Text").GetComponent<TextMeshProUGUI>();
        killText.text = kCText + " : " + killCount.ToString("D4");
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timerText.text = (timer / 60).ToString("00")+":" +(timer% 60).ToString("00") ;
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            timer = Time.time;
            timerText.text = Mathf.Floor(timer / 60).ToString("00") +":"+ Mathf.Floor(timer % 60).ToString("00");
        }
    }
    public void Kill()//�G���j��
    {
        killCount++;
        killText.text = kCText + ":" + killCount.ToString("D4");//���݂̌��j����\��
    }
    public void Gameover()//�v���C���[�̎��S��
    {
        Debug.Log(" GAME OVER ");
    }
}

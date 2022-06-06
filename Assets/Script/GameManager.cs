using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int killCount = 0;
    TextMeshProUGUI killText;
    [SerializeField] string kCText = "KILL";
    // Start is called before the first frame update
    void Start()
    {
        killText = GameObject.Find("Kill Count Text").GetComponent<TextMeshProUGUI>();
        killText.text = kCText + " : " + killCount.ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Kill()
    {
        killCount++;
        killText.text = kCText + " : " + killCount.ToString("D4");
    }
    public void Gameover()
    {
        Debug.Log(" GAME OVER ");
    }
}

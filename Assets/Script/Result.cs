using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result : MonoBehaviour
{
    TextMeshProUGUI result;
    // Start is called before the first frame update
    void Start()
    {
        result = GameObject.Find("Result Time").GetComponent<TextMeshProUGUI>();
        result.text = (GameManager.timer / 60).ToString("00") + ":" + (GameManager.timer % 60).ToString("00");
    }
}

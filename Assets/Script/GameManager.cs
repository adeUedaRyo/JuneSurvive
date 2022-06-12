using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int _killCount = 0;
    TextMeshProUGUI _killText;
    TextMeshProUGUI _timerText;
    [SerializeField] string _kCText = "KILL";
    public static float timer = 0;
    public bool alive = true;
    [SerializeField]GameObject _gameOver;
    [SerializeField] Slider _expSlider;
    float _exp = 0;
    int level = 1;
    float nextLevelEXP = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        _killText = GameObject.Find("Kill Count Text").GetComponent<TextMeshProUGUI>();
        _killText.text = _kCText + " : " + _killCount.ToString("D4");
        _timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        _timerText.text = (timer / 60).ToString("00")+":" +(timer% 60).ToString("00") ;
        _expSlider.value = _exp;
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)//¶‚«‚Ä‚¢‚é‚Æ‚«ŽžŠÔ‚ð‰ÁŽZ‚µ‚Äƒ^ƒCƒ}[‚ðXV
        {
            timer += Time.deltaTime;
            _timerText.text = Mathf.Floor(timer / 60).ToString("00") +":"+ Mathf.Floor(timer % 60).ToString("00");
        }
    }
    public void Kill()//“GŒ‚”jŽž
    {
        _killCount++;
        _killText.text = _kCText + " : " + _killCount.ToString("D4");//Œ»Ý‚ÌŒ‚”j”‚ð•\Ž¦
    }
    public void GameOver()//ƒvƒŒƒCƒ„[‚ÌŽ€–SŽž
    {
        Debug.Log(" GAME OVER ");
        _gameOver.SetActive(true);
    }
    public void GameOverSceneChange()
    {
        SceneManager.LoadScene("Result");
    }
    public void GetEXP(int exp)
    {
        _exp += exp;
        if(_exp >= nextLevelEXP)
        {
            level++;
            _exp = 0;
        }
        _expSlider.value = _exp / nextLevelEXP;
    }
}

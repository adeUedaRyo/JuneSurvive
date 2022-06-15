using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }

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
    LevelUpSkill _levelUpSkill;
    List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] GameObject swordBitPrefab =null;
    GameObject player= null;
    float attractZone = 1;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        _killText = GameObject.Find("Kill Count Text").GetComponent<TextMeshProUGUI>();
        _killText.text = _kCText + " : " + _killCount.ToString("D4");
        _timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        _timerText.text = (timer / 60).ToString("00")+":" +(timer% 60).ToString("00") ;
        _expSlider.value = _exp;
        _levelUpSkill = GameObject.FindObjectOfType<LevelUpSkill>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)//生きているとき時間を加算してタイマーを更新
        {
            timer += Time.deltaTime;
            _timerText.text = Mathf.Floor(timer / 60).ToString("00") +":"+ Mathf.Floor(timer % 60).ToString("00");
        }
    }
    public void Kill()//敵撃破時
    {
        _killCount++;
        _killText.text = _kCText + " : " + _killCount.ToString("D4");//現在の撃破数を表示
    }
    public void GameOver()//プレイヤーの死亡時
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
            _exp -= nextLevelEXP;
            _levelUpSkill.Select();
            Time.timeScale = 0;
        }
        _expSlider.value = _exp / nextLevelEXP;
    }
    public void Setup()
    {
        //ObjectPoolに依存している
        _enemies = GameObject.FindObjectsOfType<Enemy>(true).ToList();
    }
    static public List<Enemy> EnemyList => _instance._enemies;

    public void LevelUpSwordBit()
    {
        GameObject swordBit = GameObject.FindGameObjectWithTag("Swordbit");
        if (swordBit == null)
        {
            Instantiate(swordBitPrefab);
        }
        else
        {
            swordBit.GetComponent<SwordBit>().WeaponLevelUp();
        }
    }
    public void LevelUpRifle()
    {
        GameObject rifle = GameObject.Find("Rifle");
        rifle.GetComponent<Shot>().WeaponLevelUp();
    }
    public void LevelUpRegenerate()
    {
        player.GetComponent<Player>().RegenerateUp();
    }
    public void LevelUpMaxHP()
    {
        player.GetComponent<Player>().MaxHPUP(20);
    }
    public void LevelUpAttract()
    {
        attractZone += 0.8f;
        GameObject.Find("AttractZone").transform.localScale = new Vector2(attractZone,attractZone); 
    }
}

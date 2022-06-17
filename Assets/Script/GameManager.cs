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
    TextMeshProUGUI _killText = null;
    TextMeshProUGUI _timerText = null;
    TextMeshProUGUI _enemyCountText = null;
    TextMeshProUGUI _levelText = null;
    [SerializeField] string _kCText = null;
    public static float timer = 0;
    public bool alive = true;
    [SerializeField]GameObject _gameOver;
    [SerializeField] Slider _expSlider;
    float _exp = 0;
    int level = 1;
    float nextLevelEXP = 5;
    LevelUpSkill _levelUpSkill;
    List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] GameObject swordBitPrefab =null;
    [SerializeField] GameObject boomerangLauncherPrefab = null;
    [SerializeField] GameObject missileLauncherPrefab = null;
    GameObject player= null;
    float attractZone = 1;
    public int _enemyCount = 0;
    int regeneLev,mhpLev,attraLev = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        _killText = GameObject.Find("Kill Count Text").GetComponent<TextMeshProUGUI>();
        _killText.text = _kCText + ":" + _killCount.ToString("D4");
        _timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        _timerText.text = (timer / 60).ToString("00")+":" +(timer% 60).ToString("00");
        _enemyCountText = GameObject.Find("EnemyCount Text").GetComponent<TextMeshProUGUI>();
        _levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        _expSlider.value = _exp;
        _levelUpSkill = GameObject.FindObjectOfType<LevelUpSkill>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)//�����Ă���Ƃ����Ԃ����Z���ă^�C�}�[���X�V
        {
            timer += Time.deltaTime;
            _timerText.text = Mathf.Floor(timer / 60).ToString("00") +":"+ Mathf.Floor(timer % 60).ToString("00");
        }
        _levelText.text = "Level " + level.ToString();
        _enemyCountText.text = "�G���m��:"+_enemyCount.ToString("D3");
    }
    public void Kill()//�G���j��
    {
        _killCount++;
        _killText.text = _kCText + ":" + _killCount.ToString("D4");//���݂̌��j����\��
    }
    public void GameOver()//�v���C���[�̎��S��
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
            Time.timeScale = 0;
            _levelUpSkill.Select();
            nextLevelEXP = 2+level/5 + level*(level/5 +3);
        }
        _expSlider.value = _exp / nextLevelEXP;
    }
    public void Setup()
    {
        //ObjectPool�Ɉˑ����Ă���
        _enemies = GameObject.FindObjectsOfType<Enemy>(true).ToList();
    }
    static public List<Enemy> EnemyList => _instance._enemies;

    //����̃��x���A�b�v
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
    public void LevelUpBoomerang()
    {
        GameObject boomerangL = GameObject.FindGameObjectWithTag("BoomerangLauncher");
        if(boomerangL==null)
        {
            Instantiate(boomerangLauncherPrefab);
        }
        else
        {
            boomerangL.GetComponent<BoomerangLauncher>().WeaponLevelUp();
        }
    }
    public void LevelUpRifle()
    {
        GameObject rifle = GameObject.Find("Rifle");
        rifle.GetComponent<Shot>().WeaponLevelUp();
    }
    public void LevelUpMissile()
    {
        GameObject missileL = GameObject.FindGameObjectWithTag("MissileLauncher");
        if (missileL == null)
        {
            Instantiate(missileLauncherPrefab);
        }
        else
        {
            missileL.GetComponent<MissileLauncher>().WeaponLevelUp();
        }
    }
    //�X�L���̃��x���A�b�v
    public void LevelUpRegenerate()
    {
        player.GetComponent<Player>().RegenerateUp();
        regeneLev++;
        if (regeneLev >= 5) _levelUpSkill.LevelMax("RegenerateButton");
    }
    public void LevelUpMaxHP()
    {
        player.GetComponent<Player>().MaxHPUP(20);
        mhpLev++;
        if (mhpLev >= 5) _levelUpSkill.LevelMax("MaxHPUpButton");
    }
    public void LevelUpAttract()
    {
        attractZone += 0.8f;
        GameObject.Find("AttractZone").transform.localScale = new Vector2(attractZone,attractZone);
        attraLev++;
        if (mhpLev >= 5) _levelUpSkill.LevelMax("AttractZoneButton");
    }

    public void Chicken()
    {
        player.GetComponent<Player>().HPUP(30);
    }
}

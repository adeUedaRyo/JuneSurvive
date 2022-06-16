using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    GameObject player = null;
    [SerializeField] GameObject missilePrefab = null;
    [SerializeField] float _coolTime = 6;
    [SerializeField] int _rapidFire = 20;//˜AŽË‘¬“x
    [SerializeField] int weaponLevel = 1;
    [SerializeField] Transform[] barrel = null;
    float _timer = 0;
    int _shotCount = 0;//Œ‚‚Á‚½‰ñ”
    bool _canShot = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        if (_timer >= _coolTime && _canShot == false) _canShot = true;
        if (_canShot == true && _timer > 0.05)
        {
            for(int i = 0; i< 10;i++ )
            {
                _shotCount++;
                Instantiate(missilePrefab,barrel[i%10].position, transform.rotation);
            }
            _timer = 0;
            if (_shotCount >= _rapidFire)//˜AŽË”‚ªãŒÀ‚É‚È‚Á‚½‚çŽ~‚ß‚é
            {
                _canShot = false;
                _shotCount = 0;
            }
        }
        _timer += Time.deltaTime;
    }
    public void WeaponLevelUp()
    {
        weaponLevel++;
        AttackUp();
    }
    void AttackUp()
    {
        switch (weaponLevel)
        {
            case >= 7:
                _rapidFire = 200;
                _coolTime = 1.5f;
                GameObject.Find("SkillCanvas").GetComponent<LevelUpSkill>().LevelMax("MissileButton");
                break;
            case >= 6:
                _rapidFire = 150;
                break;
            case >= 5:
                _rapidFire = 100;
                _coolTime = 2;
                break;
            case >= 4:
                _rapidFire = 70;
                break;
            case >= 3:
                _coolTime = 2.5f;
                _rapidFire = 50;
                break;
            case >= 2:
                _rapidFire = 30;
                break;
        }
    }
}

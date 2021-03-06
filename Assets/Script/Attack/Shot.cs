using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    GameObject player = null;
    [SerializeField] Transform[] muzzle = null;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] float coolTime = 2;
    [SerializeField] int rapidFire = 1;//連射可能な回数
    [SerializeField] float rFSpeed = 0.3f;//連射速度
    [SerializeField] int activeMuzzel = 1;
    [SerializeField] int weaponLevel = 1;
    int shotCount = 0;//撃った回数
    float timer = 0;
    bool canShot = false;
    float _bSpeed = 3;
    int _bPower = 5;
    int _bPenet = 1;

    [SerializeField] bool ultra = false;//デバッグ用
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ultra == true)//最強状態になる
        {
            weaponLevel = 7;
            AttackUp();
            ultra = false;
        }

        if (player == null) return;

        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        if (player.transform.localScale.x >0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
        timer += Time.deltaTime;
        if (timer >= coolTime && canShot == false) canShot = true;

        if(canShot ==true && timer > rFSpeed)
        {
            shotCount ++;
            timer = 0;
            for(int i =0;i < activeMuzzel;i++)
            {
                GameObject shotBullet = Instantiate(bulletPrefab,muzzle[i].position,muzzle[i].rotation);
                shotBullet.GetComponent<Bullet>().PowerUp(_bSpeed,_bPower,_bPenet);
            }
            if (shotCount >= rapidFire)//連射数が上限になったら止める
            {
                canShot = false;
                shotCount = 0;
            }
        }
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
                rapidFire = 4;
                coolTime = 0.5f;
                activeMuzzel = 4;
                _bPenet = 5;
                _bPower = 10;
                _bSpeed = 6;
                GameObject.Find("SkillCanvas").GetComponent<LevelUpSkill>().LevelMax("RifleButton");
                break;
            case >= 6:
                activeMuzzel = 4;
                _bPenet = 5;
                _bPower = 10;
                _bSpeed = 6;
                break;
            case >= 5:
                rapidFire = 3;
                coolTime = 0.75f;
                _bPower = 7;
                break;
            case >= 4:
                activeMuzzel = 3;
                _bSpeed = 4.5f;
                _bPenet = 3;
                break;
            case >= 3:
                rapidFire = 2;
                coolTime = 1;
                break;
            case >= 2:
                activeMuzzel = 2;
                break;
        }
    }
}

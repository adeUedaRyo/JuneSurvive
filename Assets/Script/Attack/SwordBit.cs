using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBit : MonoBehaviour
{
    [SerializeField] float _speed = 1;//回転速度
    [SerializeField] GameObject[] bit;
    [SerializeField] GameObject[] brade;
    [SerializeField] float coolTime = 3;
    [SerializeField] float activeTime =5;
    [SerializeField]int weaponLevel = 1;
    float time = 0;
    bool active = true;
    GameObject player = null;
    int _activeBit = 2;
    int _power = 3;
    float _size = 1;
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
        
        time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, _speed * -360 * Time.deltaTime));
        
        if(time> coolTime && active == false)
        {
            active = true;
            time = 0;
        }
        if(time >activeTime && active ==true)
        {
            active = false;
            time = 0;
        }

        if(active == true)//オンオフ切り替えと本数を設定
        {
            
            for (int i = 0; i < _activeBit; i++)
            {
                bit[i].SetActive(true);
            }
        }
        else
        {
            for(int i = 0; i<bit.Length;i++)
            {
                bit[i].SetActive(false);
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
        switch (weaponLevel) {
            case >= 7:
                _size = 1.3f;
                _power = 7;
                break;
            case >= 6:
                _activeBit = 6;
                break;
            case >= 5:
                _speed = 1.5f;
                _power = 5;
                break;
            case >= 4:
                _activeBit = 4;
                break;
            case >= 3:
                _speed = 1.25f;
                _power = 4;
                break;
            case >= 2:
                _size = 1.3f;
                break;
        }

        for (int i = 0; i < bit.Length; i++)
        {
            bit[i].GetComponent<Transform>().localScale = new Vector2(bit[i].transform.localScale.x * _size, bit[i].transform.localScale.y * _size);
        }
        _size = 1;//レベルアップのたびに巨大化するのを防ぐ
        
        for (int i = 0; i < brade.Length; i++)
        {
            brade[i].GetComponent<Blade>().PowerUp(_power);
        }
    }
}

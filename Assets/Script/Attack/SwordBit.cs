using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBit : MonoBehaviour
{
    [SerializeField] float _speed = 1;//回転速度
    [SerializeField] GameObject[] bit;
    [SerializeField] float coolTime = 3;
    [SerializeField] float activeTime =5;
    [SerializeField]int weaponLevel = 1;
    float time = 0;
    bool active = true;
    GameObject player = null;
    int activeBit = 2;

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

        if(active == true)//オンオフ切り替え
        {
            if(weaponLevel >=6)
            {
                activeBit = 6;
            }
            else if(weaponLevel>=4)
            {
                activeBit = 4;
            }
            else
            {
                activeBit = 2;
            }
            for (int i = 0; i < activeBit; i++)
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
    }
}

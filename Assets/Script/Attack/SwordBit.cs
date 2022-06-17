using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBit : MonoBehaviour
{
    [SerializeField] float _speed = 1;//��]���x
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

    [SerializeField]bool ultra= false;//�f�o�b�O�p

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (ultra ==true)//�ŋ���ԂɂȂ�
        {
            weaponLevel = 7;
            AttackUp();
            ultra = false;
        }
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

        if(active == true)//�I���I�t�؂�ւ��Ɩ{����ݒ�
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
                _activeBit = 6;
                coolTime = 3;
                activeTime = 4;
                _size = 1.3f;
                _power = 5;
                _speed = 1.25f;
                GameObject.Find("SkillCanvas").GetComponent<LevelUpSkill>().LevelMax("SwordBitButton");
                break;
            case >= 6:
                _activeBit = 6;
                _size = 1.3f;
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
        _size = 1;//���x���A�b�v�̂��тɋ��剻����̂�h��
        
        for (int i = 0; i < brade.Length; i++)
        {
            brade[i].GetComponent<Blade>().PowerUp(_power);
        }
    }
}

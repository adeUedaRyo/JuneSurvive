using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangLauncher : MonoBehaviour
{
    GameObject player = null;
    [SerializeField] GameObject _boomerangPrefab = null;
    [SerializeField] float _coolTime = 2;
    [SerializeField] int _rapidFire = 1;//˜AŽË‘¬“x
    [SerializeField] int weaponLevel = 1;
    int _shotCount = 0;//Œ‚‚Á‚½‰ñ”
    float _timer = 0;
    bool _canShot = false;
    int _bPower = 10;

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

        _timer += Time.deltaTime;
        if (_timer >= _coolTime && _canShot == false) _canShot = true;
        if (_canShot == true && _timer > 0.3)
        {
            _shotCount++;
            _timer = 0;
            GameObject boome = Instantiate(_boomerangPrefab, transform.position, transform.rotation);
            boome.GetComponent<Boomerang>().PowerUp(_bPower);
            boome.transform.localScale = new Vector2(_size, _size);
            if (_shotCount >= _rapidFire)//˜AŽË”‚ªãŒÀ‚É‚È‚Á‚½‚çŽ~‚ß‚é
            {
                _canShot = false;
                _shotCount = 0;
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
                _rapidFire = 5;
                _size = 2;
                break;
            case >= 6:
                _rapidFire = 4;
                _bPower = 20;
                break;
            case >= 5:
                _coolTime = 1f;
                _size = 1.6f;
                break;
            case >= 4:
                _rapidFire = 3;
                _bPower = 15;
                break;
            case >= 3:
                _coolTime = 1.5f;
                _size = 1.3f;
                break;
            case >= 2:
                _rapidFire = 2;
                break;
        }
    }
}
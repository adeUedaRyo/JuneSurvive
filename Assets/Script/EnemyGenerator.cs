using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Enemy _prefab = null;
    [SerializeField] float _time = 10;
    [SerializeField] Transform _root = null;
    Transform player = null;
    float _timer = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);
    int number = 5;
    [SerializeField]int wave = 1;
    int _hp = 5;
    float _speed = 1;
    ObjectPool<Enemy> _enemyPool = new ObjectPool<Enemy>();

    GameManager gm = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        _enemyPool.SetBaseObj(_prefab, _root);
        _enemyPool.SetCapacity(1000);

        GameManager.Instance.Setup();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        _timer += Time.deltaTime;
        if (_timer > _time)
        {
            Spawn();
            _timer -= _time;
        }
        
    }
    public void Spawn()
    {
        number = 3 + wave * 3;
        for (int i = 0; i < number; i++)
        {
            var script = _enemyPool.Instantiate();
            
            int xR = 1;
            float x = Random.Range(6.0f, 12.0f);
            float y = Random.Range(-3.0f, 3.0f);
            if (i > number / 2) xR = -1;
            _popPos.x = player.transform.position.x + x * xR;
            _popPos.y = player.transform.position.y + y;
            script.transform.position = _popPos;
            script.hP = _hp;
            script.speed = _speed;
            if (gm._enemyCount >= 999) break;
        }
        wave++;
        EnemyWave();
    }
    public void EnemyWave()
    {
        if(wave >= 60)// 8•ªˆÈ~
        {
            _hp++;
            _speed = 1.75f;
        }
        else if(wave >= 6)// 1•ªŒo‰ß
        {
            _hp = 8;
            if(wave >= 18)// 3•ªŒo‰ß
            {
                _time = 7.5f;
                _hp = 10;
                _speed = 1.25f;


                if(wave >= 36)// 5•ªŒo‰ß
                {
                    _hp = 15;
                    _speed = 1.5f;
                }
            }
        }
    }
}

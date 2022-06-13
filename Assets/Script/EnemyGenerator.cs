using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Enemy _prefab = null;
    [SerializeField] float _time = 0.05f;
    [SerializeField] Transform _root = null;
    Transform player = null;
    float _timer = 0.0f;
    float _cRad = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);

    ObjectPool<Enemy> _enemyPool = new ObjectPool<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        _enemyPool.SetBaseObj(_prefab, _root);
        _enemyPool.SetCapacity(1000);

        GameManager.Instance.Setup();

        //for (int i = 0; i < 900; ++i) Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _time)
        {
            Spawn();
            _timer -= _time;
        }
        void Spawn()
        {
            var script = _enemyPool.Instantiate();
            /*
            var go = GameObject.Instantiate(_prefab);
            var script = go.GetComponent<Enemy>();
            */
            _popPos.x = player.transform.position.x + 5 * Mathf.Cos(_cRad);
            _popPos.y = player.transform.position.y + 5 * Mathf.Sin(_cRad);
            script.transform.position = _popPos;
            _cRad += 0.1f;
        }
    }
}

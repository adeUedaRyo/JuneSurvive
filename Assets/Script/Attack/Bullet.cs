using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _speed = 3;//弾速
    GameObject player;
    [SerializeField] public int _power = 5;//ダメージ
    Vector3 vec;
    [SerializeField] public int _penetration = 1;//貫通する回数
    int penetCount = 0;
    // Start is called before the first frame updat
    void Start()
    {
        player = GameObject.Find("Player");
        vec = transform.position - player.transform.position;
        vec.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vec * _speed * Time.deltaTime;
        if (transform.position.x >= player.transform.position.x + 6 || transform.position.x <= player.transform.position.x - 6 || transform.position.y >= player.transform.position.y+ 4 || transform.position.y <= player.transform.position.y - 4||player==null) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            collision.GetComponent<Enemy>().Damage(_power);
            penetCount++;
        }
        if(penetCount >= _penetration)
        {
            Destroy(gameObject);

        }
    }
    public void PowerUp(float s,int pow,int pen)
    {
        _speed = s;
        _power = pow;
        _penetration = pen;
    }
}

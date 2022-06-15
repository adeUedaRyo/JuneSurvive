using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _speed = 3;//’e‘¬
    GameObject pleyer;
    [SerializeField] public int _power = 5;//ƒ_ƒ[ƒW
    Vector3 vec;
    [SerializeField] public int _penetration = 1;//ŠÑ’Ê‚·‚é‰ñ”
    int penetCount = 0;
    // Start is called before the first frame updat
    void Start()
    {
        pleyer = GameObject.Find("Player");
        vec = transform.position - pleyer.transform.position;
        vec.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vec * _speed * Time.deltaTime;
        if (transform.position.x >= pleyer.transform.position.x + 6 || transform.position.x <= pleyer.transform.position.x - 6 || transform.position.y >= pleyer.transform.position.y+ 4 || transform.position.y <= pleyer.transform.position.y - 4) Destroy(gameObject);
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
    public void PowerUp(float s,int po,int pe)
    {
        _speed = s;
        _power = po;
        _penetration = pe;
    }
}

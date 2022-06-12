using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 10;//íeë¨
    GameObject pleyer;
    [SerializeField] int power = 5;//É_ÉÅÅ[ÉW
    Vector3 vec;
    [SerializeField]int penetration = 1;//ä—í Ç∑ÇÈâÒêî
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            collision.GetComponent<Enemy>().Damage(power);
            penetCount++;
        }
        if(penetCount >= penetration)
        {
            Destroy(gameObject);

        }
    }
}

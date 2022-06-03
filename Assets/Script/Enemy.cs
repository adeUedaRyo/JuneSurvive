using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    GameObject pleyer;
    [SerializeField] int hp = 5;
    // Start is called before the first frame update
    void Awake()
    {
        pleyer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = pleyer.transform.position - transform.position;
        vec.Normalize();

        transform.position += vec * _speed * Time.deltaTime;
        
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

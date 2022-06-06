using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    GameObject player;
    [SerializeField] int hp = 5;
    [SerializeField] float atk;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player!= null)
        {
            Vector3 vec = player.transform.position - transform.position;
            vec.Normalize();
            if (vec.x < 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
            transform.position += vec * _speed * Time.deltaTime;
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float attack = atk * Time.deltaTime;
            player.GetComponent<Player>().Damage(attack);
        }
    }
    public void Damage(int damage)
    {
        hp -= damage;
    }
}

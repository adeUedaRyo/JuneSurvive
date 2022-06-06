using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gm;
    [SerializeField] float _speed = 10;
    GameObject player;
    [SerializeField] int hP = 5;
    [SerializeField] float dps = 10;//ïbä‘É_ÉÅÅ[ÉW
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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

            if (hP <= 0)
            {
                gm.Kill();
                Destroy(gameObject);
            }
        }
        
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float attack = dps * Time.deltaTime;
            player.GetComponent<Player>().Damage(attack);
        }
    }
    public void Damage(int damage)
    {
        hP -= damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool
{
    GameManager gm;
    [SerializeField] public float speed = 10;
    GameObject player;
    [SerializeField] public int hP = 5;
    [SerializeField] float dps = 10;//ïbä‘É_ÉÅÅ[ÉW
    [SerializeField] GameObject eXP;
    // Start is called before the first frame update
    SpriteRenderer _sprite;
    CapsuleCollider2D _collider;
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            return;
        }
        if (player != null)
        {
            Vector3 vec = player.transform.position - transform.position;
            vec.Normalize();
            if (vec.x < 0)
            {
                transform.localScale = new Vector2(2.5f, 2.5f);
            }
            else
            {
                transform.localScale = new Vector2(-2.5f, 2.5f);
            }
            transform.position += vec * speed * Time.deltaTime;

            if (hP <= 0)
            {
                
                gm.Kill();
                Instantiate(eXP, this.transform.position, this.transform.rotation);
                Destroy();
                hP += 5;
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
    bool _isActive = false;
    public bool IsActive => _isActive;
    public void DisactiveForInstantiate()
    {
        _collider.enabled = false;
        _sprite.enabled = false;
        _isActive = false;
    }
    public void Create() 
    {
        _collider.enabled = true;
        _sprite.enabled = true;
        _isActive = true;
        gm._enemyCount++;
    }

    public void Destroy()
    {
        _collider.enabled = false;
        _sprite.enabled = false;
        _isActive = false;
        gm._enemyCount--;
    }
}

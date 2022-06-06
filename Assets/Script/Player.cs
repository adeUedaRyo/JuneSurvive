using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameManager gm;
    [SerializeField] float moveSpeed = 1f;
    float h = 0;
    float v = 0;
    [SerializeField]float hP = 100;//現在HP
    float maxHp = 0;//最大HP
    Rigidbody2D rb;
    [SerializeField] Slider slider;
    [SerializeField] Transform hPUI;
    [SerializeField] GameObject explosion;
    Animator anim;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        slider.value = 1;
        maxHp = hP;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Vector2 hv = new Vector2(h, v).normalized;
        rb.velocity = hv * moveSpeed;
        if(h > 0)
        {
            transform.localScale = new Vector2(1, 1);
            hPUI.localScale = new Vector2(1, 1);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            hPUI.localScale = new Vector2(-1, 1);
        }

        slider.value = hP / maxHp;//スライダーの値を現在HPの割合に変更
    }
    public void Damage(float damage)
    {
        hP -= damage;
        if(hP <=0)
        {
            Death();
        }
    }
    public void Explosion() 
    {
        anim.SetTrigger("Death");
    }
    public void Death()
    {
        Instantiate(explosion,this.transform.position,this.transform.rotation);
        gm.Gameover();
        Destroy(gameObject);
    }
}

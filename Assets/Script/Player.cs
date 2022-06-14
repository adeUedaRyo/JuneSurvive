using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameManager gm;
    [SerializeField] float moveSpeed = 1f;
    float h = 0;
    float v = 0;
    [SerializeField]float hP = 100;//現在HP
    float maxHp = 100;//最大HP
    Rigidbody2D rb;
    [SerializeField] Slider slider;
    [SerializeField] Transform hPUI;
    [SerializeField] GameObject explosion;
    Animator anim;
    List<ISkill> _skill = new List<ISkill>();
    float regenerate = 0;
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

        if(h > 0)//左を向いている時だけ左右反転
        {
            transform.localScale = new Vector2(1, 1);
            hPUI.localScale = new Vector2(1, 1);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            hPUI.localScale = new Vector2(-1, 1);//HPバーが反転するのを防ぐ
        }
        if(hP <=maxHp) hP += regenerate * Time.deltaTime;
        if(hP <=maxHp)
        slider.value = hP / maxHp;//スライダーの値を現在HPの割合に変更
    }
    public void Damage(float damage)//ダメージを受けたとき
    {
        hP -= damage;
        if(hP <=0)//HPがゼロになる時
        {
            gm.alive = false;
            anim.SetTrigger("Death");//死亡時用アニメーションを再生
        }
    }
    public void Death()//死亡時用アニメーションから呼ばれる
    {
        Instantiate(explosion,this.transform.position,this.transform.rotation);
        gm.GameOver();
        Destroy(gameObject);
    }
    public void RegenerateUp()
    {
        regenerate += 0.1f;
    }
}

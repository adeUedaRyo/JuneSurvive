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
    [SerializeField]float hP = 100;//����HP
    float maxHp = 0;//�ő�HP
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

        if(h > 0)//���������Ă��鎞�������E���]
        {
            transform.localScale = new Vector2(1, 1);
            hPUI.localScale = new Vector2(1, 1);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            hPUI.localScale = new Vector2(-1, 1);//HP�o�[�����]����̂�h��
        }

        slider.value = hP / maxHp;//�X���C�_�[�̒l������HP�̊����ɕύX
    }
    public void Damage(float damage)//�_���[�W���󂯂��Ƃ�
    {
        hP -= damage;
        if(hP <=0)//HP���[���ɂȂ鎞
        {
            gm.alive = false;
            anim.SetTrigger("Death");//���S���p�A�j���[�V�������Đ�
        }
    }
    public void Death()//���S���p�A�j���[�V��������Ă΂��
    {
        Instantiate(explosion,this.transform.position,this.transform.rotation);
        gm.Gameover();
        Destroy(gameObject);
    }
}

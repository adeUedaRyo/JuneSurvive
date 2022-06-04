using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float mSpeed = 1f;
    float h = 0;
    float v = 0;
    [SerializeField]float hp = 100;//����HP
    float maxHp = 0;//�ő�HP
    Rigidbody2D rb;
    [SerializeField]Slider slider;
    [SerializeField] Transform hpUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider.value = 1;
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Vector2 hv = new Vector2(h, v).normalized;
        rb.velocity = hv * mSpeed;
        if(h > 0)
        {
            transform.localScale = new Vector2(1, 1);
            hpUI.localScale = new Vector2(1, 1);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            hpUI.localScale = new Vector2(-1, 1);
        }

        slider.value = hp / maxHp;//�X���C�_�[�̒l������HP�̊����ɕύX
    }
    public void Damage(float damage)
    {
        hp -= damage;
        if(hp <=0)
        {
            Destroy(gameObject);
        }
    }
}

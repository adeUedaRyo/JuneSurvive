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
    [SerializeField]float hP = 100;//����HP
    float maxHp = 0;//�ő�HP
    Rigidbody2D rb;
    [SerializeField] Slider slider;
    [SerializeField] Transform hPUI;
    [SerializeField] GameObject explosion;
    Animator anim;
    List<ISkill> _skill = new List<ISkill>();
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
        gm.GameOver();
        Destroy(gameObject);
    }
    //public void AddSkill(int skillId)
    //{
    //    var having = _skill.Where(s => s.SkillId == (SkillDef)skillId);
    //    if (having.Count() > 0)
    //    {
    //        having.Single().Levelup();
    //    }
    //    else
    //    {
    //        ISkill newSkill = null;
    //        switch ((SkillDef)skillId)
    //        {
    //            case SkillDef.Shot:
    //                newSkill = new Shot();
    //                break;
    //        }

    //        if (newSkill != null)
    //        {
    //            newSkill.Setup();
    //            _skill.Add(newSkill);
    //        }
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] int power = 5;//ダメージ
    [SerializeField] int weaponLevel = 1;
    [SerializeField] float _rotateSpeed = 5;//回転速度

    [SerializeField] float _speed = 5;//速度
    GameObject player = null;
    GameObject[] enemy = null;
    GameObject targetEnemy = null;
    bool back = false;
    Vector3 vec;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = 1000;
        foreach(GameObject a in enemy)
        {
            float aDistance = Vector2.Distance(player.transform.position,a.transform.position);
            if(distance > aDistance && a.GetComponent<SpriteRenderer>().enabled)
            {
                distance = aDistance;
                targetEnemy = a;
            }
        }
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }
        vec = targetEnemy.transform.position - player.transform.position;
        vec.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed * 360 * Time.deltaTime));
        time += Time.deltaTime;
        transform.position += vec * _speed *(1-time)* Time.deltaTime;
        if (transform.position.x >= player.transform.position.x + 6 || transform.position.x <= player.transform.position.x - 6 || transform.position.y >= player.transform.position.y + 4 || transform.position.y <= player.transform.position.y - 4 || player ==null)
        {
            if(time > 2)Destroy(gameObject);
        }
        if (time > 5) Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(power);
        }
    }
    public void PowerUp(int pow)
    {
        power = pow;
    }
}

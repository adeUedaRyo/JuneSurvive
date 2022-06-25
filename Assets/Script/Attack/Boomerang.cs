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
        float distance = 1000;//初期値は適当 敵との距離よりも絶対に大きくなる数字
        foreach(GameObject a in enemy)//シーン上の敵から一番近い敵を探す
        {
            float aDistance = Vector2.Distance(player.transform.position,a.transform.position);//プレイヤーとの距離を測る
            if(distance > aDistance && a.GetComponent<SpriteRenderer>().enabled)//敵との距離がより近くて、SpriteRenderer の enabled が true の時（アクティブになっていることがわかればなんでもいい）
            {
                distance = aDistance;
                targetEnemy = a;//一番近い敵をターゲットにする
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
        // (1 - time)をかけることで「１秒かけて減速しながら進み、１秒経ったら少しずつ加速しながら後ろに下がる」という挙動になる。
        // これは、time が Time.deltaTimeによって増えていき、１秒を超えた時点で (1 - time) が0を下回る。
        // そして、マイナスが掛けられることにより、スピードもマイナスになることで後ろに下がり始める。
        // （例）0秒の時　1-time = 0　,　0.5秒経過時 1 - time = 0.5 ,１秒経過時 1 - time = 0 , 1.5秒経過時 1 - time = -0.5 , ２秒経過時 1 - time = -1

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

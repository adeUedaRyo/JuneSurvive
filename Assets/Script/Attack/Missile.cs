using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] int power = 1;//É_ÉÅÅ[ÉW
    [SerializeField] int weaponLevel = 1;
    [SerializeField] float _speed = 5;
    GameObject player = null;
    GameObject[] allEnemy = null;
    List <GameObject> enemy =new List<GameObject>();
    GameObject targetEnemy = null;
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < allEnemy.Length - 1;i++)
        {
            if (allEnemy[i].GetComponent<SpriteRenderer>().enabled)
            {
                enemy.Add(allEnemy[i]);
            }
        }
        if (enemy.Count == 0)
        {
            Destroy(gameObject);
            return;
        }
        targetEnemy = enemy[Random.Range(0, enemy.Count)];
        vec = targetEnemy.transform.position - player.transform.position;
        vec.Normalize();
        Vector3 diff = targetEnemy.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vec * _speed * Time.deltaTime;
        
        if (transform.position.x >= player.transform.position.x + 6 || transform.position.x <= player.transform.position.x - 6 || transform.position.y >= player.transform.position.y + 4 || transform.position.y <= player.transform.position.y - 4 || player == null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(power);
            Destroy(gameObject);
        }
    }
}

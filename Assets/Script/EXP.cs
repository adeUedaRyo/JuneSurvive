using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    [SerializeField] int eXP = 1;
    GameManager gm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.GetEXP(eXP);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Attractzone")
        {
            Vector3 vec = collision.transform.position - transform.position;
            transform.position += vec * 5 * Time.deltaTime;
        }
    }
}

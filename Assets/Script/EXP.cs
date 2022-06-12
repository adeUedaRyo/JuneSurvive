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
}

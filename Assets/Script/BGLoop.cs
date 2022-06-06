using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{

    [SerializeField] Transform upper, lower, right, left,maxX,minX,maxY,minY;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player!= null)
        {
            if (player.transform.position.x >= maxX.transform.position.x)//プレイヤーがマップ右端に到達時
            {
                player.transform.position = new Vector2(left.position.x, player.transform.position.y);//マップ左側の右端にワープ
            }
            if (player.transform.position.x <= minX.transform.position.x)//プレイヤーがマップ左端に到達時
            {
                player.transform.position = new Vector2(right.position.x, player.transform.position.y);//マップ右側の左端にワープ
            }
            if (player.transform.position.y >= maxY.transform.position.y)//プレイヤーがマップ上端に到達時
            {
                player.transform.position = new Vector2(player.transform.position.x, lower.position.y);//マップ下側の上端にワープ
            }
            if (player.transform.position.y <= minY.transform.position.y)//プレイヤーがマップ下端に到達時
            {
                player.transform.position = new Vector2(player.transform.position.x, upper.position.y);//マップ上側の下端にワープ
            }
        }
    }
}

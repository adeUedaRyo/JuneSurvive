using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{

    [SerializeField] Transform upper, lower, right, left;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= 12.5)
        {
            player.transform.position = new Vector2(player.transform.position.x, lower.position.y);
        }
        if (player.transform.position.y <= -48.5)
        {
            player.transform.position = new Vector2(player.transform.position.x, upper.position.y);
        }
        if (player.transform.position.x <= -12.5)
        {
            player.transform.position = new Vector2(right.position.x, player.transform.position.y);
        }
        if (player.transform.position.x >= 59)
        {
            player.transform.position = new Vector2(left.position.x, player.transform.position.y);
        }
    }
}

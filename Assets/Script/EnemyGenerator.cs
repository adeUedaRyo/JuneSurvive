using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Transform maxX,minX,maxY,minY;
    int eCount = 0;
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eCount < 1000)
        {
            float x = Random.Range(maxX.position.x, minX.position.x);
            float y = Random.Range(maxY.position.y, minY.position.y);
            Instantiate(enemy, new Vector2(x, y), enemy.transform.rotation);
            eCount++;
        }
    }
}

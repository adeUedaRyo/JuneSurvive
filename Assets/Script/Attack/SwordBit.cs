using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBit : MonoBehaviour
{
    [SerializeField] float _speed = 1;//‰ñ“]‘¬“x
    [SerializeField] GameObject[] bit;
    [SerializeField] float coolTime = 3;
    [SerializeField] float activeTime =5;
    float time = 0;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, _speed * -360 * Time.deltaTime));
        if(time> coolTime && active == false)
        {
            active = true;
            time = 0;
        }
        if(time >activeTime && active ==true)
        {
            active = false;
            time = 0;
        }
        if(active == true)
        {
            bit[0].SetActive(true);
            bit[1].SetActive(true);
        }
        else
        {
            bit[0].SetActive(false);
            bit[1].SetActive(false);
        }
    }
}

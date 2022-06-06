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
            if (player.transform.position.x >= maxX.transform.position.x)//�v���C���[���}�b�v�E�[�ɓ��B��
            {
                player.transform.position = new Vector2(left.position.x, player.transform.position.y);//�}�b�v�����̉E�[�Ƀ��[�v
            }
            if (player.transform.position.x <= minX.transform.position.x)//�v���C���[���}�b�v���[�ɓ��B��
            {
                player.transform.position = new Vector2(right.position.x, player.transform.position.y);//�}�b�v�E���̍��[�Ƀ��[�v
            }
            if (player.transform.position.y >= maxY.transform.position.y)//�v���C���[���}�b�v��[�ɓ��B��
            {
                player.transform.position = new Vector2(player.transform.position.x, lower.position.y);//�}�b�v�����̏�[�Ƀ��[�v
            }
            if (player.transform.position.y <= minY.transform.position.y)//�v���C���[���}�b�v���[�ɓ��B��
            {
                player.transform.position = new Vector2(player.transform.position.x, upper.position.y);//�}�b�v�㑤�̉��[�Ƀ��[�v
            }
        }
    }
}

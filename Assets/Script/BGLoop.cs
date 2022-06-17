using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{

    [SerializeField] Transform upper, lower, right, left,maxX,minX,maxY,minY;
    GameObject player =null;
    GameObject[] enemy = null;
    GameObject[] exp = null;
    GameObject[] bullet = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        exp = GameObject.FindGameObjectsWithTag("EXP");
        bullet =GameObject.FindGameObjectsWithTag("Bullet");
        if (player!= null)
        {
            if (player.transform.position.x >= maxX.transform.position.x)//�v���C���[���}�b�v�E�[�ɓ��B��
            {
                player.transform.position = new Vector2(left.position.x, player.transform.position.y);//�}�b�v�����̉E�[�Ƀ��[�v
                Vector3 move = new Vector3(maxX.position.x - left.position.x,0,0);
                foreach (GameObject a in enemy)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in exp)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in bullet)
                {
                    a.transform.position -= move;
                }
            }

            if (player.transform.position.x <= minX.transform.position.x)//�v���C���[���}�b�v���[�ɓ��B��
            {
                player.transform.position = new Vector2(right.position.x, player.transform.position.y);//�}�b�v�E���̍��[�Ƀ��[�v
                Vector3 move = new Vector3(minX.position.x - right.position.x, 0, 0);
                foreach (GameObject a in enemy)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in exp)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in bullet)
                {
                    a.transform.position -= move;
                }
            }
            if (player.transform.position.y >= maxY.transform.position.y)//�v���C���[���}�b�v��[�ɓ��B��
            {
                player.transform.position = new Vector2(player.transform.position.x, lower.position.y);//�}�b�v�����̏�[�Ƀ��[�v
                Vector3 move = new Vector3(0,maxY.position.y - lower.position.y, 0);
                foreach (GameObject a in enemy)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in exp)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in bullet)
                {
                    a.transform.position -= move;
                }
            }
            if (player.transform.position.y <= minY.transform.position.y)//�v���C���[���}�b�v���[�ɓ��B��
            {
                player.transform.position = new Vector2(player.transform.position.x, upper.position.y);//�}�b�v�㑤�̉��[�Ƀ��[�v
                Vector3 move = new Vector3(0, minY.position.y - upper.position.y, 0);
                foreach (GameObject a in enemy)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in exp)
                {
                    a.transform.position -= move;
                }
                foreach (GameObject a in bullet)
                {
                    a.transform.position -= move;
                }
            }
        }
    }
}

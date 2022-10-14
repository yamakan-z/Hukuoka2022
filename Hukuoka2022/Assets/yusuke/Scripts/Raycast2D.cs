using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{

    //�z����g�p���Ă��鎞��[0]:1P [1]:2P
    [SerializeField]
    GameObject[] clickcard = new GameObject[2];//�N���b�N�����J�[�h������Q�[���I�u�W�F�N�g

    public GameObject Player1Canvans;//�v���C���[1�L�����o�X

    public GameObject Player2Canvans;//�v���C���[2�L�����o�X

    public int Player_turn = 1;//���݂̃v���C���[�@1�F1P�@2�F2P

    public bool j_start = false;//���s�t���O���Ăяo��

    public int[] clicknum;//�I�������J�[�h�̐���������ϐ�

    public bool judge;//���s������n�߂�t���O

    // Start is called before the first frame update
    void Start()
    {
        clicknum = new int[2];//�z��̍쐬
        Player2Canvans.SetActive(false);//�v���C���[1����X�^�[�g
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_turn == 1)
        {
            Player2Canvans.SetActive(false);
            Player1Canvans.SetActive(true);
        }
        else if (Player_turn == 2)
        {
            Player1Canvans.SetActive(false);
            Player2Canvans.SetActive(true);
        }




        //���C���J������̃}�E�X�J�[�\���̂���ʒu����Ray���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //���C���[�}�X�N�쐬
        //1<<�Z�Ń��C���[�ԍ����w��ł���
        int layerMask = 1 << 6;//�J�[�h���C���[�}�X�N

        //Ray�̒���
        float maxDistance = 10;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);

        //�Ȃɂ��ƏՓ˂������������̃I�u�W�F�N�g�̖��O�����O�ɏo��
        //�J�[�h�̃��C���[�`�F�b�N
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (Input.GetMouseButtonDown(0))
            {
                //clickcard = null;//�I�u�W�F�N�g�̏�����

                //�v���C���[�^�[���ɂ����1P�E2P�̑I�������J�[�h���擾����
                //1P
                if(Player_turn==1)
                {
                    clickcard[0] = hit.collider.gameObject;//�N���b�N�����J�[�h���擾����
                    Debug.Log("a");

                    clicknum[0] = clickcard[0].GetComponent<CardManager>().cardnum;//�擾�����J�[�h�̐�����clicknum�ɑ��
                    Debug.Log("b");

                    Player_turn++;//2P�փ^�[������
                }
                //2P
                else if (Player_turn == 2)
                {
                    clickcard[1] = hit.collider.gameObject;//�N���b�N�����J�[�h���擾����

                    clicknum[1] = clickcard[1].GetComponent<CardManager>().cardnum;//�擾�����J�[�h�̐�����clicknum�ɑ��

                    j_start = true;
                }

                if(j_start)
                {
                    judge = true;//���s�����肷��
                }
                   
               // Debug.Log(clicknum);
              
            }
        }



    }
}

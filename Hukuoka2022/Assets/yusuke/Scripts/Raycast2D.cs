using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{

    //�z����g�p���Ă��鎞��[0]:1P [1]:2P
    [SerializeField]
    GameObject[] clickcard = new GameObject[2];//�N���b�N�����J�[�h������Q�[���I�u�W�F�N�g

    [SerializeField]
    GameObject[] enemycards;//�G���I������J�[�h

    public GameObject enemyselect_card;//�G���I�������J�[�h

    public int e_select_num;//�G���I�������J�[�h�̐���

    public GameObject Player1Canvans;//�v���C���[1�L�����o�X

    public GameObject Player2Canvas;//�v���C���[2�L�����o�X

    public GameObject BattleCanvas;//�o�g����ʂ������Ă���

    public GameObject CostManager;//�R�X�g�Ǘ��}�l�[�W���[�������Ă���


    public int Turn_flow = 1;//���݂̃v���C���[�@1�F1P�@2�F2P 3:�o�g�����

    public int[] clicknum;//�I�������J�[�h�̐���������ϐ�

    int r_num;//�G�J�[�h�擾�̂��߃����_���Ȑ������Ƃ�

    private bool rand = true;//�����_���������s���t���O

    public bool judge;//���s������n�߂�t���O

    // Start is called before the first frame update
    void Start()
    {
        clicknum = new int[2];//�z��̍쐬
        Player2Canvas.SetActive(false);//�v���C���[1����X�^�[�g
    }

    public void RandomCardSelect()
    {
        r_num = Random.Range(0, 5);//�擾�����G�J�[�h�������_���Ŏ擾����
    }

    // Update is called once per frame
    void Update()
    {
        if (Turn_flow == 1)//1P�J�[�h�I�����
        {
            BattleCanvas.SetActive(false);
            Player2Canvas.SetActive(false);
            Player1Canvans.SetActive(true);
        }
        else if (Turn_flow == 2)//2P�J�[�h�I�����
        {
            Player1Canvans.SetActive(false);
            Player2Canvas.SetActive(true);

            //���ݑI���ł���G�̃J�[�h��S���擾
            GameObject[] enemycard = GameObject.FindGameObjectsWithTag("Card");

            enemycards = enemycard;//�f�o�b�O�p�ɃC���X�y�N�^�[�Ɍ�����悤�ɂ���

            //�����_���������s��
            if(rand)
            {
                RandomCardSelect();
                rand = false;//���̃^�[��1�x���������_������������
            }


            enemyselect_card = enemycard[r_num];//�G�̏o���J�[�h�����肷��

            e_select_num = enemyselect_card.GetComponent<CardManager>().cardnum;

            Turn_flow++;//2P�փ^�[������

            judge = true;//���s�����肷��
        }
        else if(Turn_flow == 3)//�o�g�����
        {
            rand = true;//����ł܂������_���������s����
            Player2Canvas.SetActive(false);
            BattleCanvas.SetActive(true);

            //���̏����Ƃ��č��N���b�N�ŉ�ʂ�؂�ւ���
            if (Input.GetMouseButtonDown(0))
            {
                Turn_flow = 1;//�^�[���t���[���Z�b�g
                Debug.Log("a");
            }
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
                if(Turn_flow == 1)
                {
                   
                    clickcard[0] = hit.collider.gameObject;//�N���b�N�����J�[�h���擾����

                    //���݂̃R�X�g���I�������J�[�h�̐�����葽����Ώo����
                    if (CostManager.GetComponent<CardCost>().cardcost >= clickcard[0].GetComponent<CardManager>().cardnum)
                    {
                        clicknum[0] = clickcard[0].GetComponent<CardManager>().cardnum;//�擾�����J�[�h�̐�����clicknum�ɑ��

                        CostManager.GetComponent<CardCost>().cardcost -= clicknum[0];

                        Turn_flow++;//2P�փ^�[������
                    }
                    else
                    {
                        Debug.Log("�R�X�g������Ȃ��I�I");
                    }

                   
                }
                //2P
                //else if (Turn_flow == 2)
                //{
                //    clickcard[1] = hit.collider.gameObject;//�N���b�N�����J�[�h���擾����

                //    clicknum[1] = clickcard[1].GetComponent<CardManager>().cardnum;//�擾�����J�[�h�̐�����clicknum�ɑ��

                //    Turn_flow++;//2P�փ^�[������

                //    judge = true;//���s�����肷��

                //}
            }
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    [SerializeField]
    private int protonum;//�G�̐����i�e�X�g�p�j

    [SerializeField]
    private int protoenemy;//�G�̗̑�

    [SerializeField]
    private GameObject RayManager;//���C�}�l�[�W���[�������Ă���iRaycast2D�Ŏ擾����clicknum�������Ă���j

    [SerializeField]
    private GameObject Player;//�v���C���[�X�N���v�g�������Ă���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���s����
        if(RayManager.GetComponent<Raycast2D>().judge)
        {

            //2�l�ΐ�p
            //�v���C���[1����
            //if (RayManager.GetComponent<Raycast2D>().clicknum[0] > RayManager.GetComponent<Raycast2D>().clicknum[1])
            //{
            //    Debug.Log("P1����");
            //    P1Win();
            //}
            ////�v���C���[2����
            //else if (RayManager.GetComponent<Raycast2D>().clicknum[0] < RayManager.GetComponent<Raycast2D>().clicknum[1])
            //{
            //    Debug.Log("P2����");
            //    P2Win();
            //}


            //�v���C���[����
            if (RayManager.GetComponent<Raycast2D>().clicknum[0] > RayManager.GetComponent<Raycast2D>().e_select_num)
            {
                Debug.Log("P1����");
                P1Win();
            }
            //�G����
            else if (RayManager.GetComponent<Raycast2D>().clicknum[0] < RayManager.GetComponent<Raycast2D>().e_select_num)
            {
                Debug.Log("�G����");
                EnemyWin();
            }
            //��������
            else if (protonum == RayManager.GetComponent<Raycast2D>().clicknum[1])
            {
                Dlow();
            }
        }
    }
    
    public void P1Win()
    {
        //����
        Debug.Log("����");
        protoenemy -= RayManager.GetComponent<Raycast2D>().clicknum[0] - RayManager.GetComponent<Raycast2D>().e_select_num;
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void EnemyWin()
    {
        //����
        Debug.Log("����");
        //�h��v�Z�@�v���C���[�J�[�h�̐��� - �G�J�[�h�̐���
        Player.GetComponent<Player>().HP -= RayManager.GetComponent<Raycast2D>().e_select_num - RayManager.GetComponent<Raycast2D>().clicknum[0];
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void P2Win()
    {
        //Debug.Log("����");
        Player.GetComponent<Player>().HP-= RayManager.GetComponent<Raycast2D>().clicknum[1] - RayManager.GetComponent<Raycast2D>().clicknum[0];
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void Dlow()
    {
        //��������
        Debug.Log("��������");
        RayManager.GetComponent<Raycast2D>().judge = false;
    }
}

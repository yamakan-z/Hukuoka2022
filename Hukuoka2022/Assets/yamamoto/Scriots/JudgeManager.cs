using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    //[SerializeField]
    //private int protonum;//�G�̐����i�e�X�g�p�j

    public int enemy_HP;//�G�̗̑�

    public Player Player;//�v���C���[�X�N���v�g�������Ă���

    public Raycast2D Raycast2D;//�X�N���v�g�������Ă���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���s����
        if(Raycast2D.judge)
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
            if (Raycast2D.clicknum > Raycast2D.e_select_num)
            {
                Debug.Log("P1����");
                P1Win();
            }
            //�G����
            else if (Raycast2D.clicknum < Raycast2D.e_select_num)
            {
                Debug.Log("�G����");
                EnemyWin();
            }
            //��������
            else if (Raycast2D.clicknum == Raycast2D.e_select_num)
            {
                Dlow();
            }
        }


    }
    
    public void P1Win()
    {
        //����
        Debug.Log("����");
        enemy_HP -= Raycast2D.clicknum - Raycast2D.e_select_num;
        Raycast2D.judge = false;
    }

    public void EnemyWin()
    {
        //����
        Debug.Log("����");
        //�h��v�Z�@�v���C���[�J�[�h�̐��� - �G�J�[�h�̐���
        Player.HP -= Raycast2D.e_select_num - Raycast2D.clicknum;
        Raycast2D.judge = false;
    }

    //public void P2Win()
    //{
    //    //Debug.Log("����");
    //    Player.GetComponent<Player>().HP-= RayManager.GetComponent<Raycast2D>().clicknum[1] - RayManager.GetComponent<Raycast2D>().clicknum[0];
    //    RayManager.GetComponent<Raycast2D>().judge = false;
    //}

    public void Dlow()
    {
        //��������
        Debug.Log("��������");
        Raycast2D.judge = false;
    }
}

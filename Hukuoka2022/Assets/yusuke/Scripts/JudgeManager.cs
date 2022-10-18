using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    [SerializeField]
    private int protonum;//�G�̐����i�e�X�g�p�j

    [SerializeField]
    private GameObject RayManager;//���C�}�l�[�W���[�������Ă���iRaycast2D�Ŏ擾����clicknum�������Ă���j

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
            //����
            if (RayManager.GetComponent<Raycast2D>().clicknum[0] > RayManager.GetComponent<Raycast2D>().clicknum[1])
            {
                Debug.Log("P1����");
                P1Win();
            }
            //����
            else if (RayManager.GetComponent<Raycast2D>().clicknum[0] < RayManager.GetComponent<Raycast2D>().clicknum[1])
            {
                Debug.Log("P2����");
                P2Win();
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
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void P2Win()
    {
        //����
        Debug.Log("����");
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void Dlow()
    {
        //��������
        Debug.Log("��������");
        RayManager.GetComponent<Raycast2D>().judge = false;
    }
}

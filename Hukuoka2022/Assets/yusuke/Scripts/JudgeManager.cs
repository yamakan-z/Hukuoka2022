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
        //����
        if (protonum < RayManager.GetComponent<Raycast2D>().clicknum && RayManager.GetComponent<Raycast2D>().judge)
        {
            Win();
        }
        //����
        else if (protonum > RayManager.GetComponent<Raycast2D>().clicknum && RayManager.GetComponent<Raycast2D>().judge)
        {
            Lose();
        }
        //��������
        else if(protonum==RayManager.GetComponent<Raycast2D>().clicknum&&RayManager.GetComponent<Raycast2D>().judge)
        {
            Dlow();
        }

    }

    public void Win()
    {
        //����
        Debug.Log("����");
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void Lose()
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

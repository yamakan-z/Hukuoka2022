using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCreata : MonoBehaviour
{
    [SerializeField]
    GameObject[] PlayerCard_Create;//�v���C���[��D�J�[�h����

    [SerializeField]
    GameObject[] EnemyCard_Create;//�v���C���[��D�J�[�h����

    [SerializeField]
    GameObject[] P_HandCreateArea;//�J�[�h�����ꏊ

    [SerializeField]
    private int rand;

    public Transform parent;


    /// <summary>
    /// �����_���Ȑ����𐶐�����
    /// </summary>
    public void RandNumCreate()
    {
        rand = Random.Range(0, 20);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<5;i++)
        {
            RandNumCreate();//�����_����������

            Debug.Log(rand);

            Instantiate(PlayerCard_Create[rand], P_HandCreateArea[i].transform.position, Quaternion.identity, parent);

            P_HandCreateArea[i].transform.localScale = Vector3.one;//�J�[�h�̑傫����e�I�u�W�F�N�g�ɉe���󂯂Ȃ��悤�ɂ���
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

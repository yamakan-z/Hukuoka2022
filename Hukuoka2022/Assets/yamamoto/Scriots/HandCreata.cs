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
    List<int> rand = new List<int>();

    public Transform parent;

    [SerializeField]
    List<GameObject> P_CardList = new List<GameObject>();//�v���C���[�̎�D����Ȃ�

    /// <summary>
    /// �����_���Ȑ����𐶐�����
    /// </summary>
    public void RandNumCreate()
    {
        rand[0] = Random.Range(0, 20);
    }

    // Start is called before the first frame update
    void Start()
    {
       
        for(int i=0;i<5;i++)
        {
            //  RandNumCreate();//�����_����������

            rand.Add(i);

            Debug.Log(rand);

            //P_CardList.Add(PlayerCard_Create[rand]);

            //Instantiate(PlayerCard_Create[rand], P_HandCreateArea[i].transform.position, Quaternion.identity, parent);

           // P_HandCreateArea[i].transform.localScale = Vector3.one;//�J�[�h�̑傫����e�I�u�W�F�N�g�ɉe���󂯂Ȃ��悤�ɂ���
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

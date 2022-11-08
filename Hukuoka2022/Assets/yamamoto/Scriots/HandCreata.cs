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
    private int rand_num;//�����_���ɐ�����������

    [SerializeField]
    List<int> rand = new List<int>();//�R�D

    [SerializeField]
    private int[] deck;//�����z��̃J�[�h�̏d����������R�D

    int count;

    [SerializeField]
    private int max;//�c��̎R�D�J�[�h����

    public Transform parent;

  
    /// <summary>
    /// �����_���Ȑ����𐶐�����
    /// </summary>
    public void RandNumCreate()
    {
        rand_num = Random.Range(0, 20);
    }

    // Start is called before the first frame update
    void Start()
    {

        deck = new int[20];

        for(int i=0;i<20;i++)
        {
            rand.Add(i);
        }

        //�����z��̃J�[�h���Ƃ�Ȃ��悤�ɂ���
        while(rand.Count>0)
        {

            rand_num = Random.Range(0,rand.Count);

            int r = rand[rand_num];
            Debug.Log(r);

            deck[count] =r;
            count++;

            rand.RemoveAt(rand_num);

            
        }

        
        for(int i=0;i<5;i++)
        {
            Instantiate(PlayerCard_Create[deck[i]], P_HandCreateArea[i].transform.position, Quaternion.identity, parent);

            P_HandCreateArea[i].transform.localScale = Vector3.one;//�J�[�h�̑傫����e�I�u�W�F�N�g�ɉe���󂯂Ȃ��悤�ɂ���

            max++;
        }


    }

    //�ŏ���5���ȍ~�̃J�[�h�������s��
    public void CardCreate()
    {
        Instantiate(PlayerCard_Create[deck[max]], P_HandCreateArea[max].transform.position, Quaternion.identity, parent);

        P_HandCreateArea[max].transform.localScale = Vector3.one;//�J�[�h�̑傫����e�I�u�W�F�N�g�ɉe���󂯂Ȃ��悤�ɂ���

        max++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

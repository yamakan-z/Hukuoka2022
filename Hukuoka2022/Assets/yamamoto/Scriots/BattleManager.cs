using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] card_generation = new GameObject[10];//��������J�[�h������

    public GameObject PlayerCardArea;//�v���C���[�̃J�[�h�����ꏊ

    public GameObject EnemyCardArea;//����̃J�[�h�����ꏊ

    public Transform parent;


    void Start()
    {
        Instantiate(card_generation[1], PlayerCardArea.transform.position, Quaternion.identity, parent);

        PlayerCardArea.transform.localScale = Vector3.one;//�J�[�h�̑傫����e�I�u�W�F�N�g�ɉe���󂯂Ȃ��悤�ɂ���


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

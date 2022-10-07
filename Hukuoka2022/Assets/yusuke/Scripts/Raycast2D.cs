using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{

    GameObject clickcard;//�N���b�N�����J�[�h������Q�[���I�u�W�F�N�g


    public int clicknum;//�I�������J�[�h�̐���������ϐ�

    public bool judge;//���s������n�߂�t���O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                clickcard = null;//�I�u�W�F�N�g�̏�����

                clickcard = hit.collider.gameObject;//�N���b�N�����J�[�h���擾����

                clicknum = clickcard.GetComponent<CardManager>().cardnum;//�擾�����J�[�h�̐�����clicknum�ɑ��

                judge = true;//���s�����肷��

                //Debug.Log(hit.collider.gameObject.name);

                Debug.Log(clicknum);
              
            }
        }


    }
}

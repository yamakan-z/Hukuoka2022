using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    int seisu = 8;

    private void Start()
    {
        print("���̐���:" + seisu);

        //�����Z
        seisu = seisu - 5;
        print("���Z����:" + seisu);

        //�|���Z
        seisu = seisu * 5;
        print("��Z����:" + seisu);
        seisu = 8;//�����̃��Z�b�g
    }
}

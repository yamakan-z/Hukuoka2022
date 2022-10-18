using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    int seisu = 8;

    private void Start()
    {
        print("Œ³‚Ì®”:" + seisu);

        //ˆø‚«Z
        seisu = seisu - 5;
        print("Œ¸ZŒ‹‰Ê:" + seisu);

        //Š|‚¯Z
        seisu = seisu * 5;
        print("æZŒ‹‰Ê:" + seisu);
        seisu = 8;//®”‚ÌƒŠƒZƒbƒg
    }
}

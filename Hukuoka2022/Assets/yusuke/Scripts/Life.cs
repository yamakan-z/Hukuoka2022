using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] public int lifeNum;

    public void SubHeartNum()
    {
        if(lifeNum<=0)
        {
            --lifeNum;
        }
    }
}

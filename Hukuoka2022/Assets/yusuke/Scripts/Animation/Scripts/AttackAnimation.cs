using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackAnimation : MonoBehaviour
{
    [SerializeField] Animator AnimationImage = null;

    public void ClickAttackButton()
    {
        AnimationImage.SetTrigger("AttackTrigger");
        AnimationImage.SetTrigger("EmptyTrigger");
    }
}
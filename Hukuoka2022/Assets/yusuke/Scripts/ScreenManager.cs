using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private Animator fadeAnimator; //�t�F�[�h�𐧌䂷��A�j���[�^�[
    public IEnumerator StartFadeOut()
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return null; //1�t���[���҂�

        while(!fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idel"))
        {
            //���o���͑ҋ@
            yield return null;
        }
    }

    public IEnumerator StartFadeIn()
    {
        fadeAnimator.SetTrigger("FadeIn");
        yield return null; //1�t���[���҂�

        while(!fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idel"))
        {
            //���o���͑ҋ@
            yield return null;
        }
    }
}

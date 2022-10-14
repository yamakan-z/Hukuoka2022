using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private Animator fadeAnimator; //フェードを制御するアニメーター
    public IEnumerator StartFadeOut()
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return null; //1フレーム待つ

        while(!fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idel"))
        {
            //演出中は待機
            yield return null;
        }
    }

    public IEnumerator StartFadeIn()
    {
        fadeAnimator.SetTrigger("FadeIn");
        yield return null; //1フレーム待つ

        while(!fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idel"))
        {
            //演出中は待機
            yield return null;
        }
    }
}

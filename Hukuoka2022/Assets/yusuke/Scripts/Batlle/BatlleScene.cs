using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えに使用するライブラリ

public class BatlleScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}

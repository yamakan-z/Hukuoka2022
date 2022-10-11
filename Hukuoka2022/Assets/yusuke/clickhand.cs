using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickhand : MonoBehaviour
{
    public int playerhand;

    public int cpuhand;

    public readonly static clickhand Instance = new clickhand();

    public void Onclick2()
    {
        clickhand.Instance.playerhand = 0;
        SceneManager.LoadScene("batlle");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

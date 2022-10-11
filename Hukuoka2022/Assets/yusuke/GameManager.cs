using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform playerHand, playerField, enemyField;
    // Start is called before the first frame update
    void Start()
    {
        //ŽèŽD‚ð‚P–‡”z‚é(Ž©•ª)
        Instantiate(cardPrefab, playerHand);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

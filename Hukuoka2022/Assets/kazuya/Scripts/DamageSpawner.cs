using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawner : MonoBehaviour
{
    public GameObject SpawnedPrefab;
    public Canvas OwnerCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var clickedPosition = Input.mousePosition;
            var newPrehub = Instantiate(SpawnedPrefab);

            Vector2 localPoint;
            var canvasRect = OwnerCanvas.GetComponent<RectTransform>();
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, clickedPosition, OwnerCanvas.worldCamera, out localPoint);

            newPrehub.transform.SetParent(this.transform, false);
            newPrehub.GetComponent<RectTransform>().anchoredPosition = localPoint;

            var sampleDamage = Random.Range(1, 9999).ToString();

            var numbers = newPrehub.GetComponent<ImageNumbers>();
            numbers.SetText(sampleDamage);

            newPrehub.SetActive(true);
        }
        
    }
}

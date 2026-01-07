using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExplode : MonoBehaviour
{

    public GameObject deadPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddPoint();
        
        if(other.CompareTag("Player"))
        {
            transform.gameObject.SetActive(false);
            for(int i = 0; i < 17; i++){
                Instantiate(deadPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCoin : MonoBehaviour
{
    public GameObject coin1, coin2, coin3, coin4;
    private int bornCoin;

    // Use this for initialization
    void Start()
    {
            if(PlayerPrefs.GetInt("Enemy") == 1)
            StartCoroutine(_PipeCoinSpawner());
    }
    // ham sinh coin 
    IEnumerator _PipeCoinSpawner()
    {

        yield return new WaitForSeconds(1.5f); 
        // random tu dong coin sinh ra trong khoang tu 1 den 5
        bornCoin = Random.Range(1, 5); 
        switch (bornCoin)
        {
            case 1:
                Vector3 vectorCoin1 = coin1.transform.position;
                vectorCoin1.y = Random.Range(-1.2f, 2.7f);
                Instantiate(coin1, vectorCoin1, Quaternion.identity);
                StartCoroutine(_PipeCoinSpawner());
                break;
            case 2:
                Vector3 vectorCoin2 = coin2.transform.position;
                vectorCoin2.y = Random.Range(-1.2f, 2.7f);
                Instantiate(coin1, vectorCoin2, Quaternion.identity);
                StartCoroutine(_PipeCoinSpawner());
                break;
            case 3:
                Vector3 vectorCoin3 = coin3.transform.position;
                vectorCoin3.y = Random.Range(-1.2f, 2.7f);
                Instantiate(coin3, vectorCoin3, Quaternion.identity);
                StartCoroutine(_PipeCoinSpawner());
                break;
            case 4:
            default:
                Vector3 vectorCoin4 = coin4.transform.position;
                vectorCoin4.y = Random.Range(-1.2f, 2.7f);
                Instantiate(coin4, vectorCoin4, Quaternion.identity);
                StartCoroutine(_PipeCoinSpawner());
                break;
        }


       
    }
}

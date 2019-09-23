using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineClound : MonoBehaviour
{
    public GameObject clound1, clound2, clound3,clound4;
    private int bornClound;

    // Use this for initialization
    void Start()
    {
            if(PlayerPrefs.GetInt("Clound") == 1)
            StartCoroutine(_PipeCloundSpawner());
    }
    // ham sinh coin 
    IEnumerator _PipeCloundSpawner()
    {

        yield return new WaitForSeconds(1.5f);
        // random tu dong coin sinh ra trong khoang tu 1 den 5
        bornClound = Random.Range(1, 4);
        switch (bornClound)
        {
            case 1:
                Vector3 vectorClound1 = clound1.transform.position; // vi tri hien tai 
                vectorClound1.y = Random.Range(-1.2f, 2.7f);  // random trong khoang min Y va max Y 
                Instantiate(clound1, vectorClound1, Quaternion.identity);
                StartCoroutine(_PipeCloundSpawner());
                break;
            case 2:
                Vector3 vectorClound2 = clound2.transform.position; // vi tri hien tai
                vectorClound2.y = Random.Range(-1.2f, 2.7f); // random trong khoang min Y va max Y 
                Instantiate(clound2, vectorClound2, Quaternion.identity);
                StartCoroutine(_PipeCloundSpawner());
                break;
            case 3:
                Vector3 vectorClound3 = clound3.transform.position; // vi tri hien tai 
                vectorClound3.y = Random.Range(-1.2f, 2.7f);  // random trong khoang min Y va max Y
                Instantiate(clound2, vectorClound3, Quaternion.identity);
                StartCoroutine(_PipeCloundSpawner());
                break;
            case 4:
            default:
                Vector3 vectorClound4 = clound4.transform.position; // vi tri hien tai 
                vectorClound4.y = Random.Range(-1.2f, 2.7f); // random trong khoang min Y va max Y
                Instantiate(clound3, vectorClound4, Quaternion.identity);
                StartCoroutine(_PipeCloundSpawner());
                break;
        }
    }
    }

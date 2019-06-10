using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMachine : MonoBehaviour
{
    public GameObject pipe;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner ()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 vt = pipe.transform.position;
        vt.y = Random.Range(-1.5f, 1.5f);
        Instantiate(pipe, vt, Quaternion.identity);
        StartCoroutine(Spawner());
    }

}

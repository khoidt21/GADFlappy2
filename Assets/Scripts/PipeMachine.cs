using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMachine : MonoBehaviour
{
    public GameObject pipe;
    public GameObject pipeblue;
    public int bornPipe = 1; // gan pipe ban dau sinh = 1
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
    }
    // ham sinh pipe trong khoang bao nhieu s
    IEnumerator Spawner ()
    {
        yield return new WaitForSeconds(1.5f);
        if (bornPipe == 1)
        {
            Vector3 vt = pipe.transform.position; // vi tri hien tai
            vt.y = Random.Range(-1.2f, 2.7f); // random trong khoang min Y va max Y 
            Instantiate(pipe, vt, Quaternion.identity); // tao ra ban sao cua 1 doi tuong
            StartCoroutine(Spawner());
            bornPipe = 2;

        }
        else if(bornPipe == 2)
        {
            Vector3 vt2 = pipeblue.transform.position; // vi tri hien tai
            vt2.y = Random.Range(-1.2f, 2.7f); // random trong khoang min Y va max Y
            Instantiate(pipeblue, vt2, Quaternion.identity); // tao ra ban sao cua 1 doi tuong
            StartCoroutine(Spawner());
            bornPipe = 1;
        }
    }

}

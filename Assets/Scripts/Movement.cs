using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.8f; // toc do di chuyen 
    private bool isMoving;     // khai bao bien kiem tra luc ban dau di chuyen
    private IEnumerator Start()
    {
        // doi 1s truoc khi vao games 
        yield return new WaitForSeconds(1);
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
        {
            Vector3 temp = transform.position;
            temp.x -= Time.deltaTime * speed;
            transform.position = temp;
        }
    }
}

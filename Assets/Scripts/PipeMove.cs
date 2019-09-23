using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed; // toc do khi pipe di chuyen 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // huy pipe khong cho pipe di chuyen
        if(BirdController.instance != null)
        {
            if(BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeMove>());
            }
        }    
        _PipeMovement(); 
    }
    // ham di chuyen pipe
    void _PipeMovement()
    {
        Vector3 vt = transform.position;  // lay vi tri hien tai 
        vt.x -= speed * Time.deltaTime;   // pipe chay theo chieu x tu phai sang trai 
        transform.position = vt;  // gan nguoc lai vi tri
    }
    // ham bat va cham giua destroy pipe voi pipe 
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "destroy")
        {
            Destroy(gameObject);
        }
    }
}

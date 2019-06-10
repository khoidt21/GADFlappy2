using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed;
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

    void _PipeMovement()
    {
        Vector3 vt = transform.position;
        vt.x -= speed * Time.deltaTime;
        transform.position = vt;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "destroy")
        {
            Destroy(gameObject);
        }
    }
}

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
        Move();
    }

    void Move()
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

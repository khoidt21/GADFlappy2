using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float speed;
    public GameObject BgNight;
    Vector3 startPOS;
    // Start is called before the first frame update
    void Start()
    {
        startPOS = BgNight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance != null)
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<BGScrolling>());
            }
        }
        transform.Translate((new Vector3(-1, 0, 0)) * speed * Time.deltaTime);
        Vector3 vt = transform.position;
        if (vt.x < -7)
            transform.position = startPOS;
    }

}

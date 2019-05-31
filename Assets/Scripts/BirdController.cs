using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }
    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void _BirdMoveMent()
    {
            if (Input.GetMouseButtonDown(0))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
            if(myBody.velocity.y > 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }else if(myBody.velocity.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }else if(myBody.velocity.y < 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
        }
            
        
    }
    public void onTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Pipe")
        {
            audioSource.PlayOneShot(pingClip);
        }
    }
    public void onCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(diedClip);
            anim.SetTrigger("Died");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]

    private AudioSource audioSource;
 
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    public float flag = 0;
    // khai bao bien diem
    public int score = 0;

    private GameObject pipe;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        _BirdMoveMent();
    }
    public void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        
    }
    public void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void _BirdMoveMent()
    {
            if (isAlive)
            {
                if (didFlap)
                {
                    didFlap = false;
                    myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                    audioSource.PlayOneShot(flyClip);
                }
            }
            // doan nay cho con birth ngoc dau len khi clip hoac ngoc dau xuong khi không clip
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
    public void FlapButton()
    {
        didFlap = true;
    }
    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Pipe")
        {
            score++;
            if (GameController.instance != null) {
                GameController.instance._SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }
    public void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");

                // tim den gameObject Spawaner Pipe 
                // Destroy game object Spawaner khong cho pipe duoc tao ra
                pipe = GameObject.Find("Spawner Pipe");
                Destroy(pipe);
            }
            if (GameController.instance != null) {
                GameController.instance._BirdDiedShowPanel(score);
            }
        }
    }
}

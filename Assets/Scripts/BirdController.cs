using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    // khai bao bien luc day len cua con bird 
    public float bounceForce;

    // khai bao rigidbody2D 
    private Rigidbody2D myBody;
    // khai bao animator cho con bird 
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
 
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap; // bien kiem tra nhan nut 

    public float flag = 0;
    // khai bao bien diem
    public int score = 0;

    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private GameObject pipeBlue;
    [SerializeField]
    private GameObject coinSpawner;
    [SerializeField]
    private GameObject cloundSpawner;


    // Update is called once per frame
    void Update()
    {
        _BirdMoveMent();
    }
    public void Awake()
    {
        isAlive = true;  // mac dinh vao game 
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
    // ham di chuyen bird
    public void _BirdMoveMent()
    {
            if (isAlive)
            {
                if (didFlap) // didFlap true // nguoi dung nhan vao
                {
                    didFlap = false; // gan didFlap false cho nguoi dung nhan vao duy nhat 1 lan 
                    // o day dung van toc nen truyen van toc co x la bao nhieu 
                    myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                    audioSource.PlayOneShot(flyClip);
                }
            }
            // bird ngoc dau len 
            // van toc theo chieu y 
            if(myBody.velocity.y > 0)
            {
                float angle = 0;
                
                // mybody.velocity.y / 7 cho no muot cho bao nhieu cung duoc
                // tinh goc theo chieu z
                angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
                // cho bird xoay 
                // xoay theo chieu x y z 
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }else if(myBody.velocity.y == 0) // truong hop bang khong cho xoay 
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }else if(myBody.velocity.y < 0) // truong hop < 0 bird ngoc dau xuong  
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
               
    }

    // nhan button roi gan didFlap = true
    public void FlapButton()
    {
        didFlap = true;
    }
    // ham bat va cham voi pipe va pipeBlue
    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Pipe" || target.tag == "PipeBlue")
        {
            score++;
            if (GameController.instance != null) {
                GameController.instance._SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }
    // ham bat va cham voi pipe va pipeBlue ground coint 
    public void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "PipeBlue" || target.gameObject.tag == "ground" || target.gameObject.tag == "coin")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");

                // tim den gameObject Spawaner Pipe 
                // Destroy game object Spawaner Pipe khong cho pipe pipe blue duoc tao ra
                // Destroy game object coin Spawner khong cho coin duoc tao ra
                // Destroy game object Clound Spawner khong cho clound duoc tao ra
                pipe = GameObject.Find("Spawner Pipe");
                pipeBlue = GameObject.Find("Spawner Pipe");
                coinSpawner = GameObject.Find("Coin Spawner");
                cloundSpawner = GameObject.Find("Clound Spawner");
                Destroy(pipe);  // huy pipe 
                Destroy(pipeBlue);  // huy pipeBlue 
                Destroy(coinSpawner); // huy coin
                Destroy(cloundSpawner);  // huy clound
            }
            if (GameController.instance != null) {
                GameController.instance._BirdDiedShowPanel(score);
            }
        }
    }
}

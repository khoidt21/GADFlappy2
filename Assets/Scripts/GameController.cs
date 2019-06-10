using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameController instance;

    public GameObject TapButtonClick;
    public GameObject blueb, greenb, redb;
    public Animator blackAnim;
    public GameObject blackImage;

    //public float speed;
    //public int background_count;
    //public float background_height;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject silverMedal, bronzeMedal, goldMedal;

    [SerializeField]
    private GameObject gameOverPanel,pausePanel;

    void Start()
    {
        Time.timeScale = 0;
        // goi ham fadeIn 
        StartCoroutine(FindInBlack());
        
    }
    void Awake()
    {
        _MakeInstance();
    }
    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Move down
        /*
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        if (pos.y < -background_height)
        {
            pos.y += background_height * background_count;
            transform.position = pos;
        }
        */
    }

    public void StartClick()
    {
        // games play bat dau
        // Time.timeScale = 1

        Time.timeScale = 1;
        TapButtonClick.SetActive(false);
       
        //disply chim
        int bird = PlayerPrefs.GetInt("bird");
        if (bird == 1)
        {
            redb.SetActive(true);
        }
        else if (bird == 2)
        {
            greenb.SetActive(true);
        }
        else if (bird == 3)
        {
            blueb.SetActive(true);
        }
    }

    // goi ham di chuyen bird tu BirdController
    public void FlyClick()
    {
        BirdController.instance.FlapButton();
    }
    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    // ham show Panel khi bird died 
    public void _BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        // lay diem hien tai
        endScoreText.text = "" + score;

        if (score > GameManagerGame.instance.GetHighScore())
        {
            GameManagerGame.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + GameManagerGame.instance.GetHighScore();

        if (score <= 1)
        {
            bronzeMedal.gameObject.SetActive(false);
            silverMedal.gameObject.SetActive(true);
            goldMedal.gameObject.SetActive(false);
        }
        else if (score > 1 && score < 5)
        {
            silverMedal.gameObject.SetActive(false);
            bronzeMedal.gameObject.SetActive(true);
            goldMedal.gameObject.SetActive(false);
        }
        else if (score >= 7)
        {
            goldMedal.gameObject.SetActive(true);
            bronzeMedal.gameObject.SetActive(false);
            silverMedal.gameObject.SetActive(false);
        }

    }
    public void _MenuButton()
    {
        SceneManager.LoadScene("MH-1");
    }
    public void _RestartGameButton()
    {
        SceneManager.LoadScene("MH-2");
    }
    // ham pause
    public void _PauseButton()
    {
        // games dong bang hoan toan 
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    // ham FadeIn animations

    public IEnumerator FindInBlack()
    {
        blackAnim.Play("FadeIn");
        yield return new WaitForSecondsRealtime(1f);
        blackImage.SetActive(false);
    }

}

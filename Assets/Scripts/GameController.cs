using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public static GameController instance;

    [SerializeField]
    private GameObject TapButtonClick, blueb, greenb, redb;
    
    [SerializeField]
    private Button pauseButtonClick,btnTouchFly;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject silverMedal, bronzeMedal, goldMedal;

    [SerializeField]
    private Text pauseEndScoreText, pauseBestScoreText;

    [SerializeField]
    private GameObject pauseSilverMedal, pauseBroneMedal, pauseGoldMedal;

    [SerializeField]
    private GameObject gameOverPanel,pausePanel;

    public GameObject blackImage;
    public Animator blackAnim;

    void Awake()
    {
        _MakeInstance();
        StartCoroutine(FindInBlack());
        Time.timeScale = 0;
    }
    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   
    public void StartClick()
    {
        // games play bat dau
        // Time.timeScale = 1

        Time.timeScale = 1;
        TapButtonClick.SetActive(false);
        btnTouchFly.gameObject.SetActive(true);
        
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

    //  ham nhan button di chuyen bird 
    //  goi FlapButton tu class BirdController
    public void FlyClick()
    {
        BirdController.instance.FlapButton();
    }
    // ham set diem hien tai
    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    // ham show Panel khi bird died 
    public void _BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        pauseButtonClick.gameObject.SetActive(false);
        btnTouchFly.gameObject.SetActive(false); // khong cho button Touch Fly cham vao man hinh panel

        // lay diem hien tai
        endScoreText.text = "" + score;
       
        if (score > GameManagerGame.instance.GetHighScore())
        {
            GameManagerGame.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + GameManagerGame.instance.GetHighScore();
        // lay diem hien tai tuong ung de set huy hieu
        if (score <= 20)
        {
            bronzeMedal.gameObject.SetActive(false);
            silverMedal.gameObject.SetActive(true);
            goldMedal.gameObject.SetActive(false);
        }
        else if (score > 20 && score < 40)
        {
            silverMedal.gameObject.SetActive(false);
            bronzeMedal.gameObject.SetActive(true);
            goldMedal.gameObject.SetActive(false);
        }
        else if (score >= 40)
        {
            goldMedal.gameObject.SetActive(true);
            bronzeMedal.gameObject.SetActive(false);
            silverMedal.gameObject.SetActive(false);
        }

    }
    // ham click menu ve man hinh 1 
    public void _MenuButton()
    {
        StartCoroutine(FadeOutBlack());
        btnTouchFly.gameObject.SetActive(true);
    }
    // ham restart Games choi lai tu man hinh 2
    public void _RestartGameButton()
    {
        SceneManager.LoadScene("MH-2");
        btnTouchFly.gameObject.SetActive(true);
    }
    // ham pause
    public void _PauseButton(int score)
    {
        // games dong bang hoan toan 
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        btnTouchFly.gameObject.SetActive(false); // khong cho button Touch Fly cham vao man hinh panel

        pauseEndScoreText.text = "" + score;

        if (score > GameManagerGame.instance.GetHighScore())
        {
            GameManagerGame.instance.SetHighScore(score);
        }
        pauseBestScoreText.text = "" + GameManagerGame.instance.GetHighScore();

        // lay diem cao nhat tung dat duoc truoc do lay ra huy hieu tuong ung
        if (GameManagerGame.instance.GetHighScore() <= 20)
        {
            pauseBroneMedal.gameObject.SetActive(false);
            pauseSilverMedal.gameObject.SetActive(true);
            pauseGoldMedal.gameObject.SetActive(false);
        }
        else if (GameManagerGame.instance.GetHighScore() > 20 && GameManagerGame.instance.GetHighScore() < 40)
        {
            pauseSilverMedal.gameObject.SetActive(false);
            pauseBroneMedal.gameObject.SetActive(true);
            pauseGoldMedal.gameObject.SetActive(false);
        }
        else if (GameManagerGame.instance.GetHighScore() >= 40)
        {
            pauseGoldMedal.gameObject.SetActive(true);
            pauseBroneMedal.gameObject.SetActive(false);
            pauseSilverMedal.gameObject.SetActive(false);
        }
        
    }
    // ham resume button tro lai man hinh games
    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        btnTouchFly.gameObject.SetActive(true);
    }
    // ham FadeIn 
    public IEnumerator FindInBlack()
    {
        blackAnim.Play("FadeIn");
        yield return new WaitForSecondsRealtime(0.8f);
        blackImage.SetActive(false);
    }
    // ham FadeOut
    // sau FadeOut chuyen sang MH-1
    public IEnumerator FadeOutBlack()
    {
        blackImage.SetActive(true);
        blackAnim.Play("FadeOut");
        yield return new WaitForSecondsRealtime(0.8f);
        SceneManager.LoadScene("MH-1");
    }

}

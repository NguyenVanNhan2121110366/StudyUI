using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private bool pause;
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private TextMeshProUGUI scoretext;

    [SerializeField] private TextMeshProUGUI time;

    [SerializeField] private TextMeshProUGUI bgGameOver;
    [SerializeField] private Button restartGame;
    [SerializeField] private GameObject title;
    [SerializeField] private TextMeshProUGUI liveText;
    [SerializeField] public int live;
    //public GameObject restart;
    [SerializeField] private GameObject gameoveee;

    [SerializeField] public bool ggameOver = true;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private int score;
    [SerializeField] private int timee;
    // Start is called before the first frame update

    void Start()
    {

        //this.restart=GameObject.Find("Restart Button");
        //this.restart.SetActive(false);
        this.gameoveee = GameObject.Find("GameOver");
        this.gameoveee.SetActive(false);
        this.restartGame.gameObject.SetActive(false);
        this.title = GameObject.Find("Title text");
        this.liveText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        live = 3;
        this.pausePanel = GameObject.Find("PausePanel");
        this.pausePanel.SetActive(false);
    }

    public void gameOver()
    {
        this.bgGameOver.gameObject.SetActive(true);
        ggameOver = false;
        StartCoroutine(delayrestart());
    }
    public void livesPlayer(int addlive)
    {
        live -= addlive;
        liveText.text = "Lives : " + live;
        if (live <= 0)
        {
            this.gameOver();
        }
    }

    public void pauseGame()
    {
        if (!pause)
        {
            pause = true;
            pausePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pause = false;
            pausePanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    IEnumerator delayrestart()
    {
        yield return new WaitForSeconds(1f);
        //this.restart.SetActive(true);
        this.restartGame.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while (ggameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //scoreUpdate(5);
            timeUpdate(-1);
        }

    }
    public void scoreUpdate(int addscore)
    {
        score += addscore;
        scoretext.text = "Score : " + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame(int difficult)
    {
        StartCoroutine(SpawnTarget());
        spawnRate /= difficult;
        scoreUpdate(0);
        timeUpdate(60);
        this.title.SetActive(false);
        this.livesPlayer(0);
    }

    void timeUpdate(int addtime)
    {
        timee += addtime;
        time.text = "Time : " + timee;
    }

    // Update is called once per frame
    void Update()
    {
        this.inputPause();
    }
    void inputPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.pauseGame();
        }
    }
}

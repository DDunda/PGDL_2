using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    //private Player player;
    //private Invaders invaders;
    //private MysteryShip mysteryShip;
    //private Bunkers[] bunkers;
    //public GameObject boundryMega;
//
    //public GameObject gameOverUI;
    //public GameObject restartArrow;
    //public GameObject gameOverLives;
    //public GameObject gameOverAlly;
    //public Text scoreText;
    //public Text livesText;
    //
//
    //public int score { get; private set; }
    //public int lives { get; private set; }
//
    //private int score1;
    //private int score2;
    //private int score3;
//
    //public AudioSource playerDie;
    //public AudioSource playerLose;
    //public AudioSource levelPass;
    //public AudioSource playerWin;
    //public AudioSource music;
//
    //public int level = 1;
//
    //public bool goodDead = false;
//
    //[Header("Story Text")]
    //public GameObject story01;
    //public GameObject story02;
    //public GameObject story03;
    //public GameObject story04;
    //public GameObject story05;
    //public GameObject story06;
    //public GameObject tabToCont;
    //public GameObject escToQuit;
//
    //private bool isPaused = false;
    

    private void Awake()
    {
        //player = FindObjectOfType<Player>();
        //invaders = FindObjectOfType<Invaders>();
        //mysteryShip = FindObjectOfType<MysteryShip>();
        //bunkers = FindObjectsOfType<Bunkers>();
    }

    private void Start()
    {
        //music.Play();
        //player.killed += OnPlayerKilled;
        //mysteryShip.killed += OnMysteryShipKilled;
        //invaders.killed += OnInvaderKilled;

        //NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("StartMenu");
            //Application.Quit();
		    //Debug.Log("Quit!");
        }
        //if (Input.GetKeyDown(KeyCode.Tab)) {
        //    isPaused = false;
        //}
    }

    //private void NewGame()
    //{
    //    //if (levelNum == 1){
    //        gameOverUI.SetActive(false);
    //        restartArrow.SetActive(false);
    //        gameOverAlly.SetActive(false);
    //        gameOverLives.SetActive(false);
//
    //        story01.SetActive(false);
    //        story02.SetActive(false);
    //        story03.SetActive(false);
    //        story04.SetActive(false);
    //        story05.SetActive(false);
    //        story06.SetActive(false);
    //        tabToCont.SetActive(false);
    //        escToQuit.SetActive(false);
//
//
    //        SetScore(0);
    //        SetLives(3);
    //        //NewRound(level, 1f);
    //        StartCoroutine(NewRound(level, 0f));
    //        //RestartLevel();
    //    //}
    //    
    //}
//
    //private IEnumerator NewRound(int levelNum, float delayTime)
    //{
    //    goodDead = false;
    //    boundryMega.gameObject.SetActive(true);
    //    gameOverUI.SetActive(false);
    //    restartArrow.SetActive(false);
    //    gameOverAlly.SetActive(false);
    //    gameOverLives.SetActive(false);
    //    story01.SetActive(false);
    //    story02.SetActive(false);
    //    story03.SetActive(false);
    //    story04.SetActive(false);
    //    story05.SetActive(false);
    //    story06.SetActive(false);
    //    tabToCont.SetActive(false);
    //    escToQuit.SetActive(false);
    //    yield return new WaitForSeconds(delayTime);
    //    invaders.PickForGood((level));
    //    if (levelNum == 1){
    //        tabToCont.SetActive(true);
    //        player.gameObject.SetActive(false);
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].DisableBunkers();
    //        }
    //        invaders.gameObject.SetActive(false);
    //        Time.timeScale = 0;
    //        boundryMega.gameObject.SetActive(true);
    //        story01.SetActive(true);
//
    //        isPaused = true;
    //        while (isPaused)
    //        {
    //            yield return null;
    //        }
//
//
    //        story01.SetActive(false);
    //        //story02.SetActive(true);
//
    //        //isPaused = true;
    //        //while (isPaused)
    //        //{
    //        //    yield return null;
    //        //}
//
    //        Time.timeScale = 1;
    //        boundryMega.gameObject.SetActive(false);
    //        //story02.SetActive(false);
    //        tabToCont.SetActive(false);
//
    //        SetLives(3);
    //        invaders.ResetInvaders();
    //        invaders.gameObject.SetActive(true);
//
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].ResetBunkers();
    //        }
//
    //        Respawn();
    //    }
//
    //    if (levelNum == 2){
    //        tabToCont.SetActive(true);
    //        player.gameObject.SetActive(false);
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].DisableBunkers();
    //        }
    //        invaders.gameObject.SetActive(false);
    //        Time.timeScale = 0;
    //        boundryMega.gameObject.SetActive(true);
    //        story02.SetActive(true);
//
    //        isPaused = true;
    //        while (isPaused)
    //        {
    //            yield return null;
    //        }
//
//
    //        story02.SetActive(false);
    //        story03.SetActive(true);
//
    //        isPaused = true;
    //        while (isPaused)
    //        {
    //            yield return null;
    //        }
//
    //        Time.timeScale = 1;
    //        boundryMega.gameObject.SetActive(false);
    //        story03.SetActive(false);
    //        tabToCont.SetActive(false);
//
    //        SetLives(3);
    //        invaders.ResetInvaders();
    //        invaders.gameObject.SetActive(true);
//
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].ResetBunkers();
    //        }
//
    //        Respawn();
    //    }
//
    //    if (levelNum == 3){
    //        tabToCont.SetActive(true);
    //        player.gameObject.SetActive(false);
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].DisableBunkers();
    //        }
    //        invaders.gameObject.SetActive(false);
    //        Time.timeScale = 0;
    //        boundryMega.gameObject.SetActive(true);
    //        story04.SetActive(true);
//
    //        isPaused = true;
    //        while (isPaused)
    //        {
    //            yield return null;
    //        }
//
//
    //        story04.SetActive(false);
    //        story05.SetActive(true);
//
    //        isPaused = true;
    //        while (isPaused)
    //        {
    //            yield return null;
    //        }
//
    //        Time.timeScale = 1;
    //        boundryMega.gameObject.SetActive(false);
    //        story05.SetActive(false);
//
    //        SetLives(3);
    //        invaders.ResetInvaders();
    //        invaders.gameObject.SetActive(true);
    //        tabToCont.SetActive(false);
//
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].ResetBunkers();
    //        }
//
    //        Respawn();
    //    }
    //    boundryMega.gameObject.SetActive(false);
    //}
//
    //private IEnumerator RestartRound(int levelNum, float delayTime)
    //{
    //    goodDead = false;
    //    boundryMega.gameObject.SetActive(true);
    //    gameOverUI.SetActive(false);
    //    restartArrow.SetActive(false);
    //    gameOverAlly.SetActive(false);
    //    gameOverLives.SetActive(false);
    //    story01.SetActive(false);
    //    story02.SetActive(false);
    //    story03.SetActive(false);
    //    story04.SetActive(false);
    //    story05.SetActive(false);
    //    story06.SetActive(false);
    //    tabToCont.SetActive(false);
    //    escToQuit.SetActive(false);
    //    yield return new WaitForSeconds(delayTime);
    //    boundryMega.gameObject.SetActive(false);
    //    invaders.PickForGood((level));
    //    if (levelNum == 1){
    //        SetLives(3);
    //        invaders.ResetInvaders();
    //        invaders.gameObject.SetActive(true);
//
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].ResetBunkers();
    //        }
//
    //        Respawn();
    //    }
//
    //    if (levelNum == 2){
    //        SetLives(3);
    //        invaders.ResetInvaders();
    //        invaders.gameObject.SetActive(true);
//
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].ResetBunkers();
    //        }
//
    //        Respawn();
    //    }
//
    //    if (levelNum == 3){
    //        SetLives(3);
    //        invaders.ResetInvaders();
    //        invaders.gameObject.SetActive(true);
//
    //        for (int i = 0; i < bunkers.Length; i++) {
    //            bunkers[i].ResetBunkers();
    //        }
//
    //        Respawn();
    //    }
    //    boundryMega.gameObject.SetActive(false);
    //}
//
    //private void Respawn()
    //{
    //    Vector3 position = player.transform.position;
    //    position.x = 0f;
    //    player.transform.position = position;
    //    player.gameObject.SetActive(true);
    //}
//
    //private void GameOver()
    //{
    //    playerLose.Play();
    //    gameOverUI.SetActive(true);
    //    restartArrow.SetActive(true);
    //    gameOverLives.SetActive(true);
    //    invaders.gameObject.SetActive(false);
    //}
//
    //private void SetScore(int score)
    //{
    //    this.score = score;
    //    scoreText.text = score.ToString().PadLeft(4, '0');
    //}
//
    //private void SetLives(int lives)
    //{
    //    this.lives = Mathf.Max(lives, 0);
    //    livesText.text = lives.ToString();
    //}
//
    //private void OnPlayerKilled()
    //{
    //    playerDie.Play();
    //    SetLives(lives - 1);
//
    //    player.gameObject.SetActive(false);
//
    //    if (lives > 0) {
    //        Invoke("Respawn", 1.0f);
    //    } else {
    //        GameOver();
    //    }
    //}
//
    //// Doing stuff when an invader is killed, including checking to see if new round should start and starting that new round
    //private void OnInvaderKilled(Invader invader)
    //{
    //    SetScore(score + invader.score);
//
    //    if (invaders.amountKilled == invaders.totalInvaders) {
    //        if (level >= 3 && goodDead == false){
    //            playerWin.Play();
    //            escToQuit.SetActive(true);
    //            player.gameObject.SetActive(false);
    //            for (int i = 0; i < bunkers.Length; i++) {
    //                bunkers[i].DisableBunkers();
    //            }
    //            invaders.gameObject.SetActive(false);
    //            //Time.timeScale = 0;
    //            boundryMega.gameObject.SetActive(true);
    //            story06.SetActive(true);
    //            
    //            
    //        } else {
//
    //            switch (level)
    //            {
    //                case 1:
    //                if (goodDead == false){
    //                    levelPass.Play();
    //                    level++;
    //                    Time.timeScale = 0;
    //                    StartCoroutine(NewRound(level, 1f));
    //                    Time.timeScale = 1;
    //                    score1 = score;
    //                } else {
    //                    gameOverUI.SetActive(true);
    //                    restartArrow.SetActive(true);
    //                    gameOverAlly.SetActive(true);
    //                }
    //                break;
//
    //                case 2:
    //                if (goodDead == false){
    //                    levelPass.Play();
    //                    level++;
    //                    Time.timeScale = 0;
    //                    StartCoroutine(NewRound(level, 1f));
    //                    Time.timeScale = 1;
    //                    score2 = score;
    //                } else {
    //                    gameOverUI.SetActive(true);
    //                    restartArrow.SetActive(true);
    //                    gameOverAlly.SetActive(true);
    //                }
    //                break;
//
    //                case 3:
    //                if (goodDead == false){
    //                    levelPass.Play();
    //                    level++;
    //                    Time.timeScale = 0;
    //                    StartCoroutine(NewRound(level, 1f));
    //                    Time.timeScale = 1;
    //                    score3 = score;
    //                } else {
    //                    gameOverUI.SetActive(true);
    //                    restartArrow.SetActive(true);
    //                    gameOverAlly.SetActive(true);
    //                }
    //                break;
    //            }
    //        } 
    //    }
    //}
//
    //public void RestartLevel()
    //{
    //    switch (level)
    //    {
    //        case 1:
    //            SetScore(0);
    //            Time.timeScale = 0;
    //            StartCoroutine(RestartRound(level, 1f));
    //            Time.timeScale = 1;
    //        break;
//
    //        case 2:
    //            SetScore(score1);
    //            Time.timeScale = 0;
    //            StartCoroutine(RestartRound(level, 1f));
    //            Time.timeScale = 1;
    //        break;
//
    //        case 3:
    //            SetScore(score2);
    //            Time.timeScale = 0;
    //            StartCoroutine(RestartRound(level, 1f));
    //            Time.timeScale = 1;
    //        break;
    //    }
    //}
//
    //private void OnMysteryShipKilled(MysteryShip mysteryShip)
    //{
    //    SetScore(score + mysteryShip.score);
    //}
}//

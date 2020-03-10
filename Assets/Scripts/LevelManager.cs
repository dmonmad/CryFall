using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool isSlowing;


    public TextMeshProUGUI puntuacionText;
    public GameObject player;
    PlayerMovement playerController;
    public GameObject deathParticles;
    GameObject spawn;
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    public AudioSource BackgroundAudio;
    public AudioSource GameOverAudio;
    public GameObject FinishMenu;
    public TextMeshProUGUI ScoreFinishGame;
    [SerializeField]
    private int StartPoints = 5000;

    private int puntuacionActual;

    // Start is called before the first frame update

    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        SpawnPlayer();
        puntuacionActual = StartPoints;
    }



    private void SpawnPlayer()
    {
        Time.timeScale = 1f;
        isSlowing = false;
        player = Instantiate(player, spawn.transform.position, spawn.transform.rotation);
        playerController = player.GetComponent<PlayerMovement>();

    }

    public void KillPlayer()
    {
        BackgroundAudio.Stop();
        GameOverAudio.Play();
        playerController.isAlive = false;
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.SetActive(false);
        MostrarDeathMenu();
    }

    public void RespawnPlayer()
    {
        GameOverAudio.Stop();
        BackgroundAudio.Play();
        RestartScore();
        player.transform.position = spawn.transform.position;
        player.SetActive(true);
        player.GetComponent<SpriteRenderer>().enabled = true;
        playerController.isAlive = true;
    }

    public void MostrarDeathMenu()
    {
        if (!DeathMenu.activeInHierarchy)
        {
            DeathMenu.SetActive(true);
            BackgroundAudio.Pause();
            StartCoroutine(ScaleTime(1.0f, 0.1f, 1.0f));

        }
        else
        {
            StopAllCoroutines();
            Time.timeScale = 1f;
            BackgroundAudio.Play();

            DeathMenu.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isAlive)
        {
            puntuacionActual = (int)(puntuacionActual - Time.deltaTime);
            puntuacionText.SetText(puntuacionActual.ToString());
        }

        if (Input.GetButtonDown("Cancel")) {
                this.MostrarPauseMenu();
        }
        
    }

    public void MostrarPauseMenu() {
        if (!PauseMenu.activeInHierarchy) {
            PauseMenu.SetActive(true);
            BackgroundAudio.Pause();
            StartCoroutine(ScaleTime(1.0f, 0.1f, 1.0f));

        } else {
            StopAllCoroutines();
            Time.timeScale = 1f;
            BackgroundAudio.Play();

            PauseMenu.SetActive(false);

        }
    }

    public void MostrarFinishMenu() {
        if (!FinishMenu.activeInHierarchy) {
            FinishMenu.SetActive(true);
            BackgroundAudio.Pause();
            StartCoroutine(ScaleTime(1.0f, 0.1f, 1.0f));

        } else {
            StopAllCoroutines();
            Time.timeScale = 1f;
            BackgroundAudio.Play();
            FinishMenu.SetActive(false);
        }
    }

    public void RestartDeadGame()
    {
        RespawnPlayer();
        MostrarDeathMenu();
    }

    public void RestartFinishedGame() {
        RespawnPlayer();
        MostrarFinishMenu();
    }

    public void RestartPausedGame() {
        
        RespawnPlayer();
        MostrarPauseMenu();

    }
    
    void RestartScore()
    {
        puntuacionActual = StartPoints;
        puntuacionText.SetText("");
    }

    public void GoToMenu()
    {
        GameOverAudio.Stop();
        SceneManager.LoadScene("Menu");
    }

    public void FinishGame() {
        MostrarFinishMenu();
        ScoreFinishGame.SetText("Game Finished! \nScore: " + puntuacionActual.ToString());
    }

    IEnumerator ScaleTime(float start, float end, float time) {     //not in Start or Update
    
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = end;
    }


}

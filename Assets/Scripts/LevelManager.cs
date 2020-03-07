using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public TextMeshProUGUI puntuacionText;
    public GameObject player;
    PlayerMovement playerController;
    public GameObject deathParticles;
    public GameObject spawn;
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    public AudioSource BackgroundAudio;
    public AudioSource GameOverAudio;
    public GameObject GameOverAudioObject;
    public GameObject FinishMenu;
    public TextMeshProUGUI ScoreFinishGame;
    [SerializeField]
    private int StartPoints = 5000;

    private int puntuacionActual;

    // Start is called before the first frame update

    private void Awake()
    {
        SpawnPlayer();
        puntuacionActual = StartPoints;
    }



    private void SpawnPlayer()
    {
        player = Instantiate(player, spawn.transform.position, spawn.transform.rotation);
        playerController = player.GetComponent<PlayerMovement>();
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);

    }

    public void KillPlayer()
    {
        BackgroundAudio.Stop();
        GameOverAudio.Play();
        playerController.isAlive = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.SetActive(false);
        GameOverAudioObject.SetActive(true);
        DeathMenu.SetActive(true);
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
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);
        DeathMenu.SetActive(false);
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
        if (!PauseMenu.active) {
            PauseMenu.SetActive(true);
            BackgroundAudio.Pause();

            Time.timeScale = 0f;

        } else {
            Time.timeScale = 1f;
            BackgroundAudio.Play();

            PauseMenu.SetActive(false);

        }
    }

    public void MostrarFinishMenu() {
        if (!FinishMenu.active) {
            FinishMenu.SetActive(true);


            Time.timeScale = 0f;

        } else {
            Time.timeScale = 1f;

            FinishMenu.SetActive(false);
        }
    }

    public void restartGameFinished() {
        RespawnPlayer();
        MostrarFinishMenu();
    }

    public void Restart() {
        
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
}

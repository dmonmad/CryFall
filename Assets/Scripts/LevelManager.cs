using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public AudioManager audiomanager;
    public AudioClip[] deathEffects;

    public TextMeshProUGUI puntuacionText;
    public GameObject[] player;
    public GameObject instantiatedPlayer;
    public int selectedPlayer;
    PlayerMovement playerController;
    PlayerHealth playerHealth;
    public GameObject deathParticles;
    GameObject spawn;
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    public AudioSource BackgroundAudio;
    public GameObject FinishMenu;
    public TextMeshProUGUI ScoreFinishGame;
    [SerializeField]
    private int StartPoints = 5000;

    private int puntuacionActual;

    // Start is called before the first frame update

    private void Awake()
    {
        selectedPlayer = PlayerPrefs.GetInt("Character", 0);
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        SpawnPlayer();
        puntuacionActual = StartPoints;
    }



    private void SpawnPlayer()
    {
        Time.timeScale = 1f;
        instantiatedPlayer = Instantiate(player[selectedPlayer], spawn.transform.position, spawn.transform.rotation);
        playerController = instantiatedPlayer.GetComponent<PlayerMovement>();
        playerHealth = instantiatedPlayer.GetComponent<PlayerHealth>();

    }

    public void KillPlayer()
    {
        BackgroundAudio.Stop();
        audiomanager.PlayRandomSound();
        playerController.isAlive = false;
        Instantiate(deathParticles, instantiatedPlayer.transform.position, instantiatedPlayer.transform.rotation);
        instantiatedPlayer.GetComponent<SpriteRenderer>().enabled = false;
        instantiatedPlayer.SetActive(false);
        MostrarDeathMenu();
    }

    public void RespawnPlayer()
    {
        audiomanager.Stop();
        BackgroundAudio.Play();
        RestartScore();
        instantiatedPlayer.transform.position = spawn.transform.position;
        instantiatedPlayer.SetActive(true);
        playerHealth.Restart();
        instantiatedPlayer.GetComponent<SpriteRenderer>().enabled = true;
        playerController.isAlive = true;
    }

    public void MostrarDeathMenu()
    {
        if (!DeathMenu.activeInHierarchy)
        {
            DeathMenu.SetActive(true);
            BackgroundAudio.Pause();
            StartCoroutine(ScaleTime(1.0f, 0f, 1.0f));

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

        if (Input.GetButtonDown("Cancel"))
        {
            this.MostrarPauseMenu();
        }

    }

    public void MostrarPauseMenu()
    {
        if (!PauseMenu.activeInHierarchy)
        {
            PauseMenu.SetActive(true);
            BackgroundAudio.Pause();
            StartCoroutine(ScaleTime(1.0f, 0f, 1.0f));

        }
        else
        {
            StopAllCoroutines();
            Time.timeScale = 1f;
            BackgroundAudio.Play();

            PauseMenu.SetActive(false);

        }
    }

    public void MostrarFinishMenu()
    {
        if (!FinishMenu.activeInHierarchy)
        {
            FinishMenu.SetActive(true);
            BackgroundAudio.Pause();
            StartCoroutine(ScaleTime(1.0f, 0f, 1.0f));

        }
        else
        {
            StopAllCoroutines();
            Time.timeScale = 1f;
            BackgroundAudio.Play();
            FinishMenu.SetActive(false);
        }
    }

    public void RestartDeadGame()
    {
        DemonBossAI x = FindObjectOfType<DemonBossAI>();
        
        if (x)
        {
            x.Restart();
        }
        RespawnPlayer();
        MostrarDeathMenu();
    }

    public void RestartFinishedGame()
    {
        DemonBossAI x = FindObjectOfType<DemonBossAI>();

        if (x)
        {
            x.Restart();
        }
        RespawnPlayer();
        MostrarFinishMenu();
    }

    public void RestartPausedGame()
    {
        DemonBossAI x = FindObjectOfType<DemonBossAI>();

        if (x)
        {
            x.Restart();
        }
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
        audiomanager.Stop();
        SceneManager.LoadScene("Menu");
    }

    public void FinishGame()
    {
        MostrarFinishMenu();
        ScoreFinishGame.SetText("Game Finished! \nScore: " + puntuacionActual.ToString());
    }

    IEnumerator ScaleTime(float start, float end, float time)
    {     //not in Start or Update

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

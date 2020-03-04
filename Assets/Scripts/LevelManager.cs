using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public TextMeshProUGUI puntuacionText;
    public GameObject player;
    public GameObject deathParticles;
    public GameObject spawn;
    public GameObject DeathMenu;

    [SerializeField]
    private int StartPoints = 5000;

    private int puntuacionActual;

    // Start is called before the first frame update

    private void Awake()
    {
        SpawnPlayer();
        puntuacionActual = StartPoints;
    }

    void Start()
    {
        
    }

    private void SpawnPlayer()
    {
        player = Instantiate(player, spawn.transform.position, spawn.transform.rotation);
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);
    }

    public void KillPlayer()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.SetActive(false);
        
        DeathMenu.SetActive(true);
    }

    public void RespawnPlayer()
    {
        player.transform.position = spawn.transform.position;
        player.SetActive(true);
        player.GetComponent<SpriteRenderer>().enabled = true;
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);
        puntuacionText.SetText("");
        DeathMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        puntuacionActual = (int)(puntuacionActual - Time.deltaTime);
        Debug.Log(puntuacionActual);
        puntuacionText.SetText(puntuacionActual.ToString());
    }
}

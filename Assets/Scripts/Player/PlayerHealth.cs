using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{

    public float MaxHealth = 200;
    public float Health;
    public GameObject canvas;
    public LevelManager lm;
    public TextMeshProUGUI hpText;


    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        canvas.SetActive(true);
        
        Health -= dmg;
        
        if (Health > MaxHealth / 2)
        {
            Invoke("HideCanvas", 4);
        }

        hpText.SetText(Health.ToString());

        if(Health <= 0)
        {
            lm.KillPlayer();
        }
    }
    
    public void Restart()
    {
        Health = MaxHealth;
        hpText.SetText(MaxHealth.ToString());
    }

    void HideCanvas()
    {
        canvas.SetActive(false);
    }
}

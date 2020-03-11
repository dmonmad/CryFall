using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemonBossHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth = 300;
    public float Health;
    DemonBossAI dai;
    public TextMeshProUGUI hpText;


    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        dai = GetComponent<DemonBossAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float dmg)
    {

        hpText.SetText(Health.ToString());

        Health -= dmg;

        if (Health <= 0)
        {
            dai.Die();
        }
    }

    public void Restart()
    {
        Health = MaxHealth;
        hpText.SetText(MaxHealth.ToString());
    }
}

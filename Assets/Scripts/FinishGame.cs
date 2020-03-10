using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        levelManager.FinishGame();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {
    public LevelManager levelManager;

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        levelManager.finishGame();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {
    Collider m_ObjectCollider;
    public LevelManager levelManager;

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name.Equals("Player")) {

        }
        
    }
}

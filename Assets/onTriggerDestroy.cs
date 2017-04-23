using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerDestroy : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("Destroyed me ");
            if (this.name == "MissionScroll(Clone)")
                gameManager.instance.setScroll(true);
            else if (this.name == "Seed(Clone)") {
                gameManager.instance.setSeedAvailibility(false);
                gameManager.instance.seeds++;
                gameManager.instance.spawnWave();
            }
            else { Debug.LogError(""); }
            Debug.Log(gameManager.instance.hasScroll);
            GameObject.Destroy(this.gameObject);
        }
        }
}

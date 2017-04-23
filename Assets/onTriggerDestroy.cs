using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerDestroy : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroyed me ");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameManager>().setScroll(true);
        GameObject.Destroy(this.gameObject);
    }
}

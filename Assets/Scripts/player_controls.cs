using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class player_controls : MonoBehaviour {
    public float speed = 5 ;
    public Sprite[] player;
    void Start () {
		
	}
	
	void Update () {
        Vector3 translationVector = new Vector3(Input.GetAxis("Horizontal") * speed , Input.GetAxis("Vertical") * speed , 0);
        biggestOfthree(translationVector);
        this.GetComponent<Rigidbody2D>().velocity = (translationVector);

        if (gameManager.instance.hasScroll) {
            Debug.Log("Scroll has been picked up !");
        }

    }


    void biggestOfthree(Vector3 trans ) {
        if (trans.x > 0) {
            this.GetComponentInChildren<SpriteRenderer>().sprite = player[0];
        }
        else if (trans.x < 0) {
            this.GetComponentInChildren<SpriteRenderer>().sprite = player[1];
        }
        else if (trans.y > 0 ) {
            this.GetComponentInChildren<SpriteRenderer>().sprite = player[2];

        }
        else if (trans.y < 0 ) {
            this.GetComponentInChildren<SpriteRenderer>().sprite = player[3];

        }
    }
}

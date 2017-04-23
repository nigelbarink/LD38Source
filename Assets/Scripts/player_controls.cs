using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;

public class player_controls : MonoBehaviour {
    public Sprite[] player;
    public Sprite plant;

    public float speed = 3.5f;
    public float lives = 100 ;
    public float endurance = 0.45f;
    public int plantsplanted = 0;
	void Update () {
        Vector3 translationVector = new Vector3(Input.GetAxis("Horizontal") * speed , Input.GetAxis("Vertical") * speed , 0);
        biggestOfthree(translationVector);
        this.GetComponent<Rigidbody2D>().velocity = (translationVector);

        if (gameManager.instance.hasScroll) {
            if (Input.GetKeyUp(KeyCode.E) && gameManager.instance.seeds > 0) {
                
                plant_Seed();
            }
            else if (Input.GetKeyUp(KeyCode.E) && gameManager.instance.seeds < 0)
            {
                Debug.Log("grab some seed first!");
            }
        }
        if (Input.GetKeyUp(KeyCode.Q) && endurance > 0.2) {
            endurance -= 0.25f;
            if (lives < 100)
            {
                lives += lives / 100 * 15;
                lives = Mathf.Clamp(lives , 0.01f, 100f );
            }
            foreach (GameObject h in GameObject.FindGameObjectsWithTag("hoarder")) {
                GameObject.Destroy(h);
            }
        }

        if (endurance <= 0 ) {
            endurance += 0.03f;
        }

        if (lives < 0) {
            // Game over
            SceneManager.LoadScene("defeat");
        }
        if (plantsplanted >= 20 ) {
            //Victory
            SceneManager.LoadScene("Victory");
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

    public void plant_Seed() {
        Debug.Log("Casting .. ");
        // origin , radius, direction
        Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 0.5f);
        foreach (Collider2D hit in hits) {
            if (hit.tag == "pot")
            {
                // plant seeds and give them water aswell
                Debug.Log(hit.name);
                hit.GetComponentInChildren<SpriteRenderer>().sprite = plant;
                hit.tag = "Untagged";
                plantsplanted ++;
                gameManager.instance.seeds--;
                endurance += 0.05f;
                break;
            }
        }
    }

    public void OnDrawGizmos()
    {

        Gizmos.color = new Color(1f,0f,0f,0.2f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}



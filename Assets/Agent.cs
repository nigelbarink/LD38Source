using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    private GameObject target;
    public int speed = 5;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () {
        if (target == null ) {
            Debug.Log("NO target FOUND!");
            return;
        }
        Vector3 towards = target.transform.position - this.transform.position;
        //Debug.Log(towards.x + " , " + towards.y);
        if ( (towards.x >= 0.5f || towards.y >= 0.5f) || (towards.x <= -0.5 || towards.y <= -0.5)) {

            this.GetComponent<Rigidbody2D>().velocity = (towards);
        }
        else {
            // Debug.Log("Attack!");
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            foreach (Collider2D hit in hits) {
                if (hit.tag == "Player") {
                    hit.gameObject.GetComponent<player_controls>().lives -= 0.1f;
                    break;
                }
            }
        }
	}
}

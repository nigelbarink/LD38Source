using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text health;
    public Text Endurance;
    public Text seeds;
    private player_controls pp;
    private void Start()
    {
        pp = ((GameObject)GameObject.FindGameObjectWithTag("Player")).GetComponent<player_controls>();
    }
    void Update () {
        seeds.text = "Seeds: " + gameManager.instance.seeds;
        if (pp == null) {
            return;
        }
        health.text = "Health: " + pp.lives ;
        Endurance.text = "Endurance: " + pp.endurance;
    }
}

using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    private static gameManager _instance ;
     public static gameManager instance {
         get { return _instance; }
        private set { }
    }

    public int seeds = 0;

    private bool _hasScroll = false;
    public bool hasScroll {
        get { return _hasScroll; }
        private set { _hasScroll = hasScroll; }
}
    private bool seedAvailable = false;
    
    public GameObject missionScroll;
    public GameObject Hoarder;
    public GameObject seed;
    public GameObject[] spawns; 
    
	void Start () {
        if (_instance != this  )
            _instance = this;


        spawns = GameObject.FindGameObjectsWithTag("spawn");

        if (spawns == null)
        {
            Debug.LogError("Spawns not found!");
        }
        else {
            
            int index = Random.Range(0, spawns.Length);
            GameObject.Instantiate(missionScroll, spawns[index].transform);
        }
	}
	
	
	void Update () {
        if (_hasScroll && !seedAvailable) {
           int index = Random.Range(0, spawns.Length);
            GameObject.Instantiate(seed, spawns[index].transform);
            seedAvailable = true;
        }
	}
    public void spawnWave()
    {
        int index;
        List<int> used = new List<int>(); 
        int amount = Random.Range(0, 5);
        for (int i = 0; i < amount; i++)
        {
            retry:
            index = Random.Range(0, spawns.Length);
            if (used.Contains(index)) {
             goto retry;    
            }
            GameObject.Instantiate(Hoarder , spawns[index].transform.position, Quaternion.identity);
        }
    }
    public void setScroll(bool state ) {
        _hasScroll = state;
    }
    public void setSeedAvailibility(bool state) {
        seedAvailable = state;
    }
}

using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    private static gameManager _instance ;
     public static gameManager instance {
         get { return _instance; }
        private set { }
    }

    private bool _hasScroll = false;
    public bool hasScroll {
        get { return _hasScroll; }
        private set { _hasScroll = hasScroll; }
}


    public GameObject missionScroll;
    public GameObject Hoarder;
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
		
	}

    public void setScroll(bool state ) {
        _hasScroll = state;
    }
}

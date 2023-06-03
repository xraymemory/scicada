using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main gameplay control. Acts as essentially the "Player Vessel" 
public class Player : MonoBehaviour
{

    public static Player instance = null;

    public int drinks = 0;

    public string[] tagged;

    public Dictionary<string, List<string>> topics = new Dictionary<string, List<string>>();


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.populateStartingTopics();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void populateStartingTopics()
    {
        this.topics.Add("Host", new List<string> { "BALOR" });
        this.topics.Add("Partygoer_Lucy", new List<string> { "BALOR" });

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

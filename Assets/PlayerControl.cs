using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main gameplay control. Acts as essentially the "Player Vessel" 
public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance = null;

    public int drinks = 0;

    public string[] tagged;

    public Dictionary<string, string[]> topics = new Dictionary<string, string[]>();


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
        this.topics.Add("Host", new string[] { "ALIMONY", "ARCHITECTURE", "BASEMENT" });
        this.topics.Add("Partygoer_Lucy", new string[] { "AVARICE", "BALOR", "NOVEL" });

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

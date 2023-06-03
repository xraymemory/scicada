using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        renderNPCs(new string[] { "Host", "Partygoer_Lucy" });   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void renderNPCs(string[] npcNames )
    {
        GameObject npcs = GameObject.Find("NPCs");

        foreach (string npcName in npcNames)
        {
            GameObject npc;
            
            npc = npcs.transform.Find(npcName).gameObject;
            npc.SetActive(true);

            UnityEngine.Debug.Log("Rendered NPCs " + npcNames);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyDialog : NPCDialog
{
    /*

    */

    public void Start()
    {

        this.innerName = "Partygoer_Lucy";

        this.disposition = 2;
        this.introduced = false;

        this.charName = "WINTERS, LUCY";
        this.role = "NOVELIST";
        this.sprite = "Sprites/portrait_lucy";

        this.openingText = "Hello...I don't believe we've met.";

        this.populateDialogResponses();

    }

    void populateDialogResponses()
    {
        List<List<string>> BALOR_RESPONSE = new List<List<string>>();
        BALOR_RESPONSE.Add(new List<string> { "I don't know him terribly well but Klaus speaks so highly of him. They've been friends for a long time." });
        BALOR_RESPONSE.Add(new List<string> { "ARCHITECTURE" });
        BALOR_RESPONSE.Add(new List<string> { "0" });
        this.topicResponses.Add("BALOR", BALOR_RESPONSE);
    }

}

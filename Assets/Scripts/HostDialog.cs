using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Versioning;
using System.Diagnostics;
using MiniJSON;
using System.Collections.Generic;

public class HostDialog : NPCDialog
{


    public void Start()
    {

        this.innerName = "Host";

        this.disposition = 3;
        this.introduced = false;

        this.charName = "MOTIF, KLAUS";
        this.role = "COLLECTOR";
        this.sprite = "Sprites/host_new";

        this.openingText = "Hello. You must be Balor's friend. He's told me all about you. So nice to finally meet in person. I'm Klaus, welcome.";

        this.populateDialogResponses();

    }

    /* DATASHAPE FOR DIALOGS
     * 
     * { "$NPCNAME":
     *  {
     *    "$TOPIC1": 
     *      { 
     *       "REPONSE": "Response text",
     *       "NEWTOPICS": ["New", "Topic"],
     *       "DISPOSITION" 0
     *       },
     *    "$TOPIC2": 
     *      { 
     *       "REPONSE": "Response text",
     *       "NEWTOPICS": [],
     *       "DISPOSITIOn": -1
     *       },
     *    }
     *  }
     *        
     *        
     * This function should eventually take in a JSON file with this shape and use it to
     * dynamically generate the code seen below
     * */

    void populateDialogResponses()
    {
        List<List<string>> ARCHITECTURE_RESPONSE = new List<List<string>>();
        ARCHITECTURE_RESPONSE.Add(new List<string> { "A lot of the commentariat of Newhattan found this building a bit...gauche when it was built. But I think you'll see many of them still attend parties here." });
        ARCHITECTURE_RESPONSE.Add(new List<string> { "COMMENTARIAT"});
        ARCHITECTURE_RESPONSE.Add(new List<string> { "0" });
        this.topicResponses.Add("ARCHITECTURE", ARCHITECTURE_RESPONSE);

        List<List<string>> BALOR_RESPONSE = new List<List<string>>();
        BALOR_RESPONSE.Add(new List<string> { "Always a pleasure to meet a friend of Balor's. He's truly a rarefied mind when it comes to architecture - I'm having him design my villa on St. Joachim." });
        BALOR_RESPONSE.Add(new List<string> { "ARCHITECTURE" });
        BALOR_RESPONSE.Add(new List<string> { "0" });
        this.topicResponses.Add("BALOR", BALOR_RESPONSE);

        List<List<string>> BASEMENT_RESPONSE = new List<List<string>>();
        BASEMENT_RESPONSE.Add(new List<string> { "Hmm? I'm afraid you are mistaken. This is a triplex penthouse - there is no basement" });
        BASEMENT_RESPONSE.Add(new List<string> { null });
        BASEMENT_RESPONSE.Add(new List<string> { "-1" });
        this.topicResponses.Add("BASEMENT", BASEMENT_RESPONSE);

        List<List<string>> COMMENTARIAT_RESPONSE = new List<List<string>>();
        COMMENTARIAT_RESPONSE.Add(new List<string> { "They're the type to skulk around at basement openings in Fish City and spend the whole time on their phones firing off half-baked bon mots." });
        COMMENTARIAT_RESPONSE.Add(new List<string> { "BASEMENT" });
        COMMENTARIAT_RESPONSE.Add(new List<string> { "0" });
        this.topicResponses.Add("COMMENTARIAT", COMMENTARIAT_RESPONSE);

    }


}

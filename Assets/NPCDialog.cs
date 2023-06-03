using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{


    public string innerName;
    public int disposition;
    public bool introduced;

    public string charName;
    public string role;
    public string sprite;

    public string openingText;

    public Dictionary<string, List<List<string>>> topicResponses = new Dictionary<string, List<List<string>>>();

    public void summonUI()
    {
        UIControl.summonUI(this, this.charName, this.role, this.sprite, Player.instance.topics, this.openingText);
    }

}

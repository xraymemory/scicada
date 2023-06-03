using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
//using System.Media;
//using System.Media;
//using System.Media;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;


public class UIControl : MonoBehaviour
{

    public void Update()
    {

        var panel = GameObject.FindWithTag("DialogUI");

        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            //panel.SetActive(false);
            Destroy(GameObject.FindWithTag("DialogChoice"));
            clearUI();
        }
    }


    public static void summonUI(NPCDialog charClass, string charName, string roleStr, string spriteLoc, Dictionary<string, List<string>> dialogTree = null, string greeting = " ")
    {

        // Get our objects all lined up
        GameObject dialog, portrait, name, role, prefabDialogChoice, dialogPlayerChoiceContainer, npcResponse;

        dialog = GameObject.FindWithTag("DialogUI");
        portrait = GameObject.Find("DialogPortrait");
        name = GameObject.Find("DialogName");
        role = GameObject.Find("DialogRole");
        prefabDialogChoice = GameObject.Find("PrefabDialogChoice");
        dialogPlayerChoiceContainer = GameObject.Find("DialogPlayerChoiceContainer");
        npcResponse = GameObject.Find("NPCResponseText");

        var topics = dialogTree[charClass.innerName];

        // Dialog Plate assets - name, role, portraits. Bring the alpha to 255 to make it visible

        Image dialogImage = dialog.GetComponentsInChildren<Image>()[0];
        Image portraitImage = portrait.GetComponentsInChildren<Image>()[0];

        Text nameText = name.GetComponentsInChildren<Text>()[0];
        Text roleText = role.GetComponentsInChildren<Text>()[0];

        nameText.text = charName;
        roleText.text = roleStr;

        Color tempColor = dialogImage.color;
        tempColor.a = 0.80f;
        dialogImage.color = tempColor;

        Sprite portraitSprite = Resources.Load<Sprite>(spriteLoc);
        portraitImage.sprite = portraitSprite;
        tempColor.a = 0.85f;
        portraitImage.color = tempColor;

        // Dialog Choices and Reply System

        // Introduce yourself option is always there
        Image prefabDialogChoiceImage = prefabDialogChoice.GetComponentsInChildren<Image>()[0];
        Text prefabDialogChoiceText = prefabDialogChoice.GetComponentsInChildren<Text>()[0];

        var prefabDialogChoiceImageColor = prefabDialogChoiceImage.color;
        prefabDialogChoiceImageColor.a = 0.95f;
        prefabDialogChoiceImage.color = prefabDialogChoiceImageColor;

        prefabDialogChoiceText.text = "INTRO YOURSELF";

        if (topics.Count > 0)
        {
            RectTransform parentPanel = dialogPlayerChoiceContainer.GetComponent<RectTransform>();
            renderDialogChoices(parentPanel, topics, charClass);

        }

        Text npcResponseContent = npcResponse.GetComponent<Text>();
        npcResponseContent.text = charClass.openingText;
    }

    public static void renderDialogChoices(RectTransform parentPanel, List<string> topics, NPCDialog npc)
    {
        GameObject prefabDialogChoice, dialogPlayerChoiceContainer;

        prefabDialogChoice = GameObject.Find("PrefabDialogChoice");
        dialogPlayerChoiceContainer = GameObject.Find("DialogPlayerChoiceContainer");
        Button dialogButton;


        for (int i = 0; i < topics.Count; i++)
        {
            GameObject dialogChoice = (GameObject)Instantiate(prefabDialogChoice);

            dialogChoice.transform.SetParent(parentPanel, false);

            Image dialogChoiceImage = dialogChoice.GetComponentsInChildren<Image>()[0];
            var choiceColor = dialogChoiceImage.color;
            choiceColor.a = 0.90f;
            dialogChoiceImage.color = choiceColor;

            Text dialogChoiceText = dialogChoice.GetComponentsInChildren<Text>()[0];

            dialogChoiceText.text = topics[i];

            Vector3 pos = dialogChoice.transform.position;
            pos.y -= (i * 0.5f) + 0.50f;
            dialogChoice.transform.position = pos;

            dialogChoice.name = topics[i];
            dialogChoice.tag = "DialogChoice";

            dialogButton = dialogChoice.GetComponentsInChildren<Button>()[0];
            dialogButton.onClick.AddListener(delegate { respondNPC(npc, dialogChoice.name); });
        }
    }

    public static void respondNPC(NPCDialog npc, string topic)
    {

        // TODO: Add dispo check and logic, should be first thing executed
        // TODO: Add dispo decrease if you spam the same topic

        GameObject npcResponse = GameObject.Find("NPCResponseText");
        GameObject dialogPlayerChoiceContainer = GameObject.Find("DialogPlayerChoiceContainer");
        Text npcResponseContent = npcResponse.GetComponent<Text>();
        npcResponseContent.text = npc.topicResponses[topic][0][0].ToString();


        foreach(string newTerm in npc.topicResponses[topic][1])
        {
            if (Player.instance.topics[npc.innerName].Contains(newTerm) == false && newTerm != null)
            {
                Player.instance.topics[npc.innerName].Add(newTerm);
            }
        }

        RectTransform parentPanel = dialogPlayerChoiceContainer.GetComponent<RectTransform>();

        Destroy(GameObject.FindWithTag("DialogChoice"));
        renderDialogChoices(parentPanel, Player.instance.topics[npc.innerName], npc);

    }

    public static void clearUI()
    {
        GameObject dialog, portrait, name, role, npcResponse, prefabDialogChoice;

        dialog = GameObject.FindWithTag("DialogUI");
        portrait = GameObject.Find("DialogPortrait");
        name = GameObject.Find("DialogName");
        role = GameObject.Find("DialogRole");
        npcResponse = GameObject.Find("NPCResponseText");
        prefabDialogChoice = GameObject.Find("PrefabDialogChoice");

        Image dialogImage = dialog.GetComponentsInChildren<Image>()[0];
        Image portraitImage = portrait.GetComponentsInChildren<Image>()[0];
        Image prefabDialogChoiceImage = prefabDialogChoice.GetComponentsInChildren<Image>()[0];

        Text nameText = name.GetComponentsInChildren<Text>()[0];
        Text roleText = role.GetComponentsInChildren<Text>()[0];

        nameText.text = " ";
        roleText.text = " ";

        Color tempColor = dialogImage.color;
        tempColor.a = 0f;
        dialogImage.color = tempColor;
        portraitImage.color = tempColor;


        GameObject[] dialogChoices = GameObject.FindGameObjectsWithTag("DialogChoice");
        foreach(GameObject choice in dialogChoices)
        {
            GameObject.Destroy(choice);
        }
        //Destroy(GameObject.FindWithTag("DialogChoice"));


        Text npcResponseContent = npcResponse.GetComponent<Text>();
        npcResponseContent.text = " ";

        prefabDialogChoiceImage.color = tempColor;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private GameObject textChatPrefab;
    [SerializeField] private Transform parentContent;
    public InputField inputField;

    private string userName = "Iruda";




    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputField.isFocused == false)
        {
            UpdateChat();
        }
    }

    public void UpdateChat()
    {
        if (inputField.text.Equals("")) return;

        chatPanel.SetActive(true);

        GameObject clone = Instantiate(textChatPrefab, parentContent);

        clone.GetComponent<Text>().text = $"{userName} : {inputField.text}";

        inputField.text = "";
    }
}

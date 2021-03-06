using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUI : MonoBehaviour
{
    [SerializeField] private TMP_Text gameStatusText;
    
    // Input field and Button
    public Button button;
    public TMP_InputField inputField;

    public void Start()
    {
        button.onClick.AddListener(ButtonOnClickHandler);
    }

    public void SetGameStatusText(string message)
    {
        gameStatusText.text = message;
    }

    private void ButtonOnClickHandler()
    {
        SetGameStatusText(inputField.text);
    }
    
}

using UnityEngine;
using TMPro;

public class SetUI : MonoBehaviour
{
    [SerializeField] private TMP_Text gameStatusText;

    public void SetGameStatusText(string message)
    {
        gameStatusText.text = message;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    string player;

    public void StartClicked()
    {
        player = inputField.text;

        if (player != "")
        {
            DataManager.Instance.player = player;
            SceneManager.LoadScene(1);
        }

    }

}

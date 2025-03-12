using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sessiondisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public void onConnectionSucccess(int sessionID)
    {
        var displayfield = GetComponent<TextMeshProUGUI>();
        if (sessionID < 0)
        {
            displayfield.text = $"Logging locally (session {sessionID})";
        }
        else
        {
            displayfield.text = $"Connected to server (Session {sessionID})";
        }
    }

    // Update is called once per frame
    public void OnConnectionFail(string errorMessage)
    {
        var displayfield = GetComponent<TextMeshProUGUI>();
        displayfield.text = $"Error: {errorMessage}";
    }
}

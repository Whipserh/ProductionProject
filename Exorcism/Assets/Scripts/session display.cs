using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NodeCanvas.Tasks.Actions;

public class sessiondisplay : MonoBehaviour
{

    public void onConnectionSuccess(int sessionID)
    {
        var displayfield = GetComponent<TextMeshProUGUI>();
        if (sessionID < 0)
        {
            displayfield.text = $"Logging Locally (session {sessionID})";

        }
        else
        {
            displayfield.text = $"Connected to server (session {sessionID})";

        }

    }


    public void onConnectionFail(string sessionID)
    {

        var displayfield = GetComponent<TextMeshProUGUI>();
        displayfield.text = $"Error - {sessionID}";
        }


}

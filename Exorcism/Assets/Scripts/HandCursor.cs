using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour
{

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D openHand;
    [SerializeField] private Texture2D clickHand;
    [SerializeField] private Vector2 clickPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        clickPosition = new Vector2(defaultCursor.width * 0.5f, defaultCursor.height * 0.5f);
        Cursor.SetCursor(defaultCursor, clickPosition, CursorMode.Auto);
    }


    // TODO: change hand if player is clicking or hovering over something
}

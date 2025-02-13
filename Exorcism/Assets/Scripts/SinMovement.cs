using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    // https://discussions.unity.com/t/using-mathf-sin-to-move-an-object/115367
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) / 9f, Mathf.Sin(Time.time) / 2f, 0.0f);
    }
}

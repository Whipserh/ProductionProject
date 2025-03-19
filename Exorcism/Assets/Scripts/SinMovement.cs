using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    // https://discussions.unity.com/t/using-mathf-sin-to-move-an-object/115367
    private Vector3 _startPosition;
    public float xVal = 9f;
    public float yVal = 2f;

    void Start()
    {
        _startPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) / xVal, Mathf.Sin(Time.time) / yVal, 0.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] private float sensitivity = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        turn.y = Mathf.Clamp(turn.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}

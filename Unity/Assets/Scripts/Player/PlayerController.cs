using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Vector2 controlAxis;

    private void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        controlAxis = new Vector3(horizontalInput, verticalInput);
    }
}

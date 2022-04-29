using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    private InputAction detectLeftShiftKey;

    public float Smoothing = 5;
    // Start is called before the first frame update
    void Start()
    {
        detectLeftShiftKey = new InputAction(
            type: InputActionType.Button,
            binding: "<Keyboard>/leftShift",
            interactions: "hold(duration=0.2)");

        detectLeftShiftKey.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectLeftShiftKey.ReadValue<float>() != 1)
        transform.position = Vector3.Lerp(transform.position,Target.position+Offset, Smoothing * Time.fixedDeltaTime);
        
    }
}

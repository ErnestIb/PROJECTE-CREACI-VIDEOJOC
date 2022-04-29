using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementImproved : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 dragOrigin;

    void Update()
    {
        PanCamera();
    }

    public void PanCamera()
    {
        Debug.Log("move camera!");

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            print("origin " + dragOrigin + " new position " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);

            cam.transform.position += difference;
        }

    }
}

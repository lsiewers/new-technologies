using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private int rotationSpeed = 2;
    [SerializeField] private float mouseSensitivity = 1.0f;
    private float prevX;
    private float zRotation;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(transform.position).z));
        // transform.RotateAround(cam.transform.position, Vector3.up, Time.deltaTime * (prevX - transform.position.x));
        prevX = transform.position.x;
        transform.LookAt(new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z));
        
        int distance = 15;
        transform.position = (transform.position - cam.transform.position).normalized * distance + cam.transform.position;

        if (cam.WorldToViewportPoint(transform.position).x >= 0.7f) {
            cam.transform.Rotate(cam.transform.rotation.x, cam.transform.rotation.y + mouseSensitivity, cam.transform.rotation.z);
        } else if(cam.WorldToViewportPoint(transform.position).x <= 0.3f) {
            cam.transform.Rotate(cam.transform.rotation.x, cam.transform.rotation.y - mouseSensitivity, cam.transform.rotation.z);
        }

        if(Input.GetKey(KeyCode.UpArrow)) {
            zRotation += rotationSpeed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            zRotation -= rotationSpeed;
        }
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, zRotation));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private int rotationSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));

        if(Input.GetMouseButtonDown(0)) {
            transform.Rotate(transform.rotation.x - rotationSpeed, transform.rotation.y - rotationSpeed, 5);
        } else if (Input.GetMouseButtonDown(1)) {
            transform.Rotate(transform.rotation.x + rotationSpeed, transform.rotation.y + rotationSpeed, 5);
        }
    }
}

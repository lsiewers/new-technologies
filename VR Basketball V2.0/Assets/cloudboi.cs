using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudboi : MonoBehaviour
{

    [SerializeField] GameObject cam;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 2.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(cam.transform.position, Vector3.up, Time.deltaTime * speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Basketball : MonoBehaviour
{
    [SerializeField] private GameObject missesText;
    [SerializeField] private GameObject goalsText;
    [SerializeField] private GameObject arrowRight;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject cam;
    private int misses = 0;
    private int goals = 0;
    private float prevX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(cam.transform.position, Vector3.up, Time.deltaTime * (prevX - transform.position.x * 0.5f));
        // transform.RotateAround(cam.transform.position, Vector3.up, Time.deltaTime * 20);
        transform.LookAt(new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z) );
        int distance = 15;
        transform.position = (transform.position - cam.transform.position).normalized * distance + cam.transform.position;
        // transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        prevX = transform.position.x;
        
        if(cam.GetComponentInChildren<Camera>().WorldToViewportPoint(transform.position).x >= 1.55f) {
            arrowRight.SetActive(true);
            arrowLeft.SetActive(false);
        } else if(cam.GetComponentInChildren<Camera>().WorldToViewportPoint(transform.position).x <= -0.55f) {
            arrowLeft.SetActive(true);
            arrowRight.SetActive(false);
        } else {
            arrowLeft.SetActive(false);
            arrowRight.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "End detector") {
            misses++;
            missesText.GetComponent<TextMeshProUGUI>().SetText(misses.ToString() + " Misses");
        } 
        if (other.gameObject.name == "Score point") {
            goals++;
            goalsText.GetComponent<TextMeshProUGUI>().SetText(goals.ToString() + " Goals");
        }
        if (other.gameObject.name == "Score point" || other.gameObject.name == "End detector") {
            int randomPos = Random.Range(-20, 20);
            transform.RotateAround(cam.transform.position, Vector3.up, prevX -randomPos);
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }
        if (other.gameObject.name != "End detector" && other.gameObject.name != "Score point")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

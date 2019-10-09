using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTest : MonoBehaviour
{
    public AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IEnumerator JustWait()
    //{
        //print(Time.time);
        //yield return new WaitForSeconds(0.5f);
        //print(Time.time);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Platform")
        //{
            //soundSource.Play();
            //StartCoroutine(JustWait());
        //Destroy(GetComponent<Rigidbody>());        
            //Destroy(collision.gameObject);
        //}
    }
}

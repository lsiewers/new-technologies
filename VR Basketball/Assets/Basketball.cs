using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Basketball : MonoBehaviour
{
    [SerializeField] GameObject missesText;
    [SerializeField] GameObject goalsText;
    private int misses = 0;
    private int goals = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "End detector") {
            misses++;
            missesText.GetComponent<TextMeshProUGUI>().SetText(misses.ToString() + " Misses");
        } 
        if (other.gameObject.name == "Score point") {
            goals++;
            goalsText.GetComponent<TextMeshProUGUI>().SetText(goals.ToString() + " Goals");
        }
        if (other.gameObject.name == "Score point" || other.gameObject.name == "End detector") {
            int randomX = Random.Range(-6, 6);
            transform.position = new Vector3(randomX, 5, 5);
            Debug.Log(randomX);
        }
    }
}

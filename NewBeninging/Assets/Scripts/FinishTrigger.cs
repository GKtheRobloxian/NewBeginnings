using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishTrigger : MonoBehaviour
{
    public GameObject finishText;
    public TMP_Text timeText;
    public float timer = 0.000f;
    bool counting = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.Find("Player"))
        {
            finishText.SetActive(true);
            counting = false;
            timer = Mathf.Round(timer * 1000)/1000;
            timeText.text = "Time: " + timer;
            timeText.gameObject.SetActive(true);
        }
    }
}

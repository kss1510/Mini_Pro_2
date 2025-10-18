using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIandSound : MonoBehaviour
{
    public TMP_Text infoBox;

    public AudioClip Marsclip1;
    public AudioClip Marsclip2;
    public AudioClip Marsclip3;

    AudioSource audioSource;

    string UIState = "void"; // starting point
    int infoID = 1; // pointer to info text

    string marsText1 = "Mars, our closest neighbour and possibly humanities next home";
    string marsText2 = "Mars is also known as the Red Planet \n" 
                        +"Mars is named after the Roman god of war\n"
                        +"Mars is smaller than Earth with a diameter of 4217 miles";
    string marsText3 = "toDo";

    string earthText1 = "Earth \n  Mostly Harmless!";
    string earthText2 = "Earth has a diverse climate, supporting millions of species";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();     
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "mars")
                {
                    UIState = "Mars";
                    infoID = 1;
                    infoBox.text = marsText1;
                    audioSource.PlayOneShot(Marsclip1, 1);
                }

                if (hit.transform.tag == "earth")
                {
                    infoBox.text = "select a planet";
                    UIState = "Earth";
                }

                if (hit.transform.tag == "marsInfo")
                {
                    Destroy(hit.transform.gameObject);
                    infoBox.text = "Select a Planet";
                    UIState = "void";
                }

                   if (hit.transform.tag == "earthinfo")
                {
                    Destroy(hit.transform.gameObject);
                    infoBox.text = "Select a Planet";
                    UIState = "void";
                }
            }
        }
    }

    public void nextButton()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (UIState == "Mars")
        {
            switch(infoID)
            { 
                case 1:
                    infoID = 2;
                    infoBox.text = marsText2;
                    audioSource.PlayOneShot(Marsclip2, 1f);
                    break;
                case 2:        
                    infoID = 3;
                    infoBox.text = marsText3;
                    audioSource.PlayOneShot(Marsclip3, 1f);
                    break;
                default:
                    break;
            }
        }

        if (UIState == "Earth")
        {
            switch(infoID)
            {
                case 1:
                    infoID = 2;
                    infoBox.text = earthText2;
                    break;
                default:
                    infoBox.text = "Select a Planet";
                    UIState = "void";
                    break;
            }
        }
    }
}

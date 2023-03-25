using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paper1Text : MonoBehaviour
{
    // UI text objects
    public GameObject textmeshpro_name;
    public GameObject textmeshpro_age;
    public GameObject textmeshpro_occupation;
    public GameObject textmeshpro_time;
    public GameObject textmeshpro_description;


    // Game variables
    public string name;
    public string age;
    public string occupation;
    public string time;
    public string description;

    // Text Components
    TextMeshProUGUI textmeshpro_name_text;
    TextMeshProUGUI textmeshpro_age_text;
    TextMeshProUGUI textmeshpro_occupation_text;
    TextMeshProUGUI textmeshpro_time_text;
    TextMeshProUGUI textmeshpro_description_text;


    void Start()
    {
        // getting the components from the game objects
        textmeshpro_name_text = textmeshpro_name.GetComponent<TextMeshProUGUI>();
        textmeshpro_name_text.text = name;
    }


    void Update()
    {
        
    }
}

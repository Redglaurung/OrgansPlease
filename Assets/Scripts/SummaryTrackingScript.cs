using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SummaryTrackingScript : MonoBehaviour
{
    // Categories to think about:
    // Neither oldest or youngest
    // Oldest
    // Youngest
    // Highest income
    // Lowest income
    // Neither highest or lowest income
    // Not well-known
    // Well-known (extremely)
    // Well-known (moderately)
    // No good
    // Potential good
    // Guaranteed good
    // Longest on waitlist
    // Shortest on waitlist

    // Day 1
    // Page 1 Esmeralda
    // Page 2 Jinnie
    // Page 3 Mathias
    // Page 4 Jack

    // Should I be tracking neitherAge, neitherIncome, neitherWait?
    public int oldest = 0;
    public int youngest = 0;
    public int neitherAge = 0;
    public int highestIncome = 0;
    public int lowestIncome = 0;
    public int neitherIncome = 0;
    public int notKnown = 0;
    public int midKnown = 0;
    public int wellKnown = 0;
    public int noGood = 0;
    public int potGood = 0;
    public int guarGood = 0;
    public int longWait = 0;
    public int shortWait = 0;
    public int neitherWait = 0;

    public bool sameLevel = true;
    public bool gameOver = true;
    bool ranFeedback = false;
    CharacterTrackingScript character;
    public GameObject barChart;
    public Sprite bar;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        character = gameObject.GetComponent<CharacterTrackingScript>();
        barChart = GameObject.Find("BarChartExample");
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("'"))
        {
            SceneManager.LoadScene("EndingFeedback");
        }
        if((SceneManager.GetActiveScene().name == "EndingFeedback") && (!ranFeedback)){
                makeFeedbackSheet();
                ranFeedback=true;
        }
        if (sameLevel == true)
        {
            if (character.isChosen())
            {
                sameLevel = false;
                // Some print statements for Paper1 (Esmeralda)
                Debug.Log("This is the oldest var: " + oldest);
                Debug.Log("This is the neitherIncome var: " + neitherIncome);
                Debug.Log("This is the midKnown var: " + midKnown);
                Debug.Log("This is the potGood var: " + potGood);
                Debug.Log("This is the longWait var: " + longWait);
                if (gameOver == true)
                {
                    // Draw Bar Chart code goes in here
                    drawBarChart();
                }
            }
        }
    }

    public void drawBarChart()
    {
        // Will create a bar with a length dependent on the value of the variable youngest
        if (youngest >= 0)
        {
            GameObject square = new GameObject("BarYoungest");
            square.transform.SetParent(barChart.transform);
            SpriteRenderer squareRenderer = square.AddComponent<SpriteRenderer>();
            squareRenderer.sprite = bar;
            squareRenderer.color = Color.red;
            squareRenderer.sortingLayerName = "Testing Layer";
            square.transform.localScale = new Vector3(youngest, 1, 1);
        }
    }
    public void makeFeedbackSheet() {
            GameObject[] DataArray = GameObject.FindGameObjectsWithTag ("Data");
            for (int i = 0; i < DataArray.Length; i++) {
                if(DataArray[i].name == "Oldest Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(oldest.ToString());
                    //currentText.text=oldest.ToString();
                }
                if(DataArray[i].name == "Youngest Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(youngest.ToString());
                }
                if(DataArray[i].name == "AgeNeither Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(neitherAge.ToString());
                }
            }
           
    }
}

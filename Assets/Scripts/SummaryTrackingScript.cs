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

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        character = gameObject.GetComponent<CharacterTrackingScript>();
        barChart = GameObject.Find("BarChartExample");
        gameOver = true;
        oldest = 1;
        youngest = 3;
        neitherAge = 4;
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = gameObject.scene.name;
        if (sameLevel == true && gameOver == true && sceneName == "EndingFeedback")
        {
            // Draw Bar Chart code goes in here
            drawBarChart();
            sameLevel = false;
        }
        if (Input.GetKeyDown("'"))
        {
            SceneManager.LoadScene("EndingFeedback");
        }
        if((SceneManager.GetActiveScene().name == "EndingFeedback") && (!ranFeedback)){
                makeFeedbackSheet();
                ranFeedback=true;
        }
        //if (sameLevel == true)
        //{
        //    if (character.isChosen())
        //    {
        //        sameLevel = false;
        //        // Some print statements for Paper1 (Esmeralda)
        //        Debug.Log("This is the oldest var: " + oldest);
        //        Debug.Log("This is the neitherIncome var: " + neitherIncome);
        //        Debug.Log("This is the midKnown var: " + midKnown);
        //        Debug.Log("This is the potGood var: " + potGood);
        //        Debug.Log("This is the longWait var: " + longWait);
        //        if (gameOver == true)
        //        {
        //            // Draw Bar Chart code goes in here
        //            drawBarChart();
        //        }
        //    }
        //}
    }

    public void drawBarChart()
    {
        // Will create a bar with a length dependent on the value of the variable youngest
        ArrayList ageCategory = new ArrayList()
        {
            oldest,
            youngest,
            neitherAge
        };

        Debug.Log("This is oldest: " + ageCategory[0]);
        Debug.Log("This is youngest: " + ageCategory[1]);
        Debug.Log("This is neitherAge: " + ageCategory[2]);

        ArrayList incomeCategory = new ArrayList()
        {
            highestIncome,
            lowestIncome,
            neitherIncome
        };

        ArrayList knownCategory = new ArrayList()
        {
            wellKnown,
            notKnown,
            midKnown
        };

        ArrayList futureGoodCategory = new ArrayList()
        {
            guarGood,
            noGood,
            potGood
        };

        ArrayList waitCategory = new ArrayList()
        {
            longWait,
            shortWait,
            neitherWait
        };


        int colorTracker = 0;   // The current colors are 1 = Red, 2 = Green, and 3 = Gray
        foreach (int tracker in ageCategory)
        {
            GameObject barChart = GameObject.Find("AgeBarChart");
            GameObject square = new GameObject("Bar");
            square.transform.SetParent(barChart.transform);
            SpriteRenderer squareRenderer = square.AddComponent<SpriteRenderer>();
            squareRenderer.sprite = bar;
            if (colorTracker == 0)
            {
                squareRenderer.color = Color.red;
                colorTracker++;
            } else if (colorTracker == 1)
            {
                squareRenderer.color = Color.green;
                colorTracker++;
            } else
            {
                squareRenderer.color = Color.gray;
            }
            squareRenderer.sortingLayerName = "Testing Layer";
            square.transform.localScale = new Vector3(tracker, 1, 1);

        }

        colorTracker = 0;
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
                if(DataArray[i].name == "HighPay Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(highestIncome.ToString());
                }
                if(DataArray[i].name == "LowPay Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(lowestIncome.ToString());
                }
                if(DataArray[i].name == "PayNeither Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(neitherIncome.ToString());
                }
                if(DataArray[i].name == "WellKnown Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(wellKnown.ToString());
                }
                if(DataArray[i].name == "Obscure Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(notKnown.ToString());
                }
                if(DataArray[i].name == "LongestWait Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(longWait.ToString());
                }
                if(DataArray[i].name == "ShortestWait Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(shortWait.ToString());
                }
                if(DataArray[i].name == "WaitNeither Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(neitherWait.ToString());
                }
                if(DataArray[i].name == "HistoryGood Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(guarGood.ToString());
                }
                if(DataArray[i].name == "FutureGood Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(potGood.ToString());
                }
                if(DataArray[i].name == "NeitherGood Data"){
                    TextMeshProUGUI currentText = DataArray[i].GetComponent<TextMeshProUGUI>();
                    currentText.SetText(noGood.ToString());
                }
            }
           
    }
}

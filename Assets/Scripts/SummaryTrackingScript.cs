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
    public Sprite bar;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        character = gameObject.GetComponent<CharacterTrackingScript>();
        gameOver = true;
        oldest = 1;
        youngest = 2;
        neitherAge = 3;

        highestIncome = 2;
        lowestIncome = 4;
        neitherIncome = 5;

        wellKnown = 1;
        notKnown = 1;
        midKnown = 1;

        guarGood = 1;
        noGood = 1;
        potGood = 1;
        longWait = 1;
        shortWait = 1;
        neitherWait = 1;
    }


    // Update is called once per frame
    void Update()
    {
        if (sameLevel == true && gameOver == true && SceneManager.GetActiveScene().name == "EndingFeedback")
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

        // Uncomment back into code after the bar chart code is working.
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
        //float squareY = 0f;
        float yScale = 0.5f;

        GameObject ageObject = GameObject.Find("Age");
        Transform ageObjectSquare = ageObject.transform.Find("Square");

        GameObject mainScreen = ageObject.transform.parent.gameObject;
        GameObject viewPort = mainScreen.transform.parent.gameObject;
        GameObject scrollView = viewPort.transform.parent.gameObject;
        Debug.Log("This is the position of " + scrollView + ": " + scrollView.transform.position);
        Debug.Log("This is the position of " + viewPort + ": " + viewPort.transform.position);
        Debug.Log("This is the position of Main Screen: " + mainScreen.transform.position);
        Vector3 offset = scrollView.transform.position + viewPort.transform.localPosition + mainScreen.transform.localPosition;



        //Debug.Log("The position of ageObjectSquarePosition is: " + ageObjectSquarePosition);

        GameObject payObject = GameObject.Find("Pay");
        Transform payObjectSquare = payObject.transform.Find("Square");
        //Debug.Log("This is the position of payObject: " + payObject.transform.position);
 
        



        GameObject notorietyObject = GameObject.Find("Notoriety");
        Transform notorietyObjectSquare = notorietyObject.transform.Find("Square");
        //Debug.Log("The position of notorietyObjectSquarePosition is: " + notorietyObjectSquarePosition);

        GameObject waitObject = GameObject.Find("Waitlist");
        Transform waitObjectSquare = waitObject.transform.Find("Square");

        GameObject philObject = GameObject.Find("Philanthropy");
        Transform philObjectSquare = philObject.transform.Find("Square");


        Vector3 ageObjectSquarePosition = offset + ageObject.transform.localPosition + ageObjectSquare.transform.localPosition;
        Vector3 payObjectSquarePosition = offset + payObject.transform.localPosition + payObjectSquare.transform.localPosition;
        Vector3 notorietyObjectSquarePosition = offset + notorietyObject.transform.localPosition + notorietyObjectSquare.transform.localPosition;
        Vector3 waitObjectSquarePosition = offset + waitObject.transform.localPosition + waitObjectSquare.transform.localPosition;
        Vector3 philObjectSquarePosition = offset + philObject.transform.localPosition + philObjectSquare.transform.localPosition;



        //Debug.Log("This is the offset: " + offset.y);
        //Debug.Log("Age Object Square is at: " + ageObjectSquarePosition.y);
        //Debug.Log("Pay Object Square is at: " + payObjectSquarePosition.y);
        float agePosition = ageObjectSquarePosition.y - ((ageObjectSquarePosition.y - payObjectSquarePosition.y) / 2) + yScale;
        float payPosition = payObjectSquarePosition.y - ((payObjectSquarePosition.y - notorietyObjectSquarePosition.y)/2);
        //Debug.Log("This is the ageObjectSquarePositionVector " + ageObjectSquarePosition);
        Debug.Log("This is the payObjectSquarePositionVector " + payObjectSquarePosition);
        Debug.Log("This is the notorietyObjectSquarePositionVector " + notorietyObjectSquarePosition);
        Debug.Log("This is the waitObjectSquarePositionVector " + waitObjectSquarePosition);

        float notorietyPosition = notorietyObjectSquarePosition.y - ((notorietyObjectSquarePosition.y - waitObjectSquarePosition.y) / 2) - yScale/2 - yScale;
        Debug.Log("This is notorietyPosition: " + notorietyPosition);

        float waitPosition = waitObjectSquarePosition.y - ((waitObjectSquarePosition.y - philObjectSquarePosition.y) / 2);

        //barChart.transform.SetParent(ageObject.transform);
        //barChart.transform.position = new Vector3(-3, -5, 0);
        //float squareY = agePosition;

        GameObject ageChart = new GameObject("Age Chart");
        GameObject payChart = new GameObject("Pay Chart");
        GameObject notorietyChart = new GameObject("Notoriety Chart");
        GameObject waitChart = new GameObject("Wait Chart");

        GameObject ageYoungestText = ageObject.transform.Find("Youngest Data").gameObject;
        

        makeCategoryChart(ageObject, ageCategory, ageChart, ageYoungestText.transform.position.y, yScale, colorTracker);
        colorTracker = 0;
        //squareY = 0;
        makeCategoryChart(payObject, incomeCategory, payChart, payPosition, yScale, colorTracker);
        makeCategoryChart(notorietyObject, knownCategory, notorietyChart, notorietyPosition, yScale, colorTracker);
        makeCategoryChart(waitObject, waitCategory, waitChart, waitPosition, yScale, colorTracker);



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

    public void makeCategoryChart(GameObject parentObject, ArrayList category, GameObject chart, float chartYPosition, float yScale, int colorTracker)
    {
        chart.transform.SetParent(parentObject.transform);
        float squareY = 0;
        foreach (int tracker in category)
        {
            GameObject square = new GameObject("Bar");
            square.transform.SetParent(chart.transform);
            float squareX = 0.5f * (tracker - 1);
            square.transform.position = new Vector3(squareX, squareY, 0);

            squareY = squareY - yScale;

            SpriteRenderer squareRenderer = square.AddComponent<SpriteRenderer>();
            squareRenderer.sprite = bar;
            if (colorTracker == 0)
            {
                squareRenderer.color = Color.red;
                colorTracker++;
            }
            else if (colorTracker == 1)
            {
                squareRenderer.color = Color.green;
                colorTracker++;
            }
            else
            {
                squareRenderer.color = Color.gray;
            }
            squareRenderer.sortingLayerName = "Testing Layer";
            square.transform.localScale = new Vector3(tracker, yScale, 1);

            //Debug.Log("This is the position of this square: " + square.transform.position
        }
        chart.transform.localPosition = new Vector3(0, chartYPosition, 0);
        //Debug.Log("This is the chartYPosition " + chartYPosition);
        //Debug.Log("This is the chart's transform: " + chart.transform.position);
    }
}

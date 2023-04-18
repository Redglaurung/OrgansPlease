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



        float yScale = 0.5f;


        GameObject ageObject = GameObject.Find("Age");
        GameObject payObject = GameObject.Find("Pay");
        GameObject notorietyObject = GameObject.Find("Notoriety");
        GameObject waitObject = GameObject.Find("Waitlist");
        GameObject philObject = GameObject.Find("Philanthropy");

        string barLayer = "Default";

        // Age Bar Chart
        GameObject ageOldest = ageObject.transform.Find("Oldest").gameObject;
        GameObject ageOldestDataBox = ageOldest.transform.Find("Oldest Data").gameObject;
        GameObject ageOldestBar = ageOldest.transform.Find("Bar").gameObject;

        SpriteRenderer oldestRenderer = ageOldestBar.AddComponent<SpriteRenderer>();
        oldestRenderer.sprite = bar;
        oldestRenderer.sortingLayerName = barLayer;

        oldestRenderer.color = Color.red;
        ageOldestBar.transform.localScale = new Vector3(oldest, yScale, 0);
        ageOldestBar.transform.position = new Vector3(0.5f * (oldest - 1), ageOldestDataBox.transform.position.y, 0);

        GameObject ageYoungest = ageObject.transform.Find("Youngest").gameObject;
        GameObject ageYoungestDataBox = ageYoungest.transform.Find("Youngest Data").gameObject;
        GameObject ageYoungestBar = ageYoungest.transform.Find("Bar").gameObject;

        SpriteRenderer youngestRenderer = ageYoungestBar.AddComponent<SpriteRenderer>();
        youngestRenderer.sprite = bar;
        youngestRenderer.color = Color.green;
        youngestRenderer.sortingLayerName = barLayer;

        ageYoungestBar.transform.localScale = new Vector3(youngest, yScale, 0);
        ageYoungestBar.transform.position = new Vector3(0.5f * (youngest - 1), ageYoungestDataBox.transform.position.y, 0);


        GameObject ageNeither = ageObject.transform.Find("Neither").gameObject;
        GameObject ageNeitherDataBox = ageNeither.transform.Find("AgeNeither Data").gameObject;
        GameObject ageNeitherBar = ageNeither.transform.Find("Bar").gameObject;

        SpriteRenderer neitherRenderer = ageNeitherBar.AddComponent<SpriteRenderer>();
        neitherRenderer.sprite = bar;
        neitherRenderer.color = Color.grey;
        neitherRenderer.sortingLayerName = barLayer;

        ageNeitherBar.transform.localScale = new Vector3(neitherAge, yScale, 0);
        ageNeitherBar.transform.position = new Vector3(0.5f * (neitherAge - 1), ageNeitherDataBox.transform.position.y, 0);

        // Pay Bar Chart
        GameObject payHigh = payObject.transform.Find("HighPay").gameObject;
        GameObject payHighData = payHigh.transform.Find("HighPay Data").gameObject;
        GameObject payHighBar = payHigh.transform.Find("Bar").gameObject;

        SpriteRenderer payHighRenderer = payHighBar.AddComponent<SpriteRenderer>();
        payHighRenderer.sprite = bar;
        payHighRenderer.color = Color.red;
        payHighRenderer.sortingLayerName = barLayer;

        payHighBar.transform.localScale = new Vector3(highestIncome, yScale, 0);
        payHighBar.transform.position = new Vector3(0.5f * (highestIncome - 1), payHighData.transform.position.y, 0);

        GameObject payLow = payObject.transform.Find("LowPay").gameObject;
        GameObject payLowData = payLow.transform.Find("LowPay Data").gameObject;
        GameObject payLowBar = payLow.transform.Find("Bar").gameObject;

        SpriteRenderer payLowRenderer = payLowBar.AddComponent<SpriteRenderer>();
        payLowRenderer.sprite = bar;
        payLowRenderer.color = Color.green;
        payLowRenderer.sortingLayerName = barLayer;

        payLowBar.transform.localScale = new Vector3(lowestIncome, yScale, 0);
        payLowBar.transform.position = new Vector3(0.5f * (lowestIncome - 1), payLowData.transform.position.y, 0);

        GameObject payNeither = payObject.transform.Find("NeitherPay").gameObject;
        GameObject payNeitherData = payNeither.transform.Find("PayNeither Data").gameObject;
        GameObject payNeitherBar = payNeither.transform.Find("Bar").gameObject;

        SpriteRenderer payNeitherRenderer = payNeitherBar.AddComponent<SpriteRenderer>();
        payNeitherRenderer.sprite = bar;
        payNeitherRenderer.color = Color.gray;
        payNeitherRenderer.sortingLayerName = barLayer;

        payNeitherBar.transform.localScale = new Vector3(neitherIncome, yScale, 0);
        payNeitherBar.transform.position = new Vector3(0.5f * (neitherIncome - 1), payNeitherData.transform.position.y, 0);


        // Notoriety Bar Chart
        GameObject notoWell = notorietyObject.transform.Find("WellKnown").gameObject;
        GameObject notoWellData = notoWell.transform.Find("WellKnown Data").gameObject;
        GameObject notoWellBar = notoWell.transform.Find("Bar").gameObject;

        SpriteRenderer notoWellRenderer = notoWellBar.AddComponent<SpriteRenderer>();
        notoWellRenderer.sprite = bar;
        notoWellRenderer.color = Color.red;
        notoWellRenderer.sortingLayerName = barLayer;

        notoWellBar.transform.localScale = new Vector3(wellKnown, yScale, 0);
        notoWellBar.transform.position = new Vector3(0.5f * (wellKnown - 1), notoWellData.transform.position.y, 0);

        GameObject notoLeast = notorietyObject.transform.Find("Obscure").gameObject;
        GameObject notoLeastData = notoLeast.transform.Find("Obscure Data").gameObject;
        GameObject notoLeastBar = notoLeast.transform.Find("Bar").gameObject;

        SpriteRenderer notoLeastRenderer = notoLeastBar.AddComponent<SpriteRenderer>();
        notoLeastRenderer.sprite = bar;
        notoLeastRenderer.color = Color.green;
        notoLeastRenderer.sortingLayerName = barLayer;

        notoLeastBar.transform.localScale = new Vector3(notKnown, yScale, 0);
        notoLeastBar.transform.position = new Vector3(0.5f * (notKnown - 1), notoLeastData.transform.position.y, 0);

        // Waitlist Bar Chart

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

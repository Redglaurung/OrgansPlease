using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrackingScript : MonoBehaviour
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

    int currLevel = 1;

    int oldest = 0;
    int youngest = 0;
    int highestIncome = 0;
    int lowestIncome = 0;
    int neitherIncome = 0;
    int notKnown = 0;
    int midKnown = 0;
    int wellKnown = 0;
    int noGood = 0;
    int potGood = 0;
    int guarGood = 0;
    int longWait = 0;
    int shortWait = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject[] papers = GameObject.FindGameObjectsWithTag("Pages");
        //foreach (GameObject paper in papers) {
        //    if (paper.)
        //}
    }

    // If something is stamped add it to the count according to the page content.
    // If GameObject's name is Paper1, then change using Esmeralda's points
    // If GameObject'2 name is Paper2, then change using Jinnie's points, etc.


}

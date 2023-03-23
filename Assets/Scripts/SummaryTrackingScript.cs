using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    CharacterTrackingScript character;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<CharacterTrackingScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }
    }
}

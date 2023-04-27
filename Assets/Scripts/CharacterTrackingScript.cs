using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTrackingScript : MonoBehaviour
{
    SummaryTrackingScript summary;
    private bool day1Chosen = false;
    private bool day2Chosen = false;
    private bool day4Chosen = false;
    private bool day5Chosen = false;
    private bool day6Chosen = false;

    // Start is called before the first frame update
    void Start()
    {
        summary = gameObject.GetComponent<SummaryTrackingScript>();
    }

    // Update is called once per frame
    void Update()
    {

        // So long as no paper has been chosen/stamped, loop through all the papers
            // If GameObject's name is Paper1, then change using Esmeralda's data
            // If GameObject'2 name is Paper2, then change using Jinnie's data, etc.

        // Once one paper has been chosen/stamped, this level is over.


        GameObject[] papers = GameObject.FindGameObjectsWithTag("Pages");

        if (SceneManager.GetActiveScene().name == "Day1")
        {
            if (day1Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day1Chosen = true;
                        if (paper.name == "Paper1") // Esmeralda
                        {
                            summary.oldest += 1;
                            summary.neitherIncome += 1;
                            summary.midKnown += 1;
                            summary.potGood += 1;
                            summary.longWait += 1;
                        }

                        if (paper.name == "Paper2")     // Jinnie
                        {
                            summary.youngest += 1;
                            summary.lowestIncome += 1;
                            summary.notKnown += 1;
                            summary.noGood += 1;
                            summary.shortWait += 1;
                        }

                        if (paper.name == "Paper3") // Mathias
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.wellKnown += 1;
                            summary.guarGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper4") // Jack
                        {
                            summary.neitherAge += 1;
                            summary.highestIncome += 1;
                            summary.wellKnown += 1;
                            summary.noGood += 1;
                            summary.longWait += 1;
                        }
                    }
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Day2")
        {
            if (day2Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day2Chosen = true;
                        if (paper.name == "Paper1") // Dominik Fyodor
                        {
                            summary.youngest += 1;
                            summary.lowestIncome += 1;
                            summary.notKnown += 1;
                            summary.noGood += 1;
                            summary.shortWait += 1;
                        }

                        if (paper.name == "Paper2")     // Daniela Rodriguez
                        {
                            summary.oldest += 1;
                            summary.lowestIncome += 1;
                            summary.midKnown += 1;
                            summary.guarGood += 1;
                            summary.longWait += 1;
                        }

                        if (paper.name == "Paper3") // Kaya Lindiwe
                        {
                            summary.neitherAge += 1;
                            summary.highestIncome += 1;
                            summary.notKnown += 1;
                            summary.guarGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper4") // Alicia De'Ver
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.wellKnown += 1;
                            summary.potGood += 1;
                            summary.neitherWait += 1;
                        }
                    }
                }
            }
        }

if (SceneManager.GetActiveScene().name == "Day4")
        {
            if (day2Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day2Chosen = true;
                        if (paper.name == "Paper1") // Alice Lee
                        {
                            summary.neitherAge += 1;
                            summary.lowestIncome += 1;
                            summary.notKnown += 1;
                            summary.guarGood += 1;
                            summary.shortWait += 1;
                        }

                        if (paper.name == "Paper2")     // Jay Allen
                        {
                            summary.oldest += 1;
                            summary.highestIncome += 1;
                            summary.midKnown += 1;
                            summary.potGood += 1;
                            summary.longWait += 1;
                        }

                        if (paper.name == "Paper3") // Rob Green
                        {
                            summary.youngest += 1;
                            summary.neitherIncome += 1;
                            summary.notKnown += 1;
                            summary.guarGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper4") // Marta Gomez
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.wellKnown += 1;
                            summary.noGood += 1;
                            summary.neitherWait += 1;
                        }
                    }
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Day5")
        {
            if (day5Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day5Chosen = true;
                        if (paper.name == "Paper1") // Nawel Berkowitz
                        {
                            summary.youngest += 1;
                            summary.lowestIncome += 1;
                            summary.midKnown += 1;
                            summary.noGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper2")     // Hana Yoon
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.midKnown += 1;
                            summary.guarGood += 1;
                            summary.shortWait += 1;
                        }

                        if (paper.name == "Paper3") // Ariel Cilenti
                        {
                            summary.oldest += 1;
                            summary.highestIncome += 1;
                            summary.wellKnown += 1;
                            summary.noGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper4") // Theo Gerhardt
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.notKnown += 1;
                            summary.guarGood += 1;
                            summary.longWait += 1;
                        }
                    }
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Day6")
        {
            if (day6Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day6Chosen = true;
                        if (paper.name == "Paper1") // Eleanor Swan
                        {
                            summary.youngest += 1;
                            summary.neitherIncome += 1;
                            summary.notKnown += 1;
                            summary.potGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper2")     // Geralt Erikson
                        {
                            summary.neitherAge += 1;
                            summary.highestIncome += 1;
                            summary.midKnown += 1;
                            summary.noGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper3") // Zoey Marshall
                        {
                            summary.oldest += 1;
                            summary.lowestIncome += 1;
                            summary.wellKnown += 1;
                            summary.guarGood += 1;
                            summary.longWait += 1;
                        }

                        if (paper.name == "Paper4") // Nina Nguyen
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.wellKnown += 1;
                            summary.guarGood += 1;
                            summary.shortWait += 1;
                        }
                    }
                }
            }
        }
    }

    public bool isChosen()
    {
        if (SceneManager.GetActiveScene().name == "Day1")
        {
            return day1Chosen;
        }
        
        if (SceneManager.GetActiveScene().name == "Day2")
        {
            return day2Chosen;
        }
        if (SceneManager.GetActiveScene().name == "Day4")
        {
            return day4Chosen;
        }
        if (SceneManager.GetActiveScene().name == "Day5")
        {
            return day5Chosen;
        }
        if (SceneManager.GetActiveScene().name == "Day6")
        {
            return day6Chosen;
        }
        return false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTrackingScript : MonoBehaviour
{
    //Tracks which days have been resolved
    SummaryTrackingScript summary;
    private bool day1Chosen = false;
    private bool day2Chosen = false;
    private bool day3Chosen = false;
    private bool day4Chosen = false;
    private bool day5Chosen = false;
    private bool day6Chosen = false;

    // Start is called before the first frame update
    void Start()
    {
        summary = gameObject.GetComponent<SummaryTrackingScript>();
    }

    /**
     * Update is called once per frame.
     * Check the name of the day and for that day if no one has been selected
     * yet, keep checking all the papers to check if the player selected a paper.
     * Once a paper is selected, we consider that day to be chosen. Then check
     * which paper was selected and increment the associated counter variables.
     */
    void Update()
    {
        GameObject[] papers = GameObject.FindGameObjectsWithTag("Pages");

        /** Day 1 */
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

        /** Day 2 */
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

        /** Day 3 */
        if (SceneManager.GetActiveScene().name == "Day3")
        {
            if (day3Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day3Chosen = true;
                        if (paper.name == "Paper1") // Tony
                        {
                            summary.youngest += 1;
                            summary.neitherIncome += 1;
                            summary.midKnown += 1;
                            summary.noGood += 1;
                            summary.shortWait += 1;
                        }

                        if (paper.name == "Paper2")     // Damon
                        {
                            summary.neitherAge += 1;
                            summary.lowestIncome += 1;
                            summary.notKnown += 1;
                            summary.potGood += 1;
                            summary.neitherWait += 1;
                        }

                        if (paper.name == "Paper3") // Dexter
                        {
                            summary.oldest += 1;
                            summary.highestIncome += 1;
                            summary.wellKnown += 1;
                            summary.guarGood += 1;
                            summary.longWait += 1;
                        }

                        if (paper.name == "Paper4") // Tina
                        {
                            summary.neitherAge += 1;
                            summary.neitherIncome += 1;
                            summary.midKnown += 1;
                            summary.guarGood += 1;
                            summary.neitherWait += 1;
                        }
                    }
                }
            }
        }

        /** Day 4 */
        if (SceneManager.GetActiveScene().name == "Day4")
        {
            if (day4Chosen == false)
            {
                foreach (GameObject paper in papers)
                {
                    Pages paperScript = paper.GetComponent<Pages>();
                    if (paperScript.isStamped)
                    {
                        day4Chosen = true;
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

        /** Day 5 */
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

        /** Day 6 */
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


    //Called when a paper is stamped, and sets the chosen day to be marked.
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
        if (SceneManager.GetActiveScene().name == "Day3")
        {
            return day3Chosen;
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

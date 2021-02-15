using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[,] buttons = new GameObject[3, 3];
    public GameObject button;
    public RectTransform tableTransform;
    public bool Player1Move;
    public bool gameFinished;
    void Start()
    {
        gameFinished = false;
        Player1Move = true;
        CreateTable();
    }

    void CreateTable()
    {
        GameObject createdObj;
        Vector3 pozitie = new Vector3(50, 0, 0);

        for (int i = 0; i < 3; i++)
        {
            createdObj = Instantiate(button, tableTransform.transform);
            createdObj.GetComponent<RectTransform>().anchoredPosition = pozitie;
            buttons[0, i] = createdObj;
            pozitie.x += 100;
        }
        pozitie = new Vector3(50, -100, 0);
        for (int i = 0; i < 3; i++)
        {
            createdObj = Instantiate(button, tableTransform.transform);
            createdObj.GetComponent<RectTransform>().anchoredPosition = pozitie;
            buttons[1, i] = createdObj;
            pozitie.x += 100;
        }

        pozitie = new Vector3(50, -200, 0);
        for (int i = 0; i < 3; i++)
        {
            createdObj = Instantiate(button, tableTransform.transform);
            createdObj.GetComponent<RectTransform>().anchoredPosition = pozitie;
            buttons[2, i] = createdObj;
            pozitie.x += 100;
        }
    }

    public bool GameOver()
    {

        //parcurgere pentru fiecare linie
        for (int i = 0; i < 3; i++)
        {
            bool line_i_full_of_X = true;
            bool line_i_full_of_O = true;
            for (int j = 0; j < 3; j++)
            {
                int x_puted = buttons[i, j].GetComponent<ButtonController>().whatIsPutted;
                if(x_puted == 0)
                {
                    line_i_full_of_X = false;
                    line_i_full_of_O = false;
                }

                if(x_puted == 1)
                    line_i_full_of_O = false;

                if (x_puted == 2)
                    line_i_full_of_X = false;
            } 

            if (line_i_full_of_O || line_i_full_of_X)
                return true;
        }

        for(int i = 0; i < 3; i++)
        {
            bool column_i_full_of_X = true;
            bool column_i_full_of_O = true;

            for(int j = 0;j < 3; j++)
            {
                int x_puted = buttons[j, i].GetComponent<ButtonController>().whatIsPutted;

                if (x_puted == 0)
                {
                    column_i_full_of_X = false;
                    column_i_full_of_O = false;
                }

                if (x_puted == 1)
                    column_i_full_of_O = false;

                if (x_puted == 2)
                    column_i_full_of_X = false;
            }
            if (column_i_full_of_O || column_i_full_of_X)
                return true;
        }
        bool diagonal_full_of_X = true;
        bool diagonal_full_of_O = true;
        for (int i=0;i<3;i++)
        {
            int x_puted = buttons[i, i].GetComponent<ButtonController>().whatIsPutted;

            if (x_puted == 0)
            {
                diagonal_full_of_X = false;
                diagonal_full_of_O = false;
            } 

            if (x_puted == 1)
                diagonal_full_of_O = false;

            if (x_puted == 2)
                diagonal_full_of_X = false;
        }
        
        if (diagonal_full_of_O || diagonal_full_of_X)
            return true;

        diagonal_full_of_X = true;
        diagonal_full_of_O = true;

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (i + j == 2)
                {
                    int x_puted = buttons[i, j].GetComponent<ButtonController>().whatIsPutted;

                    if (x_puted == 0)
                    {
                        diagonal_full_of_X = false;
                        diagonal_full_of_O = false;
                    }

                    if (x_puted == 1)
                        diagonal_full_of_O = false;

                    if (x_puted == 2)
                        diagonal_full_of_X = false;
                }

        if (diagonal_full_of_O || diagonal_full_of_X)
            return true;

        
        return false;
    }

    public bool NobodyCanWon()
    {
        
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (buttons[i, j].GetComponent<ButtonController>().whatIsPutted == 0)
                    return false;
       
        return true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite xImage;
    public Sprite oImage;
    private bool canBeChanged;
    public int whatIsPutted; //1-x has been puted, 2 - 0 has been puted, 0 - not x or y has been puted
    void Start()
    {
        canBeChanged = true;
        whatIsPutted = 0;
    }

    public void AddXorY()
    {
        if (canBeChanged == true && GameObject.Find("GameManager").GetComponent<GameManager>().gameFinished == false)
        {
            bool whoMoves = GameObject.Find("GameManager").GetComponent<GameManager>().Player1Move;
            if (whoMoves == true)//player 1 is moving
            {
                this.gameObject.GetComponent<Image>().sprite = xImage;
                whatIsPutted = 1;

                bool gameOver = GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();

                if(gameOver == true)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().winner = 1;
                    GameObject.Find("GameOverStatus").GetComponent<Text>().text = "Player X has WON!";
                    GameObject.Find("GameManager").GetComponent<GameManager>().gameFinished = true;
                    GameObject.Find("GameManager").GetComponent<GameManager>().AnimateWinner();
                }
                else
                {
                    bool nobodyCanWon = GameObject.Find("GameManager").GetComponent<GameManager>().NobodyCanWon();
                
                    if(nobodyCanWon == true)
                    {
                        GameObject.Find("GameManager").GetComponent<GameManager>().winner = 0;
                        GameObject.Find("GameManager").GetComponent<GameManager>().gameFinished = true;
                        GameObject.Find("GameOverStatus").GetComponent<Text>().text = "Nobody has WON!";
                     
                    }

                }

                whoMoves = false;
                
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = oImage;
                whatIsPutted = 2;

                bool gameOver = GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();

                if (gameOver == true)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().winner = 2;
                    GameObject.Find("GameOverStatus").GetComponent<Text>().text = "Player 0 has WON!";
                    GameObject.Find("GameManager").GetComponent<GameManager>().gameFinished = true;
                    GameObject.Find("GameManager").GetComponent<GameManager>().AnimateWinner();
                }

                bool nobodyCanWon = GameObject.Find("GameManager").GetComponent<GameManager>().NobodyCanWon();

                if (nobodyCanWon == true)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().winner = 0;
                    GameObject.Find("GameManager").GetComponent<GameManager>().gameFinished = true;
                    GameObject.Find("GameOverStatus").GetComponent<Text>().text = "Nobody has WON!";
                    
                }


                whoMoves = true;
               
            }

            canBeChanged = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().Player1Move = whoMoves;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

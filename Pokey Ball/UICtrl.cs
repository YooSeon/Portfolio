using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UICtrl : MonoBehaviour
{
    public Text NowLevelText;
    public Text NextLevelText;
    public Text ScoreText;
    public Text CoinText;
    public Image CoinImage;
    public Text GetScore;

    public Image filled;

    int nextLevel;


    public bool viewCoin;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel = GameManager.instance.level + 1;

        viewCoin = false;
    }

    // Update is called once per frame
    void Update()
    {
        NowLevelText.text = GameManager.instance.level.ToString();
        NextLevelText.text = nextLevel.ToString();
        ScoreText.text = GameManager.instance.Score.ToString();
        CoinText.text = GameManager.instance.coin.ToString();
        GetScore.text = "+"+GameManager.instance.getScore.ToString();

        if (GameManager.instance.showScore)
        {
            StartCoroutine(ShowScore());
        }
        if(viewCoin)
        {
            CoinText.enabled = true;
            CoinImage.enabled = true;
            Invoke("ShowCoin", 1.0f);
        }

        filledNextLevel();
    }

    IEnumerator ShowScore()
    {
        GetScore.color = new Color(1, 1, 1, 1);
        float alp = 1;

        while (alp >= 0)
        {
            alp -= 1.5f * Time.deltaTime;
            GetScore.color = new Color(1, 1, 1, alp);
            yield return null;
        }
        GameManager.instance.showScore = false;
    }

    void ShowCoin()
    {
        CoinText.enabled = false;
        CoinImage.enabled = false;
        viewCoin = false;
    }

    void filledNextLevel()
    {
        float Dist = (GameObject.Find("Player").GetComponent<Transform>().position.y - 1.4f)/GameObject.Find("EndLine").GetComponent<Transform>().position.y; 

        filled.fillAmount = Dist;
        
    }


}

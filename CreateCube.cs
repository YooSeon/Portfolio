using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CreateCube : MonoBehaviour
{
    bool create = true;
    public List<ST_LEVEL_DATA> listLevelData;

    public float missingTime;
    public float clearTime;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject final;

    public Text text;
    public Text time;

    //5.2

    private void Awake()
    {
        listLevelData = GameObject.Find("GameManager").GetComponent<LevelCtrl>().listLevelData;

        int Level = GameObject.Find("GameManager").GetComponent<Distroy>().level;

        if (create)
        {
            for(int i=0;i<listLevelData.Count;i++)
            {
                if(Level == listLevelData[i].LEVEL)
                {
                    float floorSize = Random.Range(listLevelData[i].FLOORMIN,listLevelData[i].FLOORMAX);          
                    int holes = Random.Range(listLevelData[i].HOLEMIN, listLevelData[i].HOLEMAX);
                    int hole = 0;

                    for (int j=0;j<floorSize + holes+1;j++)
                    {
                        float hight = Random.Range(listLevelData[i].HEIGHTMIN, listLevelData[i].HEIGHTMAX);
                        int trueHole = Random.Range(0, 2);  

                        if (j < floorSize + holes)
                        {
                            if (hole < holes && j != 0)
                            {
                                if (trueHole == 0)
                                {
                                    hole++;
                                    continue;
                                }
                            }
                                                       
                            int cube = Random.Range(0, 3);

                            if (cube == 0) { Instantiate(cube1, new Vector3(5.2f * (j + 1), hight), Quaternion.Euler(-90f, 0, 0)); }
                            else if (cube == 1) { Instantiate(cube2, new Vector3(5.2f * (j + 1), hight), Quaternion.Euler(-90f, 0, 0)); }
                            else if (cube == 2) { Instantiate(cube3, new Vector3(5.2f * (j + 1), hight), Quaternion.Euler(-90f, 0, 0)); }                           
                        }
                        else if(j == floorSize + holes)
                        {
                           Instantiate(final, new Vector3(5.2f * (j + 1), hight), Quaternion.Euler(-90f, 0, 0));                            
                        }

                    }

                    clearTime = listLevelData[i].TIME;
                    missingTime = listLevelData[i].MTIME;
                }
            }

            create = false;
        }

        text.text = "LEVEL : " + Level;
        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clearTime -= Time.deltaTime;
        time.text = "TIME : " + clearTime.ToString("N2");

        if(clearTime < 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

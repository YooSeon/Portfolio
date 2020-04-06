using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ST_LEVEL_DATA
{
    public int LEVEL;
    public float TIME;
    public int FLOORMIN;
    public int FLOORMAX;
    public int HOLEMIN;
    public int HOLEMAX;
    public int HEIGHTMIN;
    public int HEIGHTMAX;
    public float MTIME;
}


public class LevelCtrl : MonoBehaviour
{

    public TextAsset levelData;
    public List<ST_LEVEL_DATA> listLevelData = new List<ST_LEVEL_DATA>();


    void Start()
    {
        LoadDate();
    }

    void LoadDate()
    {
        string text = levelData.text;

        string[] lines = text.Split('\n');

        foreach(var line in lines)
        {
            if (line == "") continue;
            ST_LEVEL_DATA data = new ST_LEVEL_DATA();

            string[] words = line.Split('\t');
            int index = 0;            
            foreach(var word in words)
            {
                if (word == "") continue;
                if (word[0] == '#') break;

                switch(index)
                {
                    case 0:
                        data.LEVEL = int.Parse(word);
                        break;
                    case 1:
                        data.TIME = float.Parse(word);
                        break;
                    case 2:
                        data.FLOORMIN = int.Parse(word);
                        break;
                    case 3:
                        data.FLOORMAX = int.Parse(word);
                        break;
                    case 4:
                        data.HOLEMIN = int.Parse(word);
                        break;
                    case 5:
                        data.HOLEMAX = int.Parse(word);
                        break;
                    case 6:
                        data.HEIGHTMIN = int.Parse(word);
                        break;
                    case 7:
                        data.HEIGHTMAX = int.Parse(word);
                        break;
                    case 8:
                        data.MTIME = float.Parse(word);
                        break;                       
                }
                index++;
            }

            if(index >8)
            {
                index = 0;
                listLevelData.Add(data);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public Color unitColor;

    private void Awake()
    {
        //makes sure that there is always one game manager
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        //setting ourselves as the instance
        Instance = this;

        //makes sure that the current game object is not destroyed when you load another scene
        DontDestroyOnLoad(gameObject);

        //Debug.Log(Application.persistentDataPath + "/savefile.json");

        loadColor();
    }

    [System.Serializable]
    class saveData
    {
        public Color _unitColor;
    }

    public void saveColor()
    {
        saveData data = new saveData();
        data._unitColor = unitColor;

        //converts our data to a json file (serialising)
        string jsonData = JsonUtility.ToJson(data);

        //saves json file to the memory
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);

    }

    public void loadColor()
    {
        //gets the json file from a persistent data path and converts it into a string
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");

        //converts the string into unity readable data (deserialising)
        saveData data = JsonUtility.FromJson<saveData>(jsonData);

        //applies that data to the game manager
        unitColor = data._unitColor;
    }
}

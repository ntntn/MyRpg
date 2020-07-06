using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        var gos = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
    }

    public void Save()
    {
        Debug.Log("saved");
        SaveGame.Save<GameObject[]>("objects", objects);
    }

    public void Load()
    {
        Debug.Log("loaded");
        objects = SaveGame.Load<GameObject[]>("objects");
        foreach (var o in objects)
        {
            GameObject.Instantiate(o);
        }
    }



    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.O))
        {
            Save();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            Load();
        }*/
    }
}

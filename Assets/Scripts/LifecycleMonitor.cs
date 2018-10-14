using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LifecycleMonitor : MonoBehaviour {

    public GameObject counterState;

	// Use this for initialization
	void Start () {
        Debug.Log("Start");

        // don't load state here - we also get unpaused and we load it there..
	}
	
    void OnApplicationPause(bool paused)
    {
        Debug.Log("Pause " + paused);
        if (paused)
            SaveState();
        else
            LoadState();          
    }

    void OnApplicationQuit()
    {
        Debug.Log("Quit");
        SaveState();
    }

    void OnDisable()
    {
        Debug.Log("Disable");
    }

    void OnEnable()
    {
        Debug.Log("Enable");
    }

    void SaveState()
    {
        ClickHandler ch = counterState.GetComponent<ClickHandler>();
        int toSave = ch.GetCounter();

        Debug.Log("Saving " + toSave);

        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, toSave);
        file.Close();
    }

    void LoadState()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        int loaded = (int)bf.Deserialize(file);
        file.Close();

        Debug.Log("Loading " + loaded);
        ClickHandler ch = counterState.GetComponent<ClickHandler>();
        ch.SetCounter(loaded);
    }
}

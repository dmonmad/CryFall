using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour{



    public string[] scenes;
    static int selector = 1;
    public TextMeshProUGUI displayText;

    public void Awake()
    {
        
    }

    private void Start()
    {
        int sceneNumber = SceneManager.sceneCountInBuildSettings;
        scenes = new string[sceneNumber];
        for (int i = 0; i < sceneNumber; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
        displayText.SetText(scenes[1]);
    }

    public void NextLevel()
    {
        
        if (selector + 1 == scenes.Length )
        {
            selector = 1;
        }
        else if(selector + 1 < scenes.Length)
        {
            selector++;
        }
        Debug.Log(scenes[selector]);

        displayText.SetText(scenes[selector]);

    }

    public void BackLevel()
    {
        if (selector - 1 == 0)
        {
            selector = 1;
        }
        else if (selector - 1 > 0)
        {
            selector--;
        }
        Debug.Log(scenes[selector]);

        displayText.SetText(scenes[selector]);
    }

    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene(this.scenes[selector]);
    }
}

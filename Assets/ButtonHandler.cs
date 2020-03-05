using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour{
    static int selector = 0;
    public void NivelDerecha()
    {

        if (selector < SceneManager.sceneCountInBuildSettings)
        {
            selector++;
            TextMeshProUGUI t = GameObject.Find("Canvas/NivelText").GetComponent<TextMeshProUGUI>();
            t.SetText(SceneManager.GetSceneAt(selector).name);
        }

    }

    public void NivelIzquierda()
    {
        if (selector > 0)
        {
            selector--;
            TextMeshProUGUI t = GameObject.Find("Canvas/NivelText").GetComponent<TextMeshProUGUI>();
            t.SetText(SceneManager.GetSceneAt(selector).name);
        }
    }
}

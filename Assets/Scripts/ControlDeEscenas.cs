using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeEscenas : MonoBehaviour
{
    public void cambiarEscena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void salirJuego()
    {
        Application.Quit();
    }
}

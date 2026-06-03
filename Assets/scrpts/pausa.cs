using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject objetoMenuPausa;
    public static bool juegoPausado = false;

    void Start()
    {
        // Esto asegura que al cargar la escena, el tiempo corra
        Time.timeScale = 1f;
        juegoPausado = false;

        // Esto apaga el menú visualmente apenas inicia la escena
        if (objetoMenuPausa != null)
        {
            objetoMenuPausa.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                Continuar();
            else
                Pausar();
        }
    }

    public void Continuar()
    {
        objetoMenuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Pausar()
    {
        objetoMenuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReiniciarDesdeElInicio()
    {
        Time.timeScale = 1f;
        juegoPausado = false;
        SceneManager.LoadScene(0);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
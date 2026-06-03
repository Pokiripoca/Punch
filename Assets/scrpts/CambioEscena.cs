using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CammbioEscena: MonoBehaviour
{
    [Header("Lista de niveles en orden")]
    public List<string> niveles; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string escenaActual = SceneManager.GetActiveScene().name;
            int indiceActual = niveles.IndexOf(escenaActual);
            int siguienteIndice = indiceActual + 1;

            if (siguienteIndice < niveles.Count)
            {
                SceneManager.LoadScene(niveles[siguienteIndice]);
            }
            else
            {
                Debug.Log("No hay más niveles en la lista.");
            }
        }
    }
}
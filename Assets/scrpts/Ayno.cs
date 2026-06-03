using UnityEngine;
using UnityEngine.SceneManagement;

public class PlushieGoal : MonoBehaviour
{
    [Header("Nombre de la escena final")]
    public string finalSceneName = "FinalScene"; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(finalSceneName);
        }
    }
}
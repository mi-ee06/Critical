using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Attempting to change scene");
            SceneManager.LoadScene(sceneName);
        }
    }
}

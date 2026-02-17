using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader:MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Button button;
    private string nextScene;

    private void Start()
    {
        toggle.isOn = true;
        toggle.onValueChanged.AddListener(OnToggleChanged);
        button.onClick.AddListener(LoadScene);
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            nextScene = "Tutorial";
        }
        else
        {
            nextScene = "GameScene";
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

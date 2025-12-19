using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int pauseUiIndex;
    [SerializeField] private int gameOverIndex;
    [SerializeField] private BGMManager bgmManager;

    private int enemyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmManager.LoadAllTracks();
        UnPause();
        uiManager.DisableMenus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        uiManager.UIElements[gameOverIndex].SetActive(true);
        for(int i = 0; i < uiManager.UIElements.Length; i++)
        {
            if(i != gameOverIndex)
            {
                uiManager.UIElements[i].SetActive(false);
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        uiManager.UIElements[pauseUiIndex].SetActive(true);
        for(int i = 0; i < uiManager.UIElements.Length; i++)
        {
            if(i != pauseUiIndex)
            {
                uiManager.UIElements[i].SetActive(false);
            }
        }
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        uiManager.UIElements[pauseUiIndex].SetActive(false);
    }
    public void TogglePause()
    {
        if(Time.timeScale == 0f)
        {
            if (!uiManager.UIElements[pauseUiIndex].activeInHierarchy)
            {
                Pause();
            }
            else { UnPause(); }
        }
        else
        {
            Pause();
        }
    }
    public UIManager UIManager
    {
        get { return uiManager; }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class VictoryScreenScript : MonoBehaviour
{
    private UIDocument document;
    private VisualElement container;

    private Button startButton;
    private Button exitButton;

    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private HealthBarUI healthBarUI;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();

        if (document == null)
        {
            Debug.LogError("UIDocument is missing from VictoryScreenUI.");
            return;
        }

        VisualElement root = document.rootVisualElement;

        container = root.Q<VisualElement>("Container");

        // These must match the Name fields in UI Builder
        startButton = root.Q<Button>("StartGameButton");
        exitButton = root.Q<Button>("QuitButton");

        if (container != null)
        {
            container.style.display = DisplayStyle.None;
        }
        else
        {
            Debug.LogError("Container was not found in Victory UI.");
        }

        if (startButton != null)
            startButton.clicked += RestartCurrentLevel;
        else
            Debug.LogError("StartGameButton was not found in Victory UI.");

        if (exitButton != null)
            exitButton.clicked += GoToMainMenu;
        else
            Debug.LogError("QuitButton was not found in Victory UI.");
    }

    private void OnDisable()
    {
        if (startButton != null)
            startButton.clicked -= RestartCurrentLevel;

        if (exitButton != null)
            exitButton.clicked -= GoToMainMenu;
    }

    public void ShowVictoryScreen()
    {
        // Hide the health bar when victory screen appears
        if (healthBarUI != null)
        {
            healthBarUI.HideHealthBar();
        }
        else
        {
            Debug.LogWarning("HealthBarUI is not assigned on VictoryScreenScript.");
        }

        if (container != null)
        {
            container.style.display = DisplayStyle.Flex;
            Time.timeScale = 0f;
        }
    }

    private void RestartCurrentLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
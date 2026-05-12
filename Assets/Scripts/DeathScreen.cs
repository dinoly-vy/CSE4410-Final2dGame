using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DeathScreen : MonoBehaviour
{
    private UIDocument document;
    private VisualElement container;

    private Button startButton;
    private Button exitButton;

    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();

        if (document == null)
        {
            Debug.LogError("UIDocument is missing from DeathScreenUI GameObject.");
            return;
        }

        VisualElement root = document.rootVisualElement;

        container = root.Q<VisualElement>("Container");

        startButton = root.Q<Button>("StartGameButton");
        exitButton = root.Q<Button>("QuitButton");

        if (container != null)
        {
            container.style.display = DisplayStyle.None;
        }
        else
        {
            Debug.LogError("Container was not found. Check the Name field in UI Builder.");
        }

        if (startButton != null)
        {
            startButton.clicked += RestartCurrentLevel;
        }
        else
        {
            Debug.LogError("StartButton was not found. Check the Name field in UI Builder.");
        }

        if (exitButton != null)
        {
            exitButton.clicked += GoToMainMenu;
        }
        else
        {
            Debug.LogError("ExitButton was not found. Check the Name field in UI Builder.");
        }
    }

    private void OnDisable()
    {
        if (startButton != null)
            startButton.clicked -= RestartCurrentLevel;

        if (exitButton != null)
            exitButton.clicked -= GoToMainMenu;
    }

    public void ShowDeathScreen()
    {
        if (container != null)
        {
            container.style.display = DisplayStyle.Flex;
            Time.timeScale = 0f;
        }
    }

    private void RestartCurrentLevel()
    {
        Debug.Log("Restarting current level...");

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToMainMenu()
    {
        Debug.Log("Returning to main menu...");

        Time.timeScale = 1f;

        SceneManager.LoadScene(mainMenuSceneName);
    }
}
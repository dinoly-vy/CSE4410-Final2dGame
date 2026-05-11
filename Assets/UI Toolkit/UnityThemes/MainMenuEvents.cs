using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private UIDocument document;

    private Button startGameButton;
    private Button quitButton;

    [SerializeField] private string gameSceneName = "Level1";

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();

        if (document == null)
        {
            Debug.LogError("UIDocument is missing from this GameObject.");
            return;
        }

        VisualElement root = document.rootVisualElement;

        startGameButton = root.Q<Button>("StartGameButton");
        quitButton = root.Q<Button>("QuitButton");

        if (startGameButton == null)
        {
            Debug.LogError("StartGameButton was not found. Check the Name field in UI Builder.");
            return;
        }

        if (quitButton == null)
        {
            Debug.LogError("QuitButton was not found. Check the Name field in UI Builder.");
            return;
        }

        startGameButton.clicked += StartGame;
        quitButton.clicked += QuitGame;
    }

    private void OnDisable()
    {
        if (startGameButton != null)
            startGameButton.clicked -= StartGame;

        if (quitButton != null)
            quitButton.clicked -= QuitGame;
    }

    private void StartGame()
    {
        Debug.Log("Start button clicked.");
        SceneManager.LoadScene(gameSceneName);
    }

    private void QuitGame()
    {
        Debug.Log("Quit button clicked.");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
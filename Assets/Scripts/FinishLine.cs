using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float transitionDelay = 1f;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered finish trigger: " + collision.gameObject.name);

        if (isTransitioning)
            return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached finish. Loading next level soon.");

            isTransitioning = true;
            StartCoroutine(LoadNextSceneAfterDelay());
        }
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(transitionDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
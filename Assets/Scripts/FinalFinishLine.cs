using System.Collections;
using UnityEngine;

public class FinalFinishLine : MonoBehaviour
{
    [SerializeField] private VictoryScreenScript victoryScreenScript;
    [SerializeField] private float victoryDelay = 1f;

    private bool hasWon = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasWon)
            return;

        if (collision.CompareTag("Player"))
        {
            hasWon = true;
            StartCoroutine(ShowVictoryAfterDelay());
        }
    }

    private IEnumerator ShowVictoryAfterDelay()
    {
        Debug.Log("Player reached final ending floor. Showing victory screen...");

        yield return new WaitForSeconds(victoryDelay);

        if (victoryScreenScript != null)
        {
            victoryScreenScript.ShowVictoryScreen();
        }
        else
        {
            Debug.LogError("VictoryScreenScript is not assigned on FinalFinishLine.");
        }
    }
}
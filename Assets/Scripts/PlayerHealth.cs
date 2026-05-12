using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //script that manages players health points
    //game will freeze when player loses all health
    public int health = 5;

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");

        if (health <= 0)
        {
            Debug.Log("Player has died!");
            //everything stops
            Time.timeScale = 0f;
        }
    }
}

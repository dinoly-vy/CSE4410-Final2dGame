using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    //fields for meteor
    //array for the two different types of meteors that we have
    [SerializeField] private GameObject[] meteors;
    private float spawnWidth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Meteor());
    }

    private IEnumerator Meteor()
    {
        while (true){
                
            //random spawn location
            float randomPos = Random.Range(-spawnWidth / 2, spawnWidth / 2);
            Vector3 spawnLocation = new Vector3(randomPos, 0, 0) + transform.position;

            SpawnMeteor(spawnLocation);

            //wait seconds until new meteor spawns
            yield return new WaitForSeconds(3.0f);
        }
    }

    public GameObject SpawnMeteor(Vector3 position)
    {
        //pick one of the two meteor sprites
        int randomMeteor = Random.Range(0, meteors.Length);

        //spawn object
        GameObject meteorToSpawn = Instantiate(meteors[randomMeteor]);
        meteorToSpawn.transform.position = position;

        return meteorToSpawn;
    }
}

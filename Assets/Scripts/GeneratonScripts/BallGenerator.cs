using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{

    public GameObject[] Spawnables;
    public Vector2 BottomLeft, TopRight;
    public int SpawnablesCount;

    // Start is called before the first frame update
    void Start()
    {
        //Runs for every objekt we whant to spawn within the bounds
        for (int i = 0; i < SpawnablesCount; i++)
        {
            int SpawnablesArrayIndex = Random.Range(0, Spawnables.Length);
            Vector2 pos = new Vector2(Random.Range(BottomLeft.x, TopRight.x),
                Random.Range(BottomLeft.y, TopRight.y));
            GameObject g = Instantiate(Spawnables[SpawnablesArrayIndex], pos, Quaternion.identity);
            g.transform.parent = transform;
        }
    }

 
}

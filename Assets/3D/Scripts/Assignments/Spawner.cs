using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject spawnPrefab; //prefab to spawn
    [SerializeField] KeyCode spawnKey; //key to press
    //
    private void Start()
    {
        //set defaults if there is nothing placed in the inspector
        if (spawnPrefab == null) spawnPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (spawnKey == KeyCode.None) spawnKey = KeyCode.Space;
    }

    void Update()
    {
        if (Input.GetKeyDown(spawnKey)) 
        {
            GameObject.Instantiate(spawnPrefab);
        }
        
    }
}

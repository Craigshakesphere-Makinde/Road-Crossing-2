using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Transform pointSpawn;

    [SerializeField] private float timeSpawn=5f;

    [SerializeField] private float blockLength=50;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", timeSpawn,timeSpawn);
        pointSpawn.position += new Vector3(0, 0, blockLength);
        
    }


    private void Generate()
    {
        int rad= Random.Range(0,blocks.Length);
        Instantiate(blocks[rad], pointSpawn.position , Quaternion.identity);
        pointSpawn.position += new Vector3(0,0,blockLength);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Tilemap tilemap;

    [Range(1, 100)]
    public int NumberOfSheeps;

    public GameObject SpawnCenter;

    public GameObject SheepPrefab;

    public float Radius = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSheeps();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnSheeps()
    {
        for (int i = 0; i < NumberOfSheeps; i++)
        {
            Vector3 pos = Random.insideUnitCircle * Radius;


            var obj = Instantiate(SheepPrefab, SpawnCenter.transform.position + pos, Quaternion.identity, SpawnCenter.transform);
            // Debug.Log(obj);
            obj.transform.parent = SpawnCenter.transform;
        }
    }
}

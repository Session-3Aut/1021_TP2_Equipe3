using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Utilities;
using UnityEngine;

public class SpawnerGenerator : MonoBehaviour
{

     public static SpawnerGenerator Instance{get; private set;}

     [SerializeField] private int numSpawnerPoints = 5;
     [SerializeField] private float minDistance = 2f;
     [SerializeField] private float maxDistance = 5f;
     [SerializeField] private float maxHeight = 2f;


    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
        }
    }

    public void GenerateSpawnerPoints(Vector3 startPosition){
        for(int i = 0; i < numSpawnerPoints; i++){
        GameObject spawnerPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spawnerPoint.name = "SpawnerPoint" + i;
        spawnerPoint.transform.position = GetRandomPosition(startPosition);
        spawnerPoint.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spawnerPoint.GetComponent<Renderer>().material.color = Color.green;
        }

    }
    private Vector3 GetRandomPosition(Vector3 startPosition){
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(0,360) * Mathf.Deg2Rad;
        float x = startPosition.x + distance * Mathf.Cos(angle);
        float y = startPosition.y + Random.Range(0, maxHeight);
        float z = startPosition.z + distance * Mathf.Sin(angle);
        return new Vector3 (x, y, z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject structurePrefab;
    public int cost;

    private Transform player;
    private ResourceController resourceController;

    void Start()
    {
        player = GameObject.Find("IcePlayer").transform;
        resourceController = GameObject.Find("ResourceController").GetComponent<ResourceController>();
    }

    public void Buy()
    {
        Debug.Log("metal: " + resourceController.metal + " cost: " + cost);
        if (resourceController.metal >= cost)
        {
            Debug.Log("bought structure");
            Vector2 spawnPosition = player.position;
            if (spawnPosition != null)
            {
                Instantiate(structurePrefab, spawnPosition, Quaternion.identity);
                resourceController.metal -= cost;
            }
        }
    }
}


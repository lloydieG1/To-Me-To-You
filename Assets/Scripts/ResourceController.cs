using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public int initialMetal;
    public int initialHealJuice;
    public int metalPerSecond;
    public int healJuicePerSecond ;

    [SerializeField] private int metal;
    [SerializeField] private int healJuice;

    private void Start() {
        metal = initialMetal;
        healJuice = initialHealJuice;
    }

    public void MiningMetal()
    {
        Debug.Log("mining metal");
        metal += metalPerSecond;
        Debug.Log(metal);
    }

    public void MiningHealJuice()
    {
        Debug.Log("mining heal juice");
        healJuice += healJuicePerSecond;
        Debug.Log(healJuice);
    }

    public void AddMetal(int amount)
    {
        metal += amount;
    }

    public void AddHealJuice(int amount)
    {
        healJuice += amount;
    }

    public void TakeMetal(int amount)
    {
        metal -= amount;
    }

    public void TakeHealJuice(int amount)
    {
        healJuice -= amount;
    }

}

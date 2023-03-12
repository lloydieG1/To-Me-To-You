using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public int initialMetal;
    public int maxMetal;
    public int initialHealJuice;
    public int maxHealJuice;
    public int metalPerSecond;
    public int healJuicePerSecond ;

    public int metal;
    public int healJuice;

    private void Start() {
        metal = initialMetal;
        healJuice = initialHealJuice;
    }

    public void MiningMetal()
    {
        if(metal <= maxMetal) {
            Debug.Log("mining metal");
            metal += metalPerSecond;
            Debug.Log(metal);
        }
    }

    public void MiningHealJuice()
    {
        if(healJuice <= maxHealJuice) {
            Debug.Log("mining heal juice");
            healJuice += healJuicePerSecond;
            Debug.Log(healJuice);
        }
    }

    public void AddMetal(int amount)
    {
        if(metal <= maxMetal) {
            metal += amount;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public int initialMetal;
    public int maxMetal;
    public int initialHealJuice;
    public int maxHealJuice;

    public int metal;
    public int healJuice;

    private void Start() {
        metal = initialMetal;
        healJuice = initialHealJuice;
    }

    public void AddMetal(int amount)
    {
        Debug.Log("Mined metal: " + amount);
        if(metal <= maxMetal) {
            metal += amount;
        }
    }

    public void AddHealJuice(int amount)
    {
        Debug.Log("Mined heal juice: " + amount);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MetalBar : MonoBehaviour
{
    private Slider slider;

    public GameObject resourceController;


    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = resourceController.GetComponent<ResourceController>().maxMetal;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = resourceController.GetComponent<ResourceController>().metal;
    }
}

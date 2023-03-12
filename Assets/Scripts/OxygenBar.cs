using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    public Image myImage;

    public Sprite[] spriteSheet;
    public int currentIndex = 0;

    void Start()
    {
        // Set the initial sprite
        myImage.sprite = spriteSheet[currentIndex];
    }

    public void ChangeSprite(int index)
    {
        // Set the new sprite
        myImage.sprite = spriteSheet[index];
    }
}

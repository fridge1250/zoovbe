using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartsSystem : MonoBehaviour
{
    public static int health = 3;
    public Image[] hearts;
    public Sprite fulllive;
    public Sprite emtylive;
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emtylive;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fulllive;
        }
    }
}

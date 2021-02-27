using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{
    public static BulletsController instance;

    //public int numOfBulletsType = 4;
    public Sprite[] sprites = new Sprite[4];
    public GameObject[] bulletsPrefab =  new GameObject[4];
    public List<Bullets> bullets = new List<Bullets>();

    void Start()
    {
        instance = this;

        bullets.Add(new Bullets(1, "สลายยาเสพติดประเภท 1", 20, 1, "best bullet forever", sprites[0], bulletsPrefab[0]));
        bullets.Add(new Bullets(2, "สลายยาเสพติดประเภท 2", 20, 1, "boom", sprites[1], bulletsPrefab[1]));

        Debug.Log(bullets[0].bulletsName);
        Debug.Log(bullets[1].bulletsName);
    }
}

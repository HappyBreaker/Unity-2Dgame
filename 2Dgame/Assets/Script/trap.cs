using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [Header("傳送點一")]
    public Transform trap1;
    [Header("陷阱傷害")]
    public float damege = 10;

    private Player player;
    private Transform warrior;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        warrior = GameObject.Find("Warrior").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.health(damege);
        warrior.position = trap1.position;
        player.DelayControl();
    }

}

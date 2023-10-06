using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    [SerializeField] PlayerMove player;
    [SerializeField] Elevator elevator;
    private float originalSpeed;
    private void Start()
    {
        originalSpeed = player.moveSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        player.moveSpeed += 50;
        collision.transform.SetParent(transform);
        Debug.Log(player.moveSpeed);
    }

    private void OnCollisionExit(Collision collision)
    {
        player.moveSpeed = originalSpeed;
        collision.transform.SetParent(null);
    }
}

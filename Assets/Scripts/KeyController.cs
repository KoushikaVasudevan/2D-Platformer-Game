using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with Key");

        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            playerController.PickUpKey();

            SoundManager.Instance.Play(SoundManager.Sounds.KeyPickup);
            Destroy(gameObject);
        }  
    }
}

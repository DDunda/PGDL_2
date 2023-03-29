using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public int maxTriggers = 1;
    public bool needsGrounded = true;
    public bool needsAlive = true;
    public Transform respawnPosition = null;

    private int _triggers = 0;
    private bool _triggerFailed = false;

    private void AttemptTrigger(Collider2D other)
    {
        var pl = other.gameObject.GetComponent<PlayerLife>();
        _triggerFailed = !((maxTriggers == -1 || _triggers < maxTriggers) &&
            (!needsGrounded || (other.gameObject.GetComponent<PlayerMovement>()?.IsGrounded() == true)) &&
            (!needsAlive || (pl?.alive == true)));

        if (!_triggerFailed)
        {
            if(respawnPosition != null)
            {
                pl.SetSpawnpoint(respawnPosition.position);
            }
            onTriggerEnter.Invoke();
            _triggers++;
        }

        if (_triggers == maxTriggers)
        {
            gameObject.SetActive(false);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        AttemptTrigger(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_triggerFailed) AttemptTrigger(other);
    }
}

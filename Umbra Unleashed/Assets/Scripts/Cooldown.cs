using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script from this video - https://youtu.be/5r6RmddoR80?si=nEHyZW-tv0zVVjM8
[System.Serializable]
public class Cooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    private float _nextFireTime;

    public bool isCoolingDown => Time.time < _nextFireTime; // bool to reset depending on cooldown time
    public void StartCooldown() => _nextFireTime = Time.time + cooldownTime; // function to begin cooldown and set the timer
}

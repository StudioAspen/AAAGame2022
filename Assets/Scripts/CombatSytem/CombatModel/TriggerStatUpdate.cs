using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStatUpdate : MonoBehaviour
{
    public enum StatUpdateType { 
        SET, // Replacing current data 
        ADD // Adding onto current data
    }
    public Stats newAlonzoStats = new Stats();
    public List<string> newAlonzoSkills;
    public StatUpdateType statUpdateType = StatUpdateType.SET;

    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement characterMovement;
        if (other.CompareTag("Player") && other.TryGetComponent<CharacterMovement>(out characterMovement))
        {
            CombatData holder = characterMovement.alonzoCombatData;
            switch (statUpdateType)
            {
                case StatUpdateType.SET:
                    holder.baseStats = newAlonzoStats;
                    holder.skillKeys.Clear();
                    foreach (string skill in newAlonzoSkills)
                    {
                        holder.skillKeys.Add(skill);
                    }
                    break;
                case StatUpdateType.ADD:
                    holder.baseStats.Add(newAlonzoStats);
                    foreach (string skill in newAlonzoSkills)
                    {
                        holder.skillKeys.Add(skill);
                    }
                    break;
            }
        }
    }
}

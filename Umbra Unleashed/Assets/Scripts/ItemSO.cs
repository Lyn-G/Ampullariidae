using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int statChangeAmount;
    public AttributeToChange attributeToChange = new AttributeToChange();
    public int attributeChangeAmount;

    public bool UseItem()
    {
        PlayerStats stats = GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>();
        bool isUsable = false;

        if (statToChange == StatToChange.Health && stats.health < stats.maxHealth)
        {
            stats.ChangeHealth(statChangeAmount);
            isUsable = true;
        }
        else if (statToChange == StatToChange.Mana && stats.mana < stats.maxMana)
        {
            stats.ChangeMana(statChangeAmount);
            isUsable = true;
        }
        else if (statToChange == StatToChange.Attack)
        {
            stats.ChangeAttack(statChangeAmount);
            isUsable = true;
        }
        else if (statToChange == StatToChange.Defense)
        {
            stats.ChangeDefense(statChangeAmount);
            isUsable = true;
        }
        else if (attributeToChange == AttributeToChange.Strength)
        {
            stats.ChangeStrength(attributeChangeAmount);
            isUsable = true;
        }
        else if (attributeToChange == AttributeToChange.Dexterity)
        {
            stats.ChangeDexterity(attributeChangeAmount);
            isUsable = true;
        }
        else if (attributeToChange == AttributeToChange.Intelligence)
        {
            stats.ChangeIntelligence(attributeChangeAmount);
            isUsable = true;
        }
        else if (attributeToChange == AttributeToChange.Charisma)
        {
            stats.ChangeCharisma(attributeChangeAmount);
            isUsable = true;
        }
        return isUsable;
    }

    public enum StatToChange
    {
        Health,
        Mana,
        Attack,
        Defense
    }
    public enum AttributeToChange
    {
        Strength,
        Dexterity,
        Intelligence,
        Charisma
    }
}

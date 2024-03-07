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
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeAttack(statChangeAmount);
        }
        else if (statToChange == StatToChange.Defense)
        {
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeDefense(statChangeAmount);
        }
        else if (attributeToChange == AttributeToChange.Strength)
        {
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeStrength(attributeChangeAmount);
        }
        else if (attributeToChange == AttributeToChange.Dexterity)
        {
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeDexterity(attributeChangeAmount);
        }
        else if (attributeToChange == AttributeToChange.Intelligence)
        {
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeIntelligence(attributeChangeAmount);
        }
        else if (attributeToChange == AttributeToChange.Charisma)
        {
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeCharisma(attributeChangeAmount);
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

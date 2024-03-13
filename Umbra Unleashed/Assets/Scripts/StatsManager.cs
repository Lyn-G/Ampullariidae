using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text strengthText;
    public TMP_Text dexterityText;
    public TMP_Text intelligenceText;
    public TMP_Text charismaText;

    // Add other stats and attributes here
    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public int attack;
    public int defense;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int charisma;

    // Default values for other stats and attributes

    private void Start()
    {
        healthText.text = "Health: " + health.ToString();
        manaText.text = "Mana: " + mana.ToString();
        attackText.text = "Attack: " + attack.ToString();
        defenseText.text = "Defense: " + defense.ToString();
        strengthText.text = "Strength: " + strength.ToString();
        dexterityText.text = "Dexterity: " + dexterity.ToString();
        intelligenceText.text = "Intelligence: " + intelligence.ToString();
        charismaText.text = "Charisma: " + charisma.ToString();
        // Update UI
    }   

    public void ChangeHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthText.text = "Health: " + health.ToString();
        // Update UI
    }

    public void ChangeMana(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        manaText.text = "Mana: " + mana.ToString();
        // Update UI
    }

    public void ChangeAttack(int amount)
    {
        attack += amount;
        attackText.text = "Attack: " + attack.ToString();
        // Update UI
    }

    public void ChangeDefense(int amount)
    {
        defense += amount;
        defenseText.text = "Defense: " + defense.ToString();
        // Update UI
    }

    public void ChangeStrength(int amount)
    {
        strength += amount;
        strengthText.text = "Strength: " + strength.ToString();
        // Update UI
    }

    public void ChangeDexterity(int amount)
    {
        dexterity += amount;
        dexterityText.text = "Dexterity: " + dexterity.ToString();
        // Update UI
    }

    public void ChangeIntelligence(int amount)
    {
        intelligence += amount;
        intelligenceText.text = "Intelligence: " + intelligence.ToString();
        // Update UI
    }

    public void ChangeCharisma(int amount)
    {
        charisma += amount;
        charismaText.text = "Charisma: " + charisma.ToString();
        // Update UI
    }

    public void SetMaxHealth()
    {
        health = maxHealth;
    }
}

using UnityEngine;

public class TooltipColors : MonoBehaviour
{
    public static Color GetRarityColor(string rarity)
    {
        switch (rarity.ToLower())
        {
            case "common": return Color.white;
            case "uncommon": return Color.green;
            case "rare": return Color.blue;
            case "epic": return new Color(0.5f, 0f, 0.5f);
            case "legendary": return new Color(1f, 0.84f, 0f);
            case "mythical": return new Color(1f, 0.41f, 0.71f);
            case "divine": return new Color(0.0f, 1f, 1f);
            case "exotic": return new Color(1f, 0f, 0f);
            default: return Color.white;
        }
    }

    public static Color GetStatColor(string stat)
    {
        switch (stat.ToLower())
        {
            case "damage":
            case "strength":
            case "crit damage":
            case "crit chance":
            case "attack speed":
                return Color.red;

            case "health":
            case "health regeneration":
            case "defense":
            case "speed":
            case "luck":
            case "mana":
            case "mana regeneration":
            case "magic damage":
            case "dungeon exp boost":
            case "gold fortune":
            case "gem fortune":
            case "essence fortune":
            case "mining fortune":
            case "gemstone fortune":
            case "ore fortune":
            case "mining speed":
            case "undead damage":
            case "undead resistance":
            case "golem damage":
            case "golem resistance":
            case "draconic damage":
            case "draconic resistance":
            case "demonic damage":
            case "demonic resistance":
            case "angelic damage":
            case "angelic resistance":
            case "giant damage":
            case "giant resistance":
            case "fire damage":
            case "fire resistance":
            case "water damage":
            case "water resistance":
            case "lightning damage":
            case "lightning resistance":
            case "poison damage":
            case "poison resistance":
            case "ice damage":
            case "ice resistance":
            case "darkness damage":
            case "darkness resistance":
            case "light damage":
            case "light resistance":
                return Color.green;
            default: return Color.white;
        }
    }
    public static Color GetTierColor(string tier)
    {
        switch (tier.ToLower())
        {
            case "none": return Color.gray;
            case "rough": return Color.white;
            case "smoothed": return Color.green;
            case "polished": return Color.blue;
            case "brilliant": return Color.magenta;
            case "flawless": return new Color(1.0f, 0.84f, 0.0f);
            default: return Color.white;
        }
    }
}

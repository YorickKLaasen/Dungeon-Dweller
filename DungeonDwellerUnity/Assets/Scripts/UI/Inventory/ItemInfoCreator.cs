using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoCreator : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public List<string> itemStats = new List<string>();
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI itemRarityText;
    public TextMeshProUGUI statsText;
    [SerializeField] string itemRarity;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    public TextMeshProUGUI itemSlotsText;
    public List<string> statAmount = new List<string>();
    public List<string> itemSlots = new List<string>();
    public List<string> slotTier = new List<string>();
    private List<string> percentageStats = new List<string>
    { "crit damage", "crit chance", "attack speed",
        "luck", "speed", "dungeon exp boosts",
    "undead resistance", "undead damage", "golem resistance","golem damage",
    "draconic resistance","draconic damage","demonic resistance","demonic damage",
    "angelic resistance","angelic damage", "giant resistance", "giant damage",
    "fire resistance","fire damage","water resistance","water damage","lightning resistance","lightning damage",
    "poison resistance","poison damage","ice resistance","ice damage","darkness resistance","darkness damage",
    "light resistance","light damage"};

    public int maxUpgradeStars = 0;
    public int currentUpgradeStars;
    string[] stars = { "", "", "", "", "" };
    void Start()
    {
        GenerateItemTooltip();
    }
    void Update()
    {
        GenerateItemTooltip();
    }

    public void GenerateItemTooltip()
    {
        Color rarityColor = TooltipColors.GetRarityColor(itemRarity);
        itemNameText.color = rarityColor;
        itemRarityText.color = rarityColor;
        itemNameText.text = itemName;
        itemRarityText.text = itemRarity;
        GetItemStarCount();
        itemDescriptionText.color = Color.gray;
        itemDescriptionText.text = itemDescription;
        statsText.text = "";
        itemSlotsText.text = "";
        if (itemSlots.Count != 0)
        {
            ItemSlotAdder();
        }
        else
        {
            itemSlotsText.gameObject.SetActive(false);
        }
        for (int i = 0; i < itemStats.Count; i++)
        {
            string stat = itemStats[i];
            string amount = statAmount[i];
            if (percentageStats.Contains(stat.ToLower()))
            {
                amount += "%";
            }
            Color statColor = TooltipColors.GetStatColor(stat);
            statsText.text += $"<color=#{ColorUtility.ToHtmlStringRGB(statColor)}>{stat}: +{amount}</color>\n";
        }
    }
    public void ItemSlotAdder()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (slotTier.Count != itemSlots.Count)
            {
                slotTier.Add("None");
            }
            string itemSlot = itemSlots[i].ToLower();
            string tier = slotTier[i].ToLower();

            Color tierColor = TooltipColors.GetTierColor(tier);

            itemSlotsText.text += $"<color=#{ColorUtility.ToHtmlStringRGB(tierColor)}>[<sprite={GetSpriteIndex(itemSlot)}>]</color> ";
        }
    }
    private int GetSpriteIndex(string itemSlot)
    {
        switch (itemSlot)
        {
            case "amethyst": return 0;
            case "sapphire": return 1;
            case "topaz": return 2;
            case "jade": return 3;
            case "jasper": return 4;
            case "onyx": return 5;
            case "ruby": return 6;
            case "amber": return 7;
            case "fire": return 8;
            case "water": return 9;
            case "lightning": return 10;
            case "poison": return 11;
            case "ice": return 12;
            case "darkness": return 13;
            case "light": return 20;
            case "undead": return 14;
            case "golem": return 15;
            case "draconic": return 16;
            case "demonic": return 17;
            case "angelic": return 18;
            case "giant": return 19;
            default: return -1;
        }
    }

    public void GetItemStarCount()
    {
        string[] stars = { "", "", "", "", "" };

        if (currentUpgradeStars == 1 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=21>";
        }
        if (currentUpgradeStars == 2 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=21>"; stars[1] = "<sprite=21>";
        }
        if (currentUpgradeStars == 3 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=21>"; stars[1] = "<sprite=21>"; stars[2] = "<sprite=21>";
        }
        if (currentUpgradeStars == 4 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=21>"; stars[1] = "<sprite=21>"; stars[2] = "<sprite=21>"; stars[3] = "<sprite=21>";
        }
        if (currentUpgradeStars == 5 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=21>"; stars[1] = "<sprite=21>"; stars[2] = "<sprite=21>"; stars[3] = "<sprite=21>"; stars[4] = "<sprite=21>";
        }

        if (currentUpgradeStars == 6 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=22>"; stars[1] = "<sprite=21>"; stars[2] = "<sprite=21>"; stars[3] = "<sprite=21>"; stars[4] = "<sprite=21>";
        }
        if (currentUpgradeStars == 7 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=22>"; stars[1] = "<sprite=22>"; stars[2] = "<sprite=21>"; stars[3] = "<sprite=21>"; stars[4] = "<sprite=21>";
        }
        if (currentUpgradeStars == 8 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=22>"; stars[1] = "<sprite=22>"; stars[2] = "<sprite=22>"; stars[3] = "<sprite=21>"; stars[4] = "<sprite=21>";
        }
        if (currentUpgradeStars == 9 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=22>"; stars[1] = "<sprite=22>"; stars[2] = "<sprite=22>"; stars[3] = "<sprite=22>"; stars[4] = "<sprite=21>";
        }
        if (currentUpgradeStars == 10 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=22>"; stars[1] = "<sprite=22>"; stars[2] = "<sprite=22>"; stars[3] = "<sprite=22>"; stars[4] = "<sprite=22>";
        }

        if (currentUpgradeStars == 11 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=23>"; stars[1] = "<sprite=22>"; stars[2] = "<sprite=22>"; stars[3] = "<sprite=22>"; stars[4] = "<sprite=22>";
        }
        if (currentUpgradeStars == 12 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=23>"; stars[1] = "<sprite=23>"; stars[2] = "<sprite=22>"; stars[3] = "<sprite=22>"; stars[4] = "<sprite=22>";
        }
        if (currentUpgradeStars == 13 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=23>"; stars[1] = "<sprite=23>"; stars[2] = "<sprite=23>"; stars[3] = "<sprite=22>"; stars[4] = "<sprite=22>";
        }
        if (currentUpgradeStars == 14 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=23>"; stars[1] = "<sprite=23>"; stars[2] = "<sprite=23>"; stars[3] = "<sprite=23>"; stars[4] = "<sprite=22>";
        }
        if (currentUpgradeStars == 15 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=23>"; stars[1] = "<sprite=23>"; stars[2] = "<sprite=23>"; stars[3] = "<sprite=23>"; stars[4] = "<sprite=23>";
        }

        if (currentUpgradeStars == 16 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=24>"; stars[1] = "<sprite=23>"; stars[2] = "<sprite=23>"; stars[3] = "<sprite=23>"; stars[4] = "<sprite=23>";
        }
        if (currentUpgradeStars == 17 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=24>"; stars[1] = "<sprite=24>"; stars[2] = "<sprite=23>"; stars[3] = "<sprite=23>"; stars[4] = "<sprite=23>";
        }
        if (currentUpgradeStars == 18 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=24>"; stars[1] = "<sprite=24>"; stars[2] = "<sprite=24>"; stars[3] = "<sprite=23>"; stars[4] = "<sprite=23>";
        }
        if (currentUpgradeStars == 19 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=24>"; stars[1] = "<sprite=24>"; stars[2] = "<sprite=24>"; stars[3] = "<sprite=24>"; stars[4] = "<sprite=23>";
        }
        if (currentUpgradeStars == 20 && currentUpgradeStars <= maxUpgradeStars)
        {
            stars[0] = "<sprite=24>"; stars[1] = "<sprite=24>"; stars[2] = "<sprite=24>"; stars[3] = "<sprite=24>"; stars[4] = "<sprite=24>";
        }

        // Toon de sterren in de item naam tekst
        itemNameText.text = itemName + " " + string.Join("", stars);
    }
}

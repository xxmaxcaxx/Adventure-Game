using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Weapon1,
    Weapon2,
    Acessory1,
    Acessory2,
}

[CreateAssetMenu]
public class EquipableItem : Item
{
        public int StrengthBonus;
        public int AgilityBonus;
        public int IntelligenceBonus;
        public int VitalityBonus;
        [Space]
        public float StregnthPercentBonus;
        public float AgilityPercentBonus;
        public float IntelligencePercentBonus;
        public float VitallityPercentBonus;
        [Space]
        public EquipmentType EquipmentType;
}

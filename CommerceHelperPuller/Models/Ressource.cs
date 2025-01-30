public class RootObject
{
    public int total { get; set; }
    public int limit { get; set; }
    public int skip { get; set; }
    public Data[] data { get; set; }
}

public class Data
{
    public string _id { get; set; }
    public int m_flags { get; set; }
    public int id { get; set; }
    public int typeId { get; set; }
    public int iconId { get; set; }
    public int level { get; set; }
    // public int realWeight { get; set; }
    public int useAnimationId { get; set; }
    public int price { get; set; }
    public int itemSetId { get; set; }
    public string criteria { get; set; }
    public string criteriaTarget { get; set; }
    public int appearanceId { get; set; }
    public bool isColorable { get; set; }
    public int recipeSlots { get; set; }
    public int[] recipeIds { get; set; }
    public int[] dropMonsterIds { get; set; }
    public object[] dropTemporisMonsterIds { get; set; }
    public PossibleEffects[] possibleEffects { get; set; }
    public object[] evolutiveEffectIds { get; set; }
    public object[] favoriteSubAreas { get; set; }
    public int favoriteSubAreasBonus { get; set; }
    public int craftXpRatio { get; set; }
    public string craftVisible { get; set; }
    public string craftConditional { get; set; }
    public string craftFeasible { get; set; }
    public string visibility { get; set; }
    public double recyclingNuggets { get; set; }
    public int[] favoriteRecyclingSubareas { get; set; }
    public object[] resourcesBySubarea { get; set; }
    public string changeVersion { get; set; }
    public long? tooltipExpirationDate { get; set; }
    public int criticalFailureProbability { get; set; }
    public int criticalHitBonus { get; set; }
    public int minRange { get; set; }
    public int criticalHitProbability { get; set; }
    public int range { get; set; }
    public bool castInLine { get; set; }
    public int apCost { get; set; }
    public bool castInDiagonal { get; set; }
    public bool castTestLos { get; set; }
    public int maxCastPerTurn { get; set; }
    public Name name { get; set; }
    public Description description { get; set; }
    public ImportantNotice importantNotice { get; set; }
    public bool cursed { get; set; }
    public bool usable { get; set; }
    public bool targetable { get; set; }
    public bool exchangeable { get; set; }
    public bool twoHanded { get; set; }
    public bool etheral { get; set; }
    public bool hideEffects { get; set; }
    public bool enhanceable { get; set; }
    public bool nonUsableOnAnother { get; set; }
    public bool secretRecipe { get; set; }
    public bool objectIsDisplayOnWeb { get; set; }
    public bool bonusIsSecret { get; set; }
    public bool needUseConfirm { get; set; }
    public bool isDestructible { get; set; }
    public bool isSaleable { get; set; }
    public bool isLegendary { get; set; }
    public string className { get; set; }
    public int m_id { get; set; }
    public int[] questsThatUse { get; set; }
    public int[] questsThatReward { get; set; }
    public bool hasRecipe { get; set; }
    public bool hasLivingObjectSkinJntMood { get; set; }
    public int[] recipesThatUse { get; set; }
    public int startLegendaryTreasureHunt { get; set; }
    public int legendaryTreasureHuntThatReward { get; set; }
    public int[] achievementsThatReward { get; set; }
    public Slug slug { get; set; }
    public Effects[] effects { get; set; }
    public string createdAt { get; set; }
    public string updatedAt { get; set; }
    public string img { get; set; }
    public object itemSet { get; set; }
    public Type type { get; set; }
    public Appearance appearance { get; set; }
}

public class PossibleEffects
{
    public int m_flags { get; set; }
    public int effectUid { get; set; }
    public int baseEffectId { get; set; }
    public int effectId { get; set; }
    public int order { get; set; }
    public int targetId { get; set; }
    public string targetMask { get; set; }
    public int duration { get; set; }
    public int random { get; set; }
    public int group { get; set; }
    public int modificator { get; set; }
    public int dispellable { get; set; }
    public int delay { get; set; }
    public string triggers { get; set; }
    public int effectElement { get; set; }
    public int spellId { get; set; }
    public int effectTriggerDuration { get; set; }
    public ZoneDescr zoneDescr { get; set; }
    public int value { get; set; }
    public int diceNum { get; set; }
    public int diceSide { get; set; }
    public bool displayZero { get; set; }
    public bool visibleInTooltip { get; set; }
    public bool visibleInBuffUi { get; set; }
    public bool visibleInFightLog { get; set; }
    public bool visibleOnTerrain { get; set; }
    public bool forClientOnly { get; set; }
    public bool trigger { get; set; }
    public string className { get; set; }
}

public class ZoneDescr
{
    public object[] cellIds { get; set; }
    public int shape { get; set; }
    public int param1 { get; set; }
    public int param2 { get; set; }
    public int damageDecreaseStepPercent { get; set; }
    public int maxDamageDecreaseApplyCount { get; set; }
    public bool isStopAtTarget { get; set; }
}

public class Name
{
    public string id { get; set; }
    public string pt { get; set; }
    public string en { get; set; }
    public string fr { get; set; }
    public string es { get; set; }
    public string de { get; set; }
}

public class Description
{
    public string id { get; set; }
    public string pt { get; set; }
    public string en { get; set; }
    public string fr { get; set; }
    public string es { get; set; }
    public string de { get; set; }
}

public class ImportantNotice
{
    public string id { get; set; }
    public string pt { get; set; }
    public string en { get; set; }
    public string fr { get; set; }
    public string es { get; set; }
    public string de { get; set; }
}

public class Slug
{
    public string pt { get; set; }
    public string en { get; set; }
    public string fr { get; set; }
    public string es { get; set; }
    public string de { get; set; }
}

public class Effects
{
    public int from { get; set; }
    public int to { get; set; }
    public int characteristic { get; set; }
    public int category { get; set; }
    public int elementId { get; set; }
    public int effectId { get; set; }
}

public class Type
{
    public string _id { get; set; }
    public int id { get; set; }
    public int superTypeId { get; set; }
    public int categoryId { get; set; }
    public bool isInEncyclopedia { get; set; }
    public bool plural { get; set; }
    public int gender { get; set; }
    public string rawZone { get; set; }
    public bool mimickable { get; set; }
    public int craftXpRatio { get; set; }
    public int evolutiveTypeId { get; set; }
    public object[] possiblePositions { get; set; }
    public Name1 name { get; set; }
    public string className { get; set; }
    public int m_id { get; set; }
    public string createdAt { get; set; }
    public string updatedAt { get; set; }
    public SuperType superType { get; set; }
}

public class Name1
{
    public string id { get; set; }
    public string pt { get; set; }
    public string en { get; set; }
    public string fr { get; set; }
    public string es { get; set; }
    public string de { get; set; }
}

public class SuperType
{
    public string _id { get; set; }
    public int[] positions { get; set; }
    public int id { get; set; }
    public Name2 name { get; set; }
    public string createdAt { get; set; }
    public string updatedAt { get; set; }
    public int __v { get; set; }
}

public class Name2
{
    public string fr { get; set; }
    public string en { get; set; }
    public string pt { get; set; }
    public string de { get; set; }
    public string it { get; set; }
    public string es { get; set; }
}

public class Appearance
{
    public string _id { get; set; }
    public object[] colors { get; set; }
    public int id { get; set; }
    public int? bone { get; set; }
    public int? skin { get; set; }
    public int size { get; set; }
    public string createdAt { get; set; }
    public string updatedAt { get; set; }
    public int __v { get; set; }
}


namespace ASWCGameEngine;

public abstract class Creature
{
    /// <summary>
    /// Creature name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Initial health which will also be the initial max health
    /// </summary>
    public int Health { get; set; }
    
    /// <summary>
    /// Item of attack
    /// </summary>
    public AttackItem? ItemAttack { get; set; }
    
    /// <summary>
    /// Item of defence
    /// </summary>
    public DefenceItem? ItemDefence { get; set; }
    
    /// <summary>
    /// Inventory / bag for holding not in-use items (items to be saved)
    /// </summary>
    public List<WorldObject> Inventory { get; set; }
    
    /// <summary>
    /// The max health value
    /// </summary>
    private int _maxHealth;
    
    /// <summary>
    /// Global base damage - this value will be multiplied by the AttackItem's damage
    /// </summary>
    private int _baseDamage = 1;
    
    /// <summary>
    /// The inventory size value
    /// </summary>
    private int _inventorySize = 5;

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Given name of creature</param>
    /// <param name="health">Initial health of creauture</param>
    public Creature(string name, int health)
    {
        Name = name;
        Health = health;
        Inventory = new List<WorldObject>();
        Inventory.Capacity = 20;
        _maxHealth = health;
    }

    /// <summary>
    /// Default constructor (JSON-parsing)
    /// </summary>
    public Creature() { }

    /// <summary>
    /// Genereate damage for hitting/damaging other creatures
    /// </summary>
    /// <returns>Points of damage to be given</returns>
    public int Hit() 
    {
        if (ItemAttack == null)
            return _baseDamage;
        return ItemAttack.Damage * _baseDamage;
    }

    /// <summary>
    /// Subtracts the given damage from the health-property
    /// </summary>
    /// <param name="damage">The damage given</param>
    public void ReceiveDamage(int damage) 
    {
        Health -= damage;
    }

    /// <summary>
    /// Equips or puts away (into inventory) the looted object
    /// </summary>
    /// <param name="obj">The object to be looted</param>
    public void Loot(WorldObject obj) 
    {
        if (obj is AttackItem) 
        {
            if (ItemAttack == null) 
            {
                ItemAttack = (AttackItem) obj;
            }
        }
        else if (obj is DefenceItem) 
        {
            if (ItemDefence == null) 
            {
                ItemDefence = (DefenceItem) obj;
            }
        }
        else 
        {
            Inventory.Add(obj);
        }
    }
}

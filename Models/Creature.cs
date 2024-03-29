﻿using ASWCGameEngine.Models;
using ASWCGameEngine.Models.Interfaces;
using ASWCGameEngine.Models.States;
using System.Numerics;

namespace ASWCGameEngine;

public abstract class Creature : IGameObject
{
    /// <summary>
    /// GameObject global id
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// GameObject position in world
    /// </summary>
    public Position Position { get; set; }
    
    /// <summary>
    /// Creature name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Initial health which will also be the initial max health
    /// </summary>
    public HealthState HealthState { get; set; }

    /// <summary>
    /// The current health of the creature
    /// </summary>
    public int Health { get {  return HealthState.Health; } }
        
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
    /// Returns true if creature is alive, false if not.
    /// Can be used for conditional rendering of creatures in the world-grid.
    /// </summary>
    public bool IsAlive { get { return HealthState.GetType() != typeof(HealthStateDead) ? true : false; } }
    
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
    public Creature(int id, Position position, string name, int health)
    {
        Id = id;
        Position = position;
        Name = name;
        Inventory = new List<WorldObject>();
        Inventory.Capacity = 20;
        _maxHealth = health;
        HealthState = new HealthStateNormal(health, this);
        HealthState.StateChangeCheck();
    }

    /// <summary>
    /// Default constructor (JSON-parsing)
    /// </summary>
    public Creature() { }

    /// <summary>
    /// Genereate damage for hitting/damaging other creatures
    /// </summary>
    /// <returns>Points of damage to be given</returns>
    public int? Hit() 
    {
        if (IsAlive)
        {
            int dmg = 0;
            if (ItemAttack == null)
                dmg = _baseDamage;
            else dmg = ItemAttack.Damage * _baseDamage;

            GameLogger.LogInformation(0, $"Creature ({this.Name}) dealt {dmg} damage");
            return dmg;
        }
        return null;
    }

    /// <summary>
    /// Subtracts the given damage from the health-property - takes in account the defence item
    /// </summary>
    /// <param name="damage">The damage given</param>
    public void ReceiveDamage(int? rawDamage) 
    {
        if (IsAlive && rawDamage != null)
        {
            int? realDamage;

            if (ItemDefence != null)
                if (ItemDefence.ReduceDamage > rawDamage)
                    realDamage = 0;
                else
                    realDamage = rawDamage - ItemDefence.ReduceDamage;
            else
                realDamage = rawDamage;

            HealthState.TakeDamage((int)realDamage);
            GameLogger.LogInformation(0, $"Creature ({this.Name}) took {realDamage} damage");
        }
        else
        {
            GameLogger.LogInformation(0, $"{this.Name} did not receive any damage");
        }
    }

    /// <summary>
    /// Equips or puts away (into inventory) the looted object
    /// </summary>
    /// <param name="obj">The object to be looted</param>
    public void Loot(WorldObject obj) 
    {
        if (IsAlive)
        {
            if (obj is AttackItem)
            {
                if (ItemAttack == null)
                {
                    ItemAttack = (AttackItem)obj;
                }
            }
            else if (obj is DefenceItem)
            {
                if (ItemDefence == null)
                {
                    ItemDefence = (DefenceItem)obj;
                }
            }
            else
            {
                Inventory.Add(obj);
            }

            //obj.Position = new Vector2(Configuration.Instance.MaxWorldSizeX+1, Configuration.Instance.MaxWorldSizeY+1);
            obj.Position = Position;

            GameLogger.LogInformation(0, $"Creature ({this.Name}) looted {obj.Name}");
        }
    }

    public Position MoveTo(Position newPos)
    {
        if (IsAlive)
        {
            Position.X = newPos.X;
            Position.Y = newPos.Y;

            GameLogger.LogInformation(0, $"Creature ({this.Name}) moved (teleported) to {Position}");
            return Position;
        }
        return null!;
    }

    public Position Move(Position moveVector)
    {
        if (IsAlive)
        {
            Position += moveVector;
            GameLogger.LogInformation(0, $"Creature ({this.Name}) moved to {Position}");
            return Position;
        }
        return null!;
    }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Position)}={Position}, {nameof(Name)}={Name}, {nameof(HealthState)}={HealthState}, {nameof(ItemAttack)}={ItemAttack}, {nameof(ItemDefence)}={ItemDefence}, {nameof(Inventory)}={Inventory}, {nameof(IsAlive)}={IsAlive.ToString()}}}";
    }
}

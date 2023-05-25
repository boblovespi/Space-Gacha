using Godot;
using System;

public partial class SimpleHealthController : AbstractHealthController
{
	public override ArmorType ArmorType { get; } = ArmorType.Armor;

	[Export]
	public int MaxHealth { get; set; } = 1000;
	public int Health { get; private set; }

	public override bool IsDead => Health <= 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Health = MaxHealth;
	}

	public override void Damage(DamageInfo incomingDamage)
	{
		Health -= incomingDamage.Damage;
	}
}

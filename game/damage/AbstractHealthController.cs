using Godot;
using System;

public abstract partial class AbstractHealthController : Node
{
	/// <summary>
	/// Returns the armor type that is currently exposed.
	/// </summary>
	public abstract ArmorType ArmorType { get; }

	/// <summary>
	/// Returns true if and only if this owner is dead.
	/// </summary>
	public abstract bool IsDead { get; }

	/// <summary>
	/// Damage this owner by the given DamageInfo.
	/// </summary>
	public abstract void Damage(DamageInfo incomingDamage);
}

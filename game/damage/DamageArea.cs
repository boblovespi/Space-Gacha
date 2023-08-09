using Godot;
using System;

public partial class DamageArea : Node3D
{
	// [Export]
	public DamageInfo damage { get; set; } = new DamageInfo {DamageType = DamageType.Piercing, Damage = 5};
	private CollisionShape3D[] hitboxes;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnCollision(Node3D body)
	{
		var hc = body.GetNodeOrNull<AbstractHealthController>("HealthController");
		hc?.Damage(damage);
		GetParent().QueueFree();
	}
}

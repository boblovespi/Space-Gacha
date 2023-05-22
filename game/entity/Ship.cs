using Godot;
using System;

public partial class Ship : RigidBody3D, ITrackable
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
	}

	public void SetForce(Vector2 dir)
	{
		ConstantTorque = -GlobalTransform.Basis.Y * dir.X - GlobalTransform.Basis.X * dir.Y;
	}

	public void EndForce()
	{
		SetForce(Vector2.Zero);
	}
}

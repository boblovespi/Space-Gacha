using Godot;
using System;

public partial class Main : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var shipUi = GetNode<ShipOverlay>("Control");
		var ship = GetNode<Ship>("Node3D");
		shipUi.Track(ship);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

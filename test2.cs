using Godot;
using System;

public partial class test2 : test1
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void SayHi()
	{
		GD.Print("Hi from test2!");
	}
}

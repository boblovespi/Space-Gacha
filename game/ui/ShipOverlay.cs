using Godot;
using System;

public partial class ShipOverlay : Control
{
	private TouchScreenButton joystick;
	private Sprite2D joystickThumb;
	private Vector2 joystickPosition;

	[Signal]
	public delegate void MovementEventHandler(Vector2 normedDirection);

	[Signal]
	public delegate void MovementEndEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		joystick = GetNode<TouchScreenButton>("Joystick");
		joystickThumb = joystick.GetNode<Sprite2D>("Thumb");
		joystickPosition = joystick.Position + new Vector2(64, 64);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touch)
		{
			if (touch.Pressed)
			{
				var dir = (touch.Position - joystickPosition).LimitLength(64) / 64;
				EmitSignal(SignalName.Movement, dir);
				SetThumbPos(touch.Position - joystickPosition);
			}
			else
			{
				EmitSignal(SignalName.MovementEnd);
				SetThumbPos(Vector2.Zero);
			}
		}
		if (@event is InputEventScreenDrag drag && joystick.IsPressed())
		{
			var dir = (drag.Position - joystickPosition).LimitLength(64) / 64;
			EmitSignal(SignalName.Movement, dir);
			SetThumbPos(drag.Position - joystickPosition);
		}
	}

	private void SetThumbPos(Vector2 pos)
	{
		joystickThumb.Position = pos.LimitLength(64) + new Vector2(64, 64);
	}
}

﻿namespace Sankari;

public class MovementInput
{
	public bool IsJump { get; set; }
	public bool IsLeft { get; set; }
	public bool IsRight { get; set; }
	public bool IsUp { get; set; }
	public bool IsDown { get; set; }
	public bool IsFastFall { get; set; }
	public bool IsDash { get; set; }
	public bool IsSprint { get; set; }
}

public class MovementUtils
{
	public static MovementInput GetPlayerMovementInput()
	{
		return new()
		{
			IsJump     = Input.IsActionJustPressed("player_jump"),
			IsDash     = Input.IsActionJustPressed("player_dash"),
			IsLeft     = Input.IsActionPressed    ("player_move_left"),
			IsRight    = Input.IsActionPressed    ("player_move_right"),
			IsUp       = Input.IsActionPressed    ("player_move_up"),
			IsDown     = Input.IsActionPressed    ("player_move_down"),
			IsFastFall = Input.IsActionPressed    ("player_fast_fall"),
			IsSprint   = Input.IsActionPressed    ("player_sprint"),
		};
	}

	/// <summary>
	/// Check if a given vector is pointing upwards
	/// </summary>
	/// <returns>True if the vector is pointing upwards</returns>
	public static bool IsUp(Vector2 vector)
	{
		return vector.y < 0;
	}

	/// <summary>
	/// Check if a given vector is pointing downwards
	/// </summary>
	/// <returns>True if the vector is pointing downwards</returns>
	public static bool IsDown(Vector2 vector)
	{
		return vector.y > 0;
	}

	/// <summary>
	/// Convert a vector into a direction vector (e.g. 1 if movement towards left)
	/// </summary>
	/// <returns>Vector where x,y are 1, 0, or -1</returns>
	public static Vector2 GetDirection(Vector2 vector)
	{
		var x = 0;
		var y = 0;

		if (vector.x > 0)
			x = 1;
		else if (vector.x < 0)
			x = -1;

		if (vector.y > 0)
			y = 1;
		if (vector.y < 0)
			y = -1;

		return new Vector2(x, y);
	}
}

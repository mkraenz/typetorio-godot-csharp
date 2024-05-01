using Godot;
using System;

public partial class InputPrompt : LineEdit
{
	public void SetText(string str)
	{
		Text = str;
		CaretColumn = str.Length; // not sure why but setting text to uppercase sets the caret to beginning of the line
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
public class ColorUtils
{
		
	public static Color GetColor(ColorLight colorLight){

		switch (colorLight) {
			case ColorLight.Blue:
				return Color.blue;
			case ColorLight.Green:
				return Color.green;
			case ColorLight.Orange:
				return GetColorFromHex("#FFA500");
			case ColorLight.Purple:
				return GetColorFromHex("#551A8B");
			case ColorLight.Red:
				return GetColorFromHex("#FF0000");
			case ColorLight.Yellow:
				return Color.yellow;
		default:
			return Color.black;
		}
	
	}

	public static Color GetColorFromHex(string hexColor){
		Color outColor;
		ColorUtility.TryParseHtmlString (hexColor, out outColor);

		return outColor;
	}


}



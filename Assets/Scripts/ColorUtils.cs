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

	public static ColorLight CombineColors(ColorLight color1, ColorLight color2){

		if (color1 == ColorLight.Blue){

			switch (color2) {
			case ColorLight.Yellow:
				return ColorLight.Green;
			case ColorLight.Red:
				return ColorLight.Purple;
					

			}			
		}else if (color1 == ColorLight.Yellow){
			switch (color2) {
			case ColorLight.Blue:
				return ColorLight.Green;
			case ColorLight.Red:
				return ColorLight.Orange;


			}	
		}else if (color1 == ColorLight.Red){
			switch (color2) {
			case ColorLight.Yellow:
				return ColorLight.Orange;
			case ColorLight.Blue:
				return ColorLight.Purple;
				}	
		}

		return ColorLight.Blue;
	} 

	public static bool isMixedColor(ColorLight color){
		if (color == ColorLight.Yellow && color == ColorLight.Blue && color == ColorLight.Red) {
			return true;
		} else {
			return false;
		}

	}

}



using System;
using System.Collections.Generic;
using UnityEngine;
public class ColorUtils
{
		
	public static Color GetColor(ColorLight colorLight){

		switch (colorLight) {
			case ColorLight.Blue:
			return GetColorFromHex("#579DD6");
			case ColorLight.Green:
			return  GetColorFromHex("#97FFAB");
			case ColorLight.Orange:
				return GetColorFromHex("#FF994D");
			case ColorLight.Purple:
				return GetColorFromHex("#CC8BF7");
			case ColorLight.Red:
				return GetColorFromHex("#EA503D");
			case ColorLight.Yellow:
			return GetColorFromHex("#F4E572");
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



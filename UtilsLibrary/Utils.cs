using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsLibrary
{
	public static class Utils
	{
		public static string RemoveAccents(this string text)
		{
			if (text is null)
			{
				return null;
			}
			StringBuilder sbReturn = new StringBuilder();
			char[] arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
			foreach (char letter in arrayText)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
					sbReturn.Append(letter);
			}
			return sbReturn.ToString().ToLower();
		}
	}
}

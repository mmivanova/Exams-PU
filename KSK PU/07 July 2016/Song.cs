using System;
using System.Collections.Generic;
using System.Text;

namespace _07_July_2016
{
	class Song
	{
		private string name;
		private int style;
		private string singer;
		private int year;
		private string album;
		private int times;

		public Song(string name, int style, string singer, int year, string album, int timesOnAir)
		{
			this.Name = name;
			this.Style = style;
			this.Singer = singer;
			this.Year = year;
			this.Album = album;
			this.TimesOnAir = timesOnAir;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Style
		{
			get { return style; }
			set { style = value; }
		}

		public string Singer
		{
			get { return singer; }
			set { singer = value; }
		}

		public int Year
		{
			get { return year; }
			set { year = value; }
		}

		public string Album
		{
			get { return album; }
			set { album = value; }
		}

		public int TimesOnAir
		{
			get { return times; }
			set { times = value; }
		}

		public string GetStyle()
		{
			int styleByInt = this.Style;
			string style = null;

			switch (styleByInt)
			{
				case 1:
					style = "джаз";
					break;
				case 2:
					style = "поп";
					break;
				case 3:
					style = "рок";
					break;
				case 4:
					style = "фолк";
					break;
				case 5:
					style = "класика";
					break;
				default:
					break;
			}
			return style;
		}

		public override string ToString()
		{
			string printText = Name + "; " + Style + "; " + Singer + "; " + Year + "; " + Album + "; " + TimesOnAir;
			return printText;
		}
	}
}

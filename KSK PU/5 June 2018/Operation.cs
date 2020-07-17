using System;
using System.Collections.Generic;
using System.Text;

namespace _5_June_2018
{
    class Operation
    {
		private string nameOfOperator;
		private DateTime date;
		private int type;
		private string comment;

		public Operation(string operat, DateTime date, int type, string comment)
		{
			this.Operator = operat;
			this.Date = date;
			this.Type = type;
			this.Comment = comment;
		}

		public string Operator
		{
			get { return nameOfOperator; }
			set { nameOfOperator = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}
		//yyyy.MM.dd HH:mm

		public int Type
		{
			get { return type; }
			set { type = value; }
		}

		public string Comment
		{
			get { return comment; }
			set { comment = value; }
		}

		public string GetType()
		{
			int typeByInt = this.Type;
			string type = null;

			switch (typeByInt)
			{
				case 1:
					type = "нови данни";
					break;
				case 2:
					type = "промяна на данни";
					break;
				case 3:
					type = "изтриване на данни";
					break;
				case 4:
					type = "справка с лични данни";
					break;
				default:
					break;
			}
			return type;
		}

		public override string ToString()
		{
			string printText = Date.ToString("yyyy.MM.dd; HH:mm") + "; " + Operator + ", " + GetType() + ", " + Comment;
			return printText;
		}
	}
}

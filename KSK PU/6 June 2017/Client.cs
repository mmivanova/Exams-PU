using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6_June_2017
{
    class Client
    {
        private string name;
        private string city;
        private string code;

        public Client(string name, string city, string code)
        {
            this.Name = name;
            this.City = city;
            this.Code = code;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string GetProduct()
        {
            char index = this.Code.ElementAt(0);
            string product = null;
            switch (index)
            {
                case '1':
                    product = "козметика";
                    break;
                case '2':
                    product = "парфюми";
                    break;
                case '3':
                    product = "аксесоари";
                    break;
                case '4':
                    product = "услуги";
                    break;
                default:
                    break;
            }
            return product;
        }


        public string GetCode()
        {
            char index = this.Code.ElementAt(1);
            string code = null;
            switch (index)
            {
                case '0':
                    code = "без натрупване";
                    break;
                case '1':
                    code = "с натрупване";
                    break;
                default:
                    break;
            }
            return code;
        }

        public double GetPercent()
        {
            string index = this.Code.Substring(2, 2);
            double percent = 0;
            switch (index)
            {
                case "05":
                    percent = 05;
                    break;
                case "10":
                    percent = 10;
                    break;
                case "20":
                    percent = 20;
                    break;
                case "30":
                    percent = 30;
                    break;
                default:
                    break;
            }
            return percent;
        }

        public DateTime GetDate()
        {
            int day = int.Parse(this.Code.Substring(4, 2));
            int month = int.Parse(this.Code.Substring(6, 2));
            int year = int.Parse(this.Code.Substring(8, 2));

            DateTime date = new DateTime(year, month, day);

            return date;
        }

        public override string ToString()
        {
            string printText = Name + ", " + City + ", " + GetProduct() + ", " + GetCode() + ", " + GetPercent() + ", " + GetDate().ToString("dd.MM.yy");
            return printText;
        }

    }
}

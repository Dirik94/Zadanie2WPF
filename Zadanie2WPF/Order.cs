using System;

namespace Zadanie2WPF
{
    internal class Order
    {
        public int Count { get; set; } = 0;
        public string Format { get; set; } = "A5";
        public string Gramatura { get; set; } = "80 g/m²";
        public string PrintType { get; set; } = "Normalny";
        public string Color { get; set; } = "Biały";
        public string CzasWykonania { get; set; } = "Standard";
        public double Discount
        {
            get
            {
                if(Count >= 100 && Count < 200)
                {
                    return 1;
                }
                else if (Count >= 200 && Count < 300)
                {
                    return 2;
                }
                else if(Count >= 300 && Count < 400)
                {
                    return 3;
                }
                else if (Count >= 400 && Count < 500)
                {
                    return 4;
                }
                else if (Count >= 500 && Count < 600)
                {
                    return 5;
                }
                else if (Count >= 600 && Count < 700)
                {
                    return 6;
                }
                else if (Count >= 700 && Count < 800)
                {
                    return 7;
                }
                else if (Count >= 800 && Count < 900)
                {
                    return 8;
                }
                else if (Count >= 900 && Count < 1000)
                {
                    return 9;
                }
                else if (Count >= 1000)
                {
                    return 10;
                }
                else
                {
                    return 0;
                }
            }
            private set { }
        }
        public double FinalPrice
        {
            get
            {
                return Count * BasePrice * Bonus * (1 - (Discount/10)/10) * NumerGramatury + CzasWykonaniaAddedCost;
            }
            private set { }
        }

        public double BasePriceNoDiscount
        {
            get
            {
                return Count * BasePrice * Bonus * NumerGramatury + CzasWykonaniaAddedCost;
            }
            private set { }
        }

        public double BasePrice { get; set; } = 0.2;
        public double NumerGramatury { get; set; } = 1;
        public double Bonus { get; set; } = 1;
        public int CzasWykonaniaAddedCost { get; set; } = 0;

        public override string ToString()
        {
            return "Przedmiot zamówienia: " + Count + " szt." + ", Format: " + Format + ", Gramatura: " + Gramatura + "\n" + "Czas realizacji: " + CzasWykonania + ", Papier: " + Color + "\n"
                + "Cena przed rabatem: " + Math.Round(BasePriceNoDiscount,2) + "zł\n" + "Naliczony rabat: " + Discount + "%\n"
                + "Cena po rabacie: " + Math.Round(FinalPrice, 2).ToString("0.00") + "zł";
        }
    }
}

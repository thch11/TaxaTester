using System;
using System.Collections.Generic;
using System.Text;

namespace TaxaStation
{
    public class Card
    {
        public string URL;

        public int value;

        public Card(int value, int type)
        {
            this.URL = "/Images/" + value + "-" + type + ".jpg";
            if (value > 10)
                value = 10;
            if (value == 1)
                value = 11;
            this.value = value;
        }

    }
}

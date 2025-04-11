using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoroninEkz
{
    public class Discount
    {
        public int FoundDiscount(double sales)
        {
            if (sales < 10000)
            {
                return 0;
            }
            else if (sales >= 10000 && sales < 50000)
            {
                return 5;
            }
            else if (sales >= 50000 && sales < 300000)
            {
                return 10;
            }
            else
            {
                return 15;
            }
        }
    }
}

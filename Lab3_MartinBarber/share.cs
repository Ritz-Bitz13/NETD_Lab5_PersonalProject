using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_MartinBarber
{
    class share : IShares
    {
        public string buyerName;
        public string buyDate;


        // getter and setters
        public string BuyerName
        {
            get { return this.buyerName; }
            set { this.buyerName = value; }
        }

        public string BuyDate
        {
            get { return this.buyDate; }
            set { this.buyDate = value; }
        }

        public share()
        {
        }

        public share(string buyer, string date)
        {
            this.buyerName = buyer;
            this.buyDate = date;
        }

        public virtual int calculateShare()
        {
            int total = 30;
            return total;
        }



    }
}

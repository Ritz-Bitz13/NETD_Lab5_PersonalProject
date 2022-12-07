using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_MartinBarber
{
    class PreferredShare : share
    {
        public int prefShares;
        public string shareType;
        public int votingPower;
        public int price;


        public int PrefShares
        {
            get { return this.prefShares; }
            set { this.prefShares = value; }
        }

        public string ShareType
        {
            get { return this.shareType; }
            set { this.shareType = value; }
        }

        public int VotingPower
        {
            get { return this.votingPower; }
            set { this.votingPower = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        const int comShare = 50;


        public PreferredShare(string buyerName, int prefShares, string buyDate, string shareType, int price, int power)
        {
            this.buyerName = buyerName;
            this.buyDate = buyDate;
            this.prefShares = prefShares;
            this.shareType = shareType;
            this.price = price;
            this.votingPower = power;
        }

        public override int calculateShare()
        {
            int total = comShare * prefShares;
            return total;
        }
    }
}

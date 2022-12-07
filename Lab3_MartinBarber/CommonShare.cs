using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_MartinBarber
{
    class CommonShare : share
    {
        public int commonShares;
        public string shareType;
        public int votingPower;
        public int price;


        public int CommonShares
        {
            get { return this.commonShares; }
            set { this.commonShares = value; }
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

        const int comShare = 25;


        public CommonShare(string buyerName, int commonShares, string buyDate, string shareType, int price, int power)
        {
            this.buyerName = buyerName;
            this.buyDate = buyDate;
            this.commonShares = commonShares;
            this.shareType = shareType;
            this.price = price;
            this.votingPower = power;
        }

        public override int calculateShare()
        {
            int total = comShare * commonShares;
            return total;
        }
    }
}

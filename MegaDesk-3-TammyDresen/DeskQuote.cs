using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_TammyDresen
{
    class DeskQuote
    {
        // This class will define the attributes of a quote including Desk,
        // rush days, customer name, and quote date. This class will also hold the
        // logic in determining the line item cost.
        #region member variables
        private string CustomerName;
        private DateTime QuoteDate;
        private int TurnAround;
        private Desk Desk = new Desk();
        #endregion

        #region constants
        private const int PRICE_BASE = 200;
        private const int PRICE_DRAWER = 50;
        private const int PRICE_SQ_FOOT = 1;
        private const int BASE_SIZE = 1000;
        private const int OAK = 200;
        private const int LAMINATE = 100;
        private const int PINE = 50;
        private const int ROSEWOOD = 300;
        private const int VENEER = 125;
        private readonly int[,] RUSH_FEE = new int[3, 3]
            {
                { 60, 70, 80 },
                { 40, 50, 60 },
                { 30, 35, 40 }
            };
        #endregion
        public QuoteInfo(string name, DateTime date)
        {
            CustomerName = name;
            QuoteDate = date;
        }
        public DeskQuote(int width, int depth, int drawers, string finish,
            int rushDays)
        {
            Desk.Width = width;
            Desk.Depth = depth;
            Desk.Drawers = drawers;
            Desk.Finish = finish;
            TurnAround = rushDays; 
        }
        
        public int CalculateQuotePrice()
        {
            return PRICE_BASE + SurfaceAreaCost() + DrawerCost() + FinishCost() + RushFee();
        }

        public int SurfaceAreaCost()
        {
            int surfaceArea = Desk.Width + Desk.Depth;
            int cost;
            if (surfaceArea > BASE_SIZE)
            {
                return cost = (surfaceArea - BASE_SIZE) * PRICE_SQ_FOOT; 
            }
            else
            {
                return cost = 0;
            }   
        }
        
        public int DrawerCost()
        {
            return Desk.Drawers * PRICE_DRAWER;
        }

        public int FinishCost()
        {
            int cost = 0;
            switch (Desk.Finish)
            {
                case "Oak":
                    cost = OAK;
                    break;
                case "Laminate":
                    cost = LAMINATE;
                    break;
                case "Pine":
                    cost = PINE;
                    break;
                case "Rosewood":
                    cost = ROSEWOOD;
                    break;
                case "Veneer":
                    cost = VENEER;
                    break;
            }
            return cost;
        }

        public int RushFee()
        {
            int surfaceArea = Desk.Width * Desk.Depth;
            if (TurnAround == 3)
            {
                if (surfaceArea > 2000)
                {
                    return RUSH_FEE[0, 2];
                }
                else if (surfaceArea > 1000)
                {
                    return RUSH_FEE[0, 1];
                }
                else
                {
                    return RUSH_FEE[0, 0];
                }
            }
            else if (TurnAround == 5)
            {
                if (surfaceArea > 2000)
                {
                    return RUSH_FEE[1, 2];
                }
                else if (surfaceArea > 1000)
                {
                    return RUSH_FEE[1, 1];
                }
                else
                {
                    return RUSH_FEE[1, 0];
                }
            }
            else if (TurnAround == 7)
            {
                if (surfaceArea > 2000)
                {
                    return RUSH_FEE[2, 2];
                }
                else if (surfaceArea > 1000)
                {
                    return RUSH_FEE[2, 1];
                }
                else
                {
                    return RUSH_FEE[2, 0];
                }
            }
            else
            {
                return 0;
            }
        }
    }
}

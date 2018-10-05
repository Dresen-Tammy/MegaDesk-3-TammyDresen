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
        private string CustomerName { get; set; }
        private DateTime QuoteDate { get; set; }
        private int TurnAround { get; set; }
        private int QuotePrice { get; set; }
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


        public DeskQuote(int width, int depth, int drawers, string finish,
            int rushDays, string name)
        {
            // save inputs to desk object
            Desk.Width = width;
            Desk.Depth = depth;
            Desk.Area = width * depth;
            Desk.Drawers = drawers;
            TurnAround = rushDays;
            // convert finish string to enum and save to desk object
            /*if (Enum.TryParse(finish, out Desk.SurfaceMaterials surfaceMaterial)) {
                Desk.Finish = (Desk.SurfaceMaterials)surfaceMaterial; */
            Desk.Finish = finish;

            // save name and date to quote
            CustomerName = name;
            QuoteDate = DateTime.Now.Date;

            // figure quote price
            QuotePrice = CalculateQuotePrice();

        }
        
        public int CalculateQuotePrice()
        {
            return PRICE_BASE + SurfaceAreaCost() + DrawerCost() + FinishCost() + RushFee();
        }

        // figure cost of surface area larger than 1000sf
        public int SurfaceAreaCost()
        {
            if (Desk.Area > BASE_SIZE)
            {
                return  (Desk.Area - BASE_SIZE) * PRICE_SQ_FOOT; 
            }
            else
            {
                return 0;
            }   
        }
        
        // calculate price of drawers
        public int DrawerCost()
        {
            return Desk.Drawers * PRICE_DRAWER;
        }

        // get int value from enum for finish type
        public int FinishCost()
        {
            int cost = 0;
            switch (Desk.Finish)
            {
                case "Oak":
                    cost = 200;
                    break;
                case "Laminate":
                    cost = 100;
                    break;
                case "Pine":
                    cost = 50;
                    break;
                case "Rosewood":
                    cost = 300;
                    break;
                case "Veneer":
                    cost = 125;
                    break;
            }
            return cost;
            //return (int)Desk.Finish;
        }

        // calculate rush fee based on surface area and speed
        public int RushFee()
        {
            // set size index based on surface area
            int sizeIndex;
            if (Desk.Area < 1000)
            {
                sizeIndex = 0;
            }
            else if (Desk.Area <= 2000)
            {
                sizeIndex = 1;
            }
            else
            {
                sizeIndex = 2;
            }
            // return rush fee based on sizeIndex and speed
            if (TurnAround == 3)
            {
                return RUSH_FEE[0, sizeIndex];
               
            }
            else if (TurnAround == 5)
            {
                return RUSH_FEE[1, sizeIndex]; 
            }
            else if (TurnAround == 7)
            {
                return RUSH_FEE[2, sizeIndex];
            }
            else
            {
                return 0;
            }
        }
    }
}

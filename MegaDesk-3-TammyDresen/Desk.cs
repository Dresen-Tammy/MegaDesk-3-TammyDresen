using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_TammyDresen
{
    class Desk
    {
        // This class will define the attributes of the desk object with width, depth,
        // number of drawers, and the surface material.
        // may contain validation of those attributes.
        public int Width { get; set;}
        public int Depth { get; set;}
        public int Drawers { get; set;}
        //public SurfaceMaterials Finish { get; set; }
        public string Finish { get; set; }
        public int Area { get; set; }

        public enum SurfaceMaterials
        {
            Oak = 200,
            Laminate = 100,
            Pine = 50,
            Rosewood = 300,
            Veneer = 125
        }
      

    }
}

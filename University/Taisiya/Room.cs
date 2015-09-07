using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    enum Building { A, B, C, D }

    class Room: IRoom
    {
        private Building building;
        private int Number;

        public Room(Building b, int Number)
        {
            building = b;
            this.Number = Number;
        }

        public string Id
        {
            get { return building.ToString() + Number; }
        }
    }
}

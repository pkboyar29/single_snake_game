using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Circle
    {
        /// <summary>
        /// расположение по ширине на pictureBox
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// расположение по высоте на pictureBox
        /// </summary>
        public int Y { get; set; }

        public Circle()
        {
            X = -1;
            Y = 0;
        }
    }
}

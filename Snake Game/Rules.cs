using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();


            label1.Text = 
                "Цель игры - заработать как можно больше очков." + Environment.NewLine +
                "Змейка перемещается по плоскости карты. На ней располагается одна единица еды, при её поедании, на карте появится снова одна единица еды, только в другом месте. Одна единица еды увеличивает количество очков змейки и её длину на единицу. Еда выделяется красным кружком." 
                + Environment.NewLine + 
                "На карте располагаются различные барьеры, при столкновении с которыми змейка умирает и игра заканчивается. Барьеры выделяются чёрными кружками. При столкновении с границей плоскости змейка не будет умирать, а окажется на противоположном конце плоскости." + 
                Environment.NewLine + 
                "Также когда змейка стокнётся с собой же, игра также заканчивается, и игрок проигрывает."
                + Environment.NewLine 
                + "На карте также располагаются бустеры, при их поедании скорость змейки увеличивается на некоторое время"
                + Environment.NewLine
                + "Добившись какого-то результата в игре, можно сделать его скриншот и поделиться с друзьями.";
        }
    }
}

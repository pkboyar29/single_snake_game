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
    public partial class Managment : Form
    {
        public Managment()
        {
            InitializeComponent();
            label1.Text = "↑ - Передвижение вверх" + 
              Environment.NewLine + "↓ - Передвижение вниз" + 
              Environment.NewLine + "← - Передвижение влево" +
              Environment.NewLine + "→ - Передвижение вправо" +
              Environment.NewLine + "Пробел - пауза";
        }
    }
}

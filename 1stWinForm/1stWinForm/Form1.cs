using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1stWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            mapWPFControlxaml1.Map.CredentialsProvider = new ApplicationIdCredentialsProvider("AtQmVGGXGavd7exw2ycm8-7cpJ4c2nHF-GA-Kx277uCf69290qX-lQFoloDPLdT5");
        }
    }
}

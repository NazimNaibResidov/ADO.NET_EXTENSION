using MyEntity.Main;
using System;


using System.Windows.Forms;

namespace MyEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Urunler urunler = new Urunler();
          var data=  urunler.Select();
            foreach (var item in data)
            {
                Console.Write(item);
            }
          


        }
    }
}

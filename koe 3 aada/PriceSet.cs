using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace koe_3_aada
{
    public partial class PriceSet : Form
    {
        public PriceSet()
        {
            InitializeComponent();
        }

        private void PriceSet_Load(object sender, EventArgs e)
        {
            /* hakee hinnat ekasta formista kun formi avataan */
            txt_perfettaPrice.Text = Form1.Perfetta.ToString();
            txt_americanaPrice.Text = Form1.Americana.ToString();
            txt_burgerPrice.Text = Form1.Burger.ToString();
            txt_jLihaPrice.Text = Form1.Jauheliha.ToString();
            txt_kanaPrice.Text = Form1.Kana.ToString();
            txt_pepperoniPrice.Text = Form1.Pepperoni.ToString();
            txt_kebabPrice.Text = Form1.Kebab.ToString();
            txt_juustoPrice.Text = Form1.Juusto.ToString();
            txt_pekoniPrice.Text = Form1.Pekoni.ToString();
            txt_lihamestariPrice.Text = Form1.Lihamestari.ToString();
        }

        private void btn_sendPrice_Click(object sender, EventArgs e)
        {
            /* lähettää muutetut hinnat ekaan formiin */
            Form1.Perfetta = double.Parse(txt_perfettaPrice.Text);
            Form1.Americana = double.Parse(txt_americanaPrice.Text);
            Form1.Burger = double.Parse(txt_burgerPrice.Text);
            Form1.Jauheliha = double.Parse(txt_jLihaPrice.Text);
            Form1.Kana = double.Parse(txt_kanaPrice.Text);
            Form1.Pepperoni = double.Parse(txt_pepperoniPrice.Text);
            Form1.Kebab = double.Parse(txt_kebabPrice.Text);
            Form1.Juusto = double.Parse(txt_juustoPrice.Text);
            Form1.Pekoni = double.Parse(txt_pekoniPrice.Text);
            Form1.Lihamestari = double.Parse(txt_lihamestariPrice.Text);


        }
    }
}

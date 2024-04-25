namespace koe_3_aada
{/* tee pitsalaskuri, jota voisi periaatteessa k‰ytt‰‰ oikeassa pizzeriassa */
    public partial class Form1 : Form
    { /* valmiit hinnat, jota voi k‰ytt‰‰ myˆs muissa formeissa. samat hinnat kun "t‰yt‰" napissa. 
       * hinnat ovat silti muutettavissa kun ohjelma on k‰ynniss‰. */
        public static double Perfetta = 11.90;
        public static double Americana = 13.40;
        public static double Burger = 13.90;
        public static double Jauheliha = 11.90;
        public static double Kana = 14.90;
        public static double Pepperoni = 12.90;
        public static double Kebab = 14.60;
        public static double Juusto = 14.90;
        public static double Pekoni = 16.90;
        public static double Lihamestari = 15.40;

        /* mainitaan array johon numericupdown tiedot voi s‰ilˆ‰ */
        private NumericUpDown[] quantity;

        public Form1()
        {
            InitializeComponent();

            /* alustaa arrayn vastaavilla numUD arvoilla */
            quantity = new NumericUpDown[]
            {
                numUD_perfetta,
                numUD_americana,
                numUD_burger,
                numUD_jLiha,
                numUD_kana,
                numUD_pepperoni,
                numUD_kebab,
                numUD_juusto,
                numUD_pekoni,
                numUD_lihamestari
            };
        }

        private void btn_changePrice_Click(object sender, EventArgs e)
        {/* avaa uuden formin, jossa voi muokata pitsojen hintoja */

            /* hintalomakkeen uusi ilmentym‰ */
            PriceSet priceSet = new PriceSet();
            priceSet.Show();

            try
            {/* k‰yt‰n parsimiseen convert.todoublea koska sit‰ on mukavampi ja nopeampi k‰ytt‰‰ */
                double perfettaP = Convert.ToDouble(txt_perfettaDisplay.Text);
                double americanaP = Convert.ToDouble(txt_americanaDisplay.Text);
                double burgerP = Convert.ToDouble(txt_burgerDisplay.Text);
                double jLihaP = Convert.ToDouble(txt_jLihaDisplay.Text);
                double kanaP = Convert.ToDouble(txt_kanaDisplay.Text);
                double pepperoniP = Convert.ToDouble(txt_pepperoniDisplay.Text);
                double kebabP = Convert.ToDouble(txt_kebabDisplay.Text);
                double juustoP = Convert.ToDouble(txt_juustoDisplay.Text);
                double pekoniP = Convert.ToDouble(txt_pekoniDisplay.Text);
                double lihamestariP = Convert.ToDouble(txt_lihamestariDisplay.Text);
            }

            catch (FormatException ex)
            { /* ohjelma herjaa/herjasi jotain jostain syyst‰, mutta se silti toimii joten lis‰sin t‰m‰n errorin,
               * ett‰ ohjelman k‰yttˆ‰ voi jatkaa
               
               * UPDATE ei herjaa en‰‰ mutta en uskalla ottaa t‰t‰ pois */
                MessageBox.Show($"Virhe {ex.Message}", "virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_refreshPrice_Click(object sender, EventArgs e)
        {
            try
            {
                /* p‰ivitt‰‰ hinnat n‰kyviksi GUI:in */
                txt_perfettaDisplay.Text = Perfetta.ToString();
                txt_americanaDisplay.Text = Americana.ToString();
                txt_burgerDisplay.Text = Burger.ToString();
                txt_jLihaDisplay.Text = Jauheliha.ToString();
                txt_kanaDisplay.Text = Kana.ToString();
                txt_pepperoniDisplay.Text = Pepperoni.ToString();
                txt_kebabDisplay.Text = Kebab.ToString();
                txt_juustoDisplay.Text = Juusto.ToString();
                txt_pekoniDisplay.Text = Pekoni.ToString();
                txt_lihamestariDisplay.Text = Lihamestari.ToString();
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            try
            {/* t‰ytt‰‰ pitsojen hinnat valmiiksi ohjelman demoamisen helpottamiseksi */
                double perfettaFill = 11.90;
                double americanaFill = 13.40;
                double burgerFill = 13.90;
                double jLihaFill = 11.90;
                double kanaFill = 14.90;
                double pepperoniFill = 12.90;
                double kebabFill = 14.60;
                double juustoFill = 14.90;
                double pekoniFill = 16.90;
                double lihamestariFill = 15.40;


                txt_perfettaDisplay.Text = perfettaFill.ToString();
                txt_americanaDisplay.Text = americanaFill.ToString();
                txt_burgerDisplay.Text = burgerFill.ToString();
                txt_jLihaDisplay.Text = jLihaFill.ToString();
                txt_kanaDisplay.Text = kanaFill.ToString();
                txt_pepperoniDisplay.Text = pepperoniFill.ToString();
                txt_kebabDisplay.Text = kebabFill.ToString();
                txt_juustoDisplay.Text = juustoFill.ToString();
                txt_pekoniDisplay.Text = pekoniFill.ToString();
                txt_lihamestariDisplay.Text = lihamestariFill.ToString();
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }

        private void btn_eqReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                /* laskee kaikki listboxin itemit yhteen ja n‰ytt‰‰ tilauken loppuhinnan, sek‰ lis‰‰ sen "kassaan" */
                double orderTotal = 0;
                double dayTotal = 0;

                foreach (var item in lbox_receipt.Items)
                {
                    double value = double.Parse(item.ToString());
                    orderTotal += value;
                }

                txt_orderTotal.Text = orderTotal.ToString("F2");
                lbox_cashRegister.Items.Add(orderTotal.ToString("F2"));

                /* laskee kassan itemit yhteen ja n‰ytt‰‰ koko p‰iv‰n tulot textboxissa */
                foreach (var item in lbox_cashRegister.Items)
                {
                    double value = double.Parse(item.ToString());
                    dayTotal += value;
                }
                txt_dayTotal.Text = dayTotal.ToString("F2");
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }

        private void btn_addToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                /* lis‰‰ asiakkaan pitsan/pitsat tilaukseen Lisaa-aliohjelmalla */
                Lisaa(numUD_perfetta, txt_perfettaDisplay);
                Lisaa(numUD_americana, txt_americanaDisplay);
                Lisaa(numUD_burger, txt_burgerDisplay);
                Lisaa(numUD_jLiha, txt_jLihaDisplay);
                Lisaa(numUD_kana, txt_kanaDisplay);
                Lisaa(numUD_pepperoni, txt_pepperoniDisplay);
                Lisaa(numUD_kebab, txt_kebabDisplay);
                Lisaa(numUD_juusto, txt_juustoDisplay);
                Lisaa(numUD_pekoni, txt_pekoniDisplay);
                Lisaa(numUD_lihamestari, txt_lihamestariDisplay);
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }


        private void Lisaa(NumericUpDown numUD, TextBox txtDisplay)
        {/* en lis‰nnyt t‰‰n virheentarkistusta, koska se on jo tuossa napissa miss‰ t‰t‰ funktiota k‰ytet‰‰n */

            /* aliohjelma, joka lis‰‰ pitsan/pitsat tilaukseen */
            if (numUD.Value > 0)
            {
                /* tarkistaa onko tilauksessa liikaa pitsoja, jos on niin se heitt‰‰ ilmoituksen n‰ytˆlle,
                 * mutta en osannut est‰‰ pitsojen lis‰‰mist‰ vaikka pitsoja on max m‰‰r‰ */
                if (lbox_receipt.Items.Count < 10)
                {
                    double price, amount;
                    price = Convert.ToDouble(txtDisplay.Text);
                    amount = (double)numUD.Value;

                    /* lis‰‰ pitsan hinnan tilaukseen yksi kerrallaan */
                    for (int i = 0; i < amount; i++)
                    {

                        /* lis‰‰ pitsan hintaan lis‰t‰ytteen hinnan jos se on valittu */
                        if (cbox_ananas.Checked)
                        {
                            price += 0.5;
                        }

                        if (cbox_majoneesi.Checked)
                        {
                            price += 0.5;
                        }

                        if (cbox_juusto.Checked)
                        {
                            price += 1;
                        }

                        lbox_receipt.Items.Add(price);

                        /* lis‰‰ pizzapassiin merkkej‰ pitsojen m‰‰r‰n verran  */
                        lbox_pizzaPassi.Items.Add("+");

                        if (lbox_pizzaPassi.Items.Count >= 6)
                        {/* en osannut laskea alennusta, mutta ohjelma n‰ytt‰‰ messageboksin joka kuudennen itemin
                          * kohdalla ja sitten tyhjent‰‰ passin */
                            object freePizza = lbox_pizzaPassi.Items[5];
                            MessageBox.Show("Saat seuraavan pitsan -50%!");

                            lbox_pizzaPassi.Items.Clear();


                        }
                    }
                }
                else { MessageBox.Show("Tilauksessa voi olla max 10 pitsaa"); }
            }
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            try
            {
                /* nappi poistaa viimeisimm‰n lis‰yksen listboksista */
                if (lbox_receipt.Items.Count > 0)
                {
                    lbox_receipt.Items.RemoveAt(lbox_receipt.Items.Count - 1);
                }
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }

        private void btn_pieniJuoma_Click(object sender, EventArgs e)
        {
            try
            {/* lis‰‰ juoman hinnan listboxiin kun nappia painetaan */
                double pieniJuoma = 2;
                lbox_receipt.Items.Add(pieniJuoma);
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }

        private void btn_isoJuoma_Click(object sender, EventArgs e)
        {
            try
            {
                /* lis‰‰ juoman hinnan listboxiin kun nappia painetaan */
                double isoJuoma = 4;
                lbox_receipt.Items.Add(isoJuoma);
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }


        private void btn_reset_Click(object sender, EventArgs e)
        {
            try
            {
                /* nollaa numUD kohtien arvot */
                foreach (NumericUpDown numUD in quantity)
                {
                    numUD.Value = 0;
                }

                /* uncheckkaa chekcboksit */
                cbox_ananas.Checked = false;
                cbox_juusto.Checked = false;
                cbox_majoneesi.Checked = false;

                /* tyhjent‰‰ listboxin */
                lbox_receipt.Items.Clear();

                txt_orderTotal.Text = string.Empty;
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }

        private void btn_resetRegister_Click(object sender, EventArgs e)
        {
            try
            {
                /* nollaa kassan */
                txt_dayTotal.Text = string.Empty;
                lbox_cashRegister.Items.Clear();
            }

            catch (Exception) { MessageBox.Show("Virhe"); }
        }
    }
}

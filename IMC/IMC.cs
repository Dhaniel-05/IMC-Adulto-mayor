using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMC
{
    public partial class IMC : Form
    {
        
        public IMC()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            //Para el cálculo se debe iniciar con comas.
            //Para calular es IMC, Vamos a 
            //colocar unos condicionales para que se vean en una ventana emergente
            //y que le muestre al usuario la clasificación en la que se encuentra
            //según su IMC.
            if (String.IsNullOrEmpty(TxtPeso.Text))
            {
                MessageBox.Show("Digite su peso", "Notificación");
                this.TxtPeso.Focus();
            }
            else if (String.IsNullOrEmpty(TxtEstatura.Text))
            {
                MessageBox.Show("Digite su estatura", "Notificación");
                this.TxtEstatura.Focus();
            }
            try
            {

                double Peso;
                Peso = double.Parse(this.TxtPeso.Text);
                double Estatura;
                Estatura = double.Parse(this.TxtEstatura.Text);
                double IMC;
                IMC = Peso / (Math.Pow(Estatura, 2) / 10000);

                this.TxtIMC.Text = IMC.ToString();

                if (IMC < 18.5)
                {
                    MessageBox.Show("Usted tiene Desnutrición", "Notificación");
                }
                else if (IMC >= 18.5 && IMC < 22)
                {
                    MessageBox.Show("Usted tiene Peso Insuficiente", "Notificación");
                }
                else if (IMC >= 22 && IMC < 27)
                {
                    MessageBox.Show("Usted tiene Peso Normal", "Notificación");
                }
                else if (IMC >= 27 && IMC < 30)
                {
                    MessageBox.Show("Usted tiene Sobrepeso", "Notificación");
                }
                else
                {
                    MessageBox.Show("Usted tiene Obesidad", "Notificación");
                }
            }
            catch (Exception)
            {

            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.TxtPeso.Text = String.Empty;
            this.TxtEstatura.Text = String.Empty;
            this.TxtIMC.Text = String.Empty;
        }



        private void ValidarPeso(object sender, KeyPressEventArgs e)
        {
            //Para que el usuario no digite ni punto, ni letras, ni símbolos, se utiliza este código de validación.

            if (e.KeyChar == '.' || Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void ValidarEstatura(object sender, KeyPressEventArgs e)
        {
            //Para que el usuario no digite ni punto, ni letras, ni símbolos, se utiliza este código de validación.
            
            //if (e.KeyChar == '.' || Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }
    }
}

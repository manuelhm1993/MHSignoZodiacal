using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MHSignoZodiacal.Controllers;

namespace MHSignoZodiacal.Views
{
    public partial class SignoZodiacalView : Form
    {
        #region Métodos
        public SignoZodiacalView()
        {
            InitializeComponent();
            Reset();

            SignoZodiacalController.FormSignoZodiacal = this;
            SignoZodiacalController.SetMeses();
        }

        private void Reset()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            txtSalida.Text = String.Empty;

            // Establecer los valores por defecto de los combos
            this.comboMes.SelectedIndex = 0;
            this.comboDia.SelectedIndex = 0;

            // Desactivar componentes
            this.txtSalida.Enabled = false;
            this.btnConsultar.Enabled = false;
            this.btnResetear.Enabled = false;
            this.comboDia.Enabled = false;

            // Ocultar componentes
            this.txtSalida.Visible = false;
        }

        private void PrintOutput()
        {
            if(this.comboDia.SelectedIndex != 0)
            {
                string mes = this.comboMes.Text;
                int dia = Int32.Parse(this.comboDia.Text);

                txtSalida.Visible = true;

                // MVC Completo
                SignoZodiacalController.SetDescripcionSigno(mes, dia);
            }
            else
            {
                txtSalida.Visible = false;
                txtSalida.Text = String.Empty;
            }
        }
        #endregion

        #region Eventos
        private void comboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalida.Text = String.Empty;

            if(this.comboMes.SelectedIndex != 0)
            {
                this.comboDia.Enabled = true;

                SignoZodiacalController.SetDias(this.comboMes.Text);
            }
            else
            {
                this.comboDia.Enabled = false;
                this.comboDia.SelectedIndex = 0;
            }
        }

        private void comboDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalida.Text = String.Empty;
            bool isDay = (this.comboDia.SelectedIndex != 0);

            if (btnConsultar.Enabled && isDay)
            {
                PrintOutput();
            }
            else
            {
                btnConsultar.Enabled = isDay;
                btnResetear.Enabled = isDay;
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            PrintOutput();
        }
        #endregion
    }
}

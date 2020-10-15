using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.txtResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lblEquation.Text = "";
            Calculator.Initialize(this.txtResult, this.lblEquation);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string stringValue = ((Button)sender).Text;
            Calculator.Put(stringValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Calculator.Clear();
        }
    }
}

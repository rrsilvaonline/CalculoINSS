using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSS.Context;
using INSS.Services;
using INSS.Repository;
using INSS.Interfaces.Repository;
using INSS.Interfaces.Services;

namespace PrgCalculoINSS
{
    public partial class FrmCalculoINSS : Form
    {
        private readonly IParametroAliquotaService _parametroAliquotaService;
        private readonly ICalculadorInss _calculadorInss;

        public FrmCalculoINSS(IParametroAliquotaService parametroAliquotaService, ICalculadorInss calculadorInss)
        {
            InitializeComponent();
            _parametroAliquotaService = parametroAliquotaService;
            _calculadorInss = calculadorInss;
            lblResultado.Text = "";
            lblSalarioDescontado.Text = "";

            String vTitulo = "Desenvolvido por Rômulo Ribeiro da Silva" + System.Environment.NewLine;
            vTitulo += "Consultor de TI / Arquiteto de Software / Gerente de Sistemas / Gerente de TI" + System.Environment.NewLine;
            vTitulo += "Tel.: (21)97285-1647" + System.Environment.NewLine;
            vTitulo += "E-mail: rrsilva.mronline@gmail.com / rrsilva.mrac.online@gmail.com";

            lblTitulo.Text = vTitulo;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (mskTxtSalario.Text == String.Empty)
            {
                MessageBox.Show("Informar o valor do salário",
                                "Cáculo de INSS",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                DateTime vdata = dtpData.Value;
                decimal vValorDesconto = _calculadorInss.CalcularDesconto(vdata, Convert.ToDecimal(mskTxtSalario.Text));
                decimal vValorSalDescontado = Convert.ToDecimal(mskTxtSalario.Text) - vValorDesconto;
                lblResultado.Text = vValorDesconto.ToString("C");
                lblSalarioDescontado.Text = vValorSalDescontado.ToString("C");
            }
        }

        private void FrmCalculoINSS_Load(object sender, EventArgs e)
        {
            var listaParametros = _parametroAliquotaService.GetAll();
            dataGridView1.DataSource = listaParametros;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }
    }
}

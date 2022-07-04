using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace sqlreport
{
    public partial class frm_castegoria : Form
    {
        public frm_castegoria()
        {
            InitializeComponent();
            

        }
        private void formato_ca()
        {
            dataview.Columns[0].Width = 80;
            dataview.Columns[0].HeaderText = "Codigo";
            dataview.Columns[1].Width = 250;
            dataview.Columns[1].HeaderText = "Categorias";

        }
        #region "mi variable"
        int Estadodoguardo = 0;
        int ncodigo = 0;

        #endregion
        #region "Mis Metodos"
        public void Listar_ca(String cTexto)
        {

         dataview.DataSource = N_categoriascs.Listar_ca(cTexto);
            this.formato_ca();


        }
        private void Estado(bool lEstado)
        {
            txtcat.Enabled = lEstado;
            btnsave.Enabled = lEstado;
            btncancel.Enabled = lEstado;

            btnNuevo.Enabled =!lEstado;
            btnActualizar.Enabled = !lEstado;
            btnelimar.Enabled = !lEstado;
            Reporte.Enabled = !lEstado;
            btnsalir.Enabled = !lEstado;
            btnbuscar.Enabled = !lEstado;
            txtbuscar.Enabled= !lEstado;

            dataview.Enabled = !lEstado;

        }


        #endregion

        private void frm_castegoria_Load(object sender, EventArgs e)
        {
            this.Listar_ca("%");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtcat.Text))

            {
                MessageBox.Show("No se tiene para ser guardad,", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                string Rpta="";
                E_categorias oca = new E_categorias();
                oca.codigo_ca = ncodigo;
                oca.desc_ca = txtcat.Text.Trim();
                


                Rpta = N_categoriascs.Guardar_ca(Estadodoguardo, oca);
                if(Rpta.Equals("ok"))
                {   this.Listar_ca("%");
                    this.Estado(false);
                    Estadodoguardo = 0;
                    ncodigo = 0;
                 
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del sistema ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Listar_ca(txtbuscar.Text.Trim());

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Estadodoguardo = 1;
            this.Estado(true);
            txtcat.Clear();
            txtcat.Focus();


            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Estado(false);
            txtcat.Clear();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estadodoguardo = 2;
            this.Estado(true);

        }

        private void dataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ncodigo = Convert.ToInt32(dataview.CurrentRow.Cells["codigo_ca"].Value);
            txtcat.Text = Convert.ToString(dataview.CurrentRow.Cells["desc_ca"].Value);



        }

        private void btnelimar_Click(object sender, EventArgs e)
        {
            DialogResult copcion;
            copcion = MessageBox.Show("Estas seguro de eliminar el registro ?","Aviso del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (copcion==DialogResult.Yes)
            {
                String Rtpa = "";
                Rtpa = N_categoriascs.drop_ca(ncodigo);
                if (Rtpa.Equals("Ok"))
                {

                    this.Listar_ca("%");
                    ncodigo = 0;
                    txtcat.Text = "";







                    MessageBox.Show("Registro Eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(Rtpa, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            

        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            Reportes.frm_rpt_ca report = new Reportes.frm_rpt_ca();
            report.txtp1.Text = txtbuscar.Text;
            report.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joyeria2._0
{
    public partial class FrmClientes : Form
    {
        clssutil consultas = new clssutil();
        Frmaddclientes abrir = new Frmaddclientes();
        public FrmClientes()
        {
                InitializeComponent();
        }
        private void btnfrmaddcliente_Click(object sender, EventArgs e)
        {
            abrir.lbldatos.Text = "";
            abrir.lblid.Text = "";
            abrir.txtnombre.Text = "";
            abrir.txtapellido.Text = "";
            abrir.txtcorreo.Text = "";
            abrir.txtdireccion.Text = "";
            abrir.txtelefono.Text = "";
            abrir.lbltitle.Text = "Agregar";
            abrir.btnguardarclientes.Text = "              Guardar";
            abrir.ShowDialog();
        }

        private void btneditclien_Click(object sender, EventArgs e)
        {
            try
            {
                abrir.lblid.Text = "";
                abrir.lblid.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
                if (abrir.lblid.Text != "")
                {
                    abrir.lbldatos.Text = "ID Cliente:";
                    abrir.lbltitle.Text = "Actualizar";
                    abrir.btnguardarclientes.Text = "              Actualizar";
                    abrir.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecciona a un cliente para editar su Informacion");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona a un cliente para editar su Informacion");
            }
        }

        public void consulta()
        {
            bunifuCustomDataGrid1.DataSource = consultas.tabla("Select * from Clientes");
        }

        private void btnelimimnar_Click(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = "";
                lblID.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
                if (lblID.Text != "")
                {
                    string sql = "delete from Clientes where IDcliente = '" + lblID.Text + "'";
                    consultas.Delete(sql);
                    consulta();
                }
                else
                {
                    MessageBox.Show("Seleccione Al cliente");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione al Cliente", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = consultas.tabla("Select IDcliente as ID, Nombre, Apellido, Domicilio, Numero as Telefono, Correo as Email from Clientes");
        }
    }
}

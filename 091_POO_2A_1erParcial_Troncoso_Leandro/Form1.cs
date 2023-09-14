using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _091_POO_2A_1erParcial_Troncoso_Leandro
{
    public partial class Form1 : Form
    {
        private List<Cliente> _listaClientes;
        private List<Cobro> _listaCobros;
        private Cliente _cliente = new Cliente();
        public Form1()
        {
            _listaClientes = new List<Cliente>();
            _listaCobros = new List<Cobro>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            _cliente = null;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvClientes.MultiSelect = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvCobrosPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCobrosPendientes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCobrosPendientes.MultiSelect = false;
            dgvCobrosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvCobrosRealizados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCobrosRealizados.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCobrosRealizados.MultiSelect = false;
            dgvCobrosRealizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvOrdenarCobros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenarCobros.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvOrdenarCobros.MultiSelect = false;
            dgvOrdenarCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvTipoAnonimo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipoAnonimo.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTipoAnonimo.MultiSelect = false;
            dgvTipoAnonimo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            cbTipoCobro.Items.Add("Normal");
            cbTipoCobro.Items.Add("Especial");
            cbTipoCobro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoCobro.SelectedIndex = 0;
            txtClienteLegajo.MaxLength = 6;
            txtClienteNombre.MaxLength = 30;
            txtCobroCodigo.MaxLength = 9;
            rbAscendente.Checked = true;
            btnOrdenar.Enabled = false;
            btnPagar.Enabled = false;
        }
        public void ActualizarDgvClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = _listaClientes;
        }
        public void ActualizarDgvCobrosPendientes()
        {
            dgvCobrosPendientes.DataSource = null;
            dgvCobrosPendientes.DataSource = Cobro.ListarCobrosPendientes(_listaCobros, _cliente);
            dgvCobrosPendientes.Columns["Cliente"].Visible = false;
            dgvCobrosPendientes.Columns["Interes"].Visible = false;
            dgvCobrosPendientes.Columns["Total"].Visible = false;
            dgvCobrosPendientes.Columns["Realizado"].Visible = false;
            dgvCobrosPendientes.Columns["Importe"].DefaultCellStyle.Format = "C2";
            dgvCobrosPendientes.Columns["Interes"].DefaultCellStyle.Format = "C2";
            dgvCobrosPendientes.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvCobrosPendientes.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCobrosPendientes.Columns["FechaVencimiento"].HeaderText = "Fecha de vencimiento";

        }
        public void ActualizarDgvCobrosRealizados()
        {
            dgvCobrosRealizados.DataSource = null;
            dgvCobrosRealizados.DataSource = Cobro.ListarCobrosPagados(_listaCobros, _cliente);
            dgvCobrosRealizados.Columns["Cliente"].Visible = false;
            dgvCobrosRealizados.Columns["Realizado"].Visible = false;
            dgvCobrosRealizados.Columns["Importe"].DefaultCellStyle.Format = "C2";
            dgvCobrosRealizados.Columns["Interes"].DefaultCellStyle.Format = "C2";
            dgvCobrosRealizados.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvCobrosRealizados.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCobrosRealizados.Columns["FechaVencimiento"].HeaderText = "Fecha de vencimiento";

        }
        public void ActualizarDgvCobrosOrdenados()
        {
            dgvOrdenarCobros.DataSource = null;
            dgvOrdenarCobros.DataSource = Cobro.ListarCobrosPagados(_listaCobros, _cliente);
            dgvOrdenarCobros.Columns["Cliente"].Visible = false;
            dgvOrdenarCobros.Columns["Realizado"].Visible = false;
            dgvOrdenarCobros.Columns["Importe"].DefaultCellStyle.Format = "C2";
            dgvOrdenarCobros.Columns["Interes"].DefaultCellStyle.Format = "C2";
            dgvOrdenarCobros.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvOrdenarCobros.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvOrdenarCobros.Columns["FechaVencimiento"].HeaderText = "Fecha de vencimiento";

        }
        public void ActualizarDgvTipoAnonimo()
        {
            dgvTipoAnonimo.DataSource = null;
            dgvTipoAnonimo.DataSource = CargarDgvTipoAnonimo(Cobro.ListarCobrosPagadosGeneral(_listaCobros));
            dgvTipoAnonimo.Columns["TotalCancelado"].HeaderText = "Total Cancelado";
            dgvTipoAnonimo.Columns["NombreCliente"].HeaderText = "Nombre del cliente";
            dgvTipoAnonimo.Columns["TotalCancelado"].DefaultCellStyle.Format = "C2";

        }

        private bool CamposVaciosCliente()
        {
            if (String.IsNullOrWhiteSpace(txtClienteLegajo.Text) || String.IsNullOrWhiteSpace(txtClienteNombre.Text))
            {
                return true;
            }
            return false;
        }
        private void VaciarCamposCliente()
        {
            txtClienteLegajo.Text = "";
            txtClienteNombre.Text = "";
        }
        private void VaciarCamposCobro()
        {
            txtCobroCodigo.Text = "";
            txtCobroImporte.Text = "";
            cbTipoCobro.SelectedIndex = 0;
            dtpCobroVencimiento.Value = DateTime.Now;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CamposVaciosCliente())
                {
                    if (!Cliente.ExisteLegajo(_listaClientes, int.Parse(txtClienteLegajo.Text)))
                    {
                        if (Cliente.SoloLetras(txtClienteNombre.Text))
                        {
                            if (!Cliente.ExisteNombre(_listaClientes, txtClienteNombre.Text))
                            {
                                Cliente cliente = new Cliente
                                {
                                    Legajo = int.Parse(txtClienteLegajo.Text),
                                    Nombre = txtClienteNombre.Text
                                };
                                _listaClientes.Add(cliente);
                                MessageBox.Show("Se ha creado el cliente con exíto");
                                VaciarCamposCliente();
                                ActualizarDgvClientes();
                                dgvClientes.ClearSelection();
                                _cliente = null;
                            }
                            else MessageBox.Show("El nombre ya exíste.", "Error al crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else MessageBox.Show("El nombre debe estar formado unicamente de letras.", "Error al crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("El legajo ya exíste.", "Error al crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Debe completar los campos.", "Error al crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("El formato de los campos no es el correcto.", "Error al crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VaciarCamposCliente();
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                txtClienteLegajo.Text = _cliente.Legajo.ToString();
                txtClienteNombre.Text = _cliente.Nombre;
                if(_listaCobros.Count > 0)
                {
                    ActualizarDgvCobrosPendientes();
                    ActualizarDgvCobrosRealizados();
                    ActualizarDgvCobrosOrdenados();
                    ActualizarDgvTipoAnonimo();
                }
                InhabilitarBottones();
            }
            catch
            {
                MessageBox.Show("No se ha podido seleccionar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InhabilitarBottones()
        {
            if (Cobro.ListarCobrosPagados(_listaCobros, _cliente).Count > 0) btnOrdenar.Enabled = true;
            else btnOrdenar.Enabled = false;

            if (Cobro.ListarCobrosPendientes(_listaCobros, _cliente).Count > 0) btnPagar.Enabled = true;
            else btnPagar.Enabled = false;
        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cliente != null)
                {
                    _listaClientes.Remove(_cliente);
                    MessageBox.Show("Se ha borrado con exíto!");
                    _cliente = null;
                    VaciarCamposCliente();
                    ActualizarDgvClientes();
                    ActualizarDgvCobrosOrdenados();
                    ActualizarDgvCobrosPendientes();
                    ActualizarDgvCobrosRealizados();
                    ActualizarDgvTipoAnonimo();
                }
                else MessageBox.Show("Debe seleccionar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("No se ha podido eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CamposVaciosCliente())
                {
                    if (!Cliente.ExisteLegajo(_listaClientes, int.Parse(txtClienteLegajo.Text), _cliente.Legajo))
                    {
                        if (!Cliente.ExisteNombre(_listaClientes, txtClienteNombre.Text, _cliente.Nombre))
                        {
                            _cliente.Legajo = int.Parse(txtClienteLegajo.Text);
                            _cliente.Nombre = txtClienteNombre.Text;
                            MessageBox.Show("Se ha modificado el cliente con exíto");
                            ActualizarDgvClientes();
                            VaciarCamposCliente();
                        }
                        else MessageBox.Show("El nombre ya exíste.", "Error al modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("El legajo ya exíste.", "Error al modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Debe completar los campos.", "Error al modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("El formato de los campos no es el correcto.", "Error al modificar cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarCobro_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cliente != null)
                {
                    if (!Cobro.CodigoExiste(_listaCobros, txtCobroCodigo.Text))
                    {
                        if (Cobro.ListarCobrosPendientes(_listaCobros, _cliente).Count() < 2)
                        {
                            if (decimal.Parse(txtCobroImporte.Text)>0)
                            {
                                if (cbTipoCobro.SelectedItem.ToString() == "Normal")
                                {
                                    Cobro cobroGenerado = new Cobro()
                                    {
                                        Codigo = txtCobroCodigo.Text,
                                        FechaVencimiento = dtpCobroVencimiento.Value,
                                        Importe = decimal.Parse(txtCobroImporte.Text),
                                        Cliente = _cliente,
                                        Realizado = false
                                    };
                                    _listaCobros.Add(cobroGenerado);
                                    MessageBox.Show("Se ha generado el cobro con exíto.");
                                    VaciarCamposCobro();
                                    ActualizarDgvCobrosPendientes();
                                    btnPagar.Enabled = true;
                                }
                                else if (cbTipoCobro.SelectedItem.ToString() == "Especial")
                                {
                                    CobroEspecial cobroGenerado = new CobroEspecial()
                                    {
                                        Codigo = txtCobroCodigo.Text,
                                        FechaVencimiento = dtpCobroVencimiento.Value,
                                        Importe = decimal.Parse(txtCobroImporte.Text),
                                        Cliente = _cliente,
                                        Realizado = false
                                    };
                                    _listaCobros.Add(cobroGenerado);
                                    MessageBox.Show("Se ha generado el cobro con exíto.");
                                    VaciarCamposCobro();
                                    ActualizarDgvCobrosPendientes();
                                    btnPagar.Enabled = true;
                                }
                            }
                            else MessageBox.Show("El importe no puede ser 0 o inferior.", "Error al generar cobro.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else MessageBox.Show("El cliente ya posee 2 cobros pendientes.", "Error al generar cobro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("El codígo ya exíste.", "Error al generar cobro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Debe seleccionar un cliente", "Error al generar cobro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("No se ha podido generar el cobro, corroborar que los campos sean correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string texto = "Importe a abonar + Interes por atraso = Total a abonar\n";
            decimal importe = 0, interes = 0, total = 0;
            foreach (var cobro in Cobro.ListarCobrosPendientes(_listaCobros,_cliente))
            {
                cobro.Interes = cobro.CalcularImporteRetraso();
                cobro.Total = cobro.Importe + cobro.Interes;
                importe += cobro.Importe;
                interes += cobro.Interes;
                total += cobro.Total;
                texto += $"{cobro.Importe.ToString("C")} + {cobro.Interes.ToString("C")} = {cobro.Total.ToString("C")}\n";
            }
            DialogResult respuesta = MessageBox.Show(texto + "--Resumen--" + Environment.NewLine +  $"{importe.ToString("C")} + {interes.ToString("C")} = {total.ToString("C")}", "Resumen", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta == DialogResult.Yes)
            {
                foreach (var cobro in _listaCobros)
                {
                    cobro.Realizado = true;
                }
                if (total > 10000) MessageBox.Show("El cliente abono un importe superior a $10.000");
                ActualizarDgvCobrosPendientes();
                ActualizarDgvCobrosRealizados();
                ActualizarDgvCobrosOrdenados();
                ActualizarDgvTipoAnonimo();
                InhabilitarBottones();
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if(rbAscendente.Checked == true)
            {
                List<Cobro> lista = Cobro.ListarCobrosPagados(_listaCobros, _cliente);
                lista.Sort(new TotalAscendente());
                dgvOrdenarCobros.DataSource = null;
                dgvOrdenarCobros.DataSource = lista;
                dgvOrdenarCobros.Columns["Cliente"].Visible = false;
                dgvOrdenarCobros.Columns["Realizado"].Visible = false;
                dgvOrdenarCobros.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgvOrdenarCobros.Columns["Interes"].DefaultCellStyle.Format = "C2";
                dgvOrdenarCobros.Columns["Total"].DefaultCellStyle.Format = "C2";
                dgvOrdenarCobros.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            else if(rbDescendente.Checked == true)
            {
                List<Cobro> lista = Cobro.ListarCobrosPagados(_listaCobros, _cliente);
                lista.Sort(new TotalDescendente());
                dgvOrdenarCobros.DataSource = null;
                dgvOrdenarCobros.DataSource = lista;
                dgvOrdenarCobros.Columns["Cliente"].Visible = false;
                dgvOrdenarCobros.Columns["Realizado"].Visible = false;
                dgvOrdenarCobros.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgvOrdenarCobros.Columns["Interes"].DefaultCellStyle.Format = "C2";
                dgvOrdenarCobros.Columns["Total"].DefaultCellStyle.Format = "C2";
                dgvOrdenarCobros.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

            }
        }
        private List<object> CargarDgvTipoAnonimo(List<Cobro>lista)
        {
            var listaAnonima = new List<object>();
            foreach(var item in lista)
            {
                var objeto = new
                {
                    NombreCliente = item.Cliente.Nombre,
                    TotalCancelado = item.Total

                };
                listaAnonima.Add(objeto);
            }
            return listaAnonima;
        }
    }
}

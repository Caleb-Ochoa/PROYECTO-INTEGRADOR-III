using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlTerreno
    {
        public Terreno_y_Calculo Vista { get; set; }

        private readonly DataManager<Terreno> _dmTerreno;
        private readonly DataManager<Cliente> _dmCliente;
        private readonly DataManager<Material> _dmMaterial;
        private readonly ICalculoService _calculo;

        private List<Terreno> _terrenos;
        private List<Cliente> _clientes;
        private List<Material> _materiales;
        private List<Coordenada> _coordActuales = new();
        private ResultadoCalculo? _ultimoResultado;

        public CtlTerreno(DataManager<Terreno> dmTerreno,
                          DataManager<Cliente> dmCliente,
                          DataManager<Material> dmMaterial,
                          ICalculoService calculo,
                          Terreno_y_Calculo vista)
        {
            _dmTerreno = dmTerreno;
            _dmCliente = dmCliente;
            _dmMaterial = dmMaterial;
            _calculo = calculo;
            Vista = vista;

            _terrenos = _dmTerreno.GetAll();
            _clientes = _dmCliente.GetAll();
            _materiales = _dmMaterial.GetAll();

            CargarCombos();

            Vista.btnAgregarCoordenada.Click += (s, e) => AgregarCoordenada();
            Vista.btnQuitarCoordenada.Click += (s, e) =>
            {
                if (_coordActuales.Count == 0) return;
                _coordActuales.RemoveAt(_coordActuales.Count - 1);
                RefrescarCoordenadas();
            };
            Vista.btnLimpiarCoordenada.Click += (s, e) => Limpiar();
            Vista.btnCalcular.Click += (s, e) => Calcular();
        }

        private void CargarCombos()
        {
            Vista.GetCmbCliente().DataSource = null;
            Vista.GetCmbCliente().DataSource = _clientes;
            Vista.GetCmbCliente().DisplayMember = "Nombre";
            Vista.GetCmbCliente().ValueMember = "Id";
            Vista.GetCmbCliente().SelectedIndex = -1;

            Vista.GetCmbMaterial().DataSource = null;
            Vista.GetCmbMaterial().DataSource = _materiales;
            Vista.GetCmbMaterial().DisplayMember = "Nombre";
            Vista.GetCmbMaterial().ValueMember = "Id";
            Vista.GetCmbMaterial().SelectedIndex = -1;
        }

        private void AgregarCoordenada()
        {
            try
            {
                var (x, y, z) = Vista.GetCoordenada();

                if (_coordActuales.Any(c => c.X == x && c.Y == y && c.Z == z))
                {
                    Vista.MostrarMensaje("Ya existe un punto con esas coordenadas.", esError: true);
                    return;
                }

                _coordActuales.Add(new Coordenada
                {
                    Id = _coordActuales.Count + 1,
                    X = x,
                    Y = y,
                    Z = z
                });

                Vista.LimpiarNumericos();
                RefrescarCoordenadas();
            }
            catch (FormatException ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
            }
        }

        private void RefrescarCoordenadas()
        {
            Vista.CargarGridCoordenadas(_coordActuales);

            // Si hay 6+ puntos calculamos el modelo para la gráfica continua
            double[]? coef = null;
            if (_coordActuales.Count >= 6)
            {
                try { coef = CalculoService.AjustarMinCuadrados(_coordActuales); }
                catch { coef = null; }
            }

            Vista.ActualizarGrafica(_coordActuales, coef);
        }

        private void Calcular()
        {
            if (_coordActuales.Count < 3)
            {
                Vista.MostrarMensaje("Necesitas al menos 3 coordenadas.", esError: true);
                return;
            }
            if (Vista.GetCmbMaterial().SelectedValue == null)
            {
                Vista.MostrarMensaje("Selecciona un material.", esError: true);
                return;
            }

            try
            {
                int materialId = (int)Vista.GetCmbMaterial().SelectedValue!;
                Material mat = _materiales.First(m => m.Id == materialId);

                int clienteId = Vista.GetCmbCliente().SelectedValue != null
                    ? (int)Vista.GetCmbCliente().SelectedValue : 0;

                Terreno terreno = new Terreno
                {
                    Id = _dmTerreno.GetNextId(),
                    ClienteId = clienteId,
                    Nombre = $"Terreno-{DateTime.Now:yyyyMMddHHmmss}",
                    Coordenadas = _coordActuales
                };

                _ultimoResultado = _calculo.Calcular(terreno, mat);

                Vista.MostrarResultado(
                    _ultimoResultado.Area,
                    _ultimoResultado.Volumen,
                    _ultimoResultado.CostoTotal,
                    _ultimoResultado.MetodoUsado);

                _terrenos.Add(terreno);
                _dmTerreno.Save(_terrenos);

                Vista.MostrarMensaje(
                    $"Método: {_ultimoResultado.MetodoUsado}\n" +
                    $"Área:    {_ultimoResultado.Area:F2} m²\n" +
                    $"Volumen: {_ultimoResultado.Volumen:F2} m³\n" +
                    $"Costo:   {_ultimoResultado.CostoTotal:C2}");
            }
            catch (Exception ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
            }
        }

        private void Limpiar()
        {
            _coordActuales.Clear();
            _ultimoResultado = null;
            Vista.LimpiarNumericos();
            Vista.CargarGridCoordenadas(_coordActuales);
            Vista.ActualizarGrafica(_coordActuales, null);
            Vista.MostrarResultado(0, 0, 0, "");
        }

        public List<Terreno> Listar()
        {
            _terrenos = _dmTerreno.GetAll();
            return _terrenos;
        }
    }
}

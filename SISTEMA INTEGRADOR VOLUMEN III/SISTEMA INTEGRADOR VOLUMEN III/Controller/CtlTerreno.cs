using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Text;

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

            // ── Agregar coordenada ────────────────────────────────────────
            Vista.btnAgragarCoordenada.Click += (s, e) => AgregarCoordenada();

            // ── Quitar última coordenada ──────────────────────────────────
            Vista.btnQuitarCoordenada.Click += (s, e) =>
            {
                if (_coordActuales.Count == 0) return;
                _coordActuales.RemoveAt(_coordActuales.Count - 1);
                RefrescarCoordenadas();
            };

            // ── Limpiar todo ──────────────────────────────────────────────
            Vista.btnLimpiarCoordenada.Click += (s, e) => Limpiar();

            // ── Calcular ──────────────────────────────────────────────────
            Vista.button1.Click += (s, e) => Calcular();
        }

        // ── Combos ────────────────────────────────────────────────────────
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

        // ── Agregar coordenada ────────────────────────────────────────────
        private void AgregarCoordenada()
        {
            var (x, y, z) = Vista.GetCoordenada();

            // Verificar duplicado
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

        private void RefrescarCoordenadas()
        {
            Vista.CargarGridCoordenadas(_coordActuales);
            Vista.ActualizarGrafica(_coordActuales);
        }

        // ── Calcular ──────────────────────────────────────────────────────
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
                    ? (int)Vista.GetCmbCliente().SelectedValue
                    : 0;

                // Crear terreno temporal para el cálculo
                Terreno terreno = new Terreno
                {
                    Id = _dmTerreno.GetNextId(),
                    ClienteId = clienteId,
                    Nombre = $"Terreno-{DateTime.Now:yyyyMMddHHmmss}",
                    Coordenadas = _coordActuales
                };

                _ultimoResultado = _calculo.Calcular(terreno, mat);

                Vista.MostrarResultado(_ultimoResultado.Volumen, _ultimoResultado.CostoTotal);

                // Persistir terreno
                _terrenos.Add(terreno);
                _dmTerreno.Save(_terrenos);

                Vista.MostrarMensaje(
                    $"Cálculo completado.\n" +
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
            Vista.ActualizarGrafica(_coordActuales);
            Vista.MostrarResultado(0, 0);
        }

        // ── Método público para CtlCotizacion ─────────────────────────────
        public List<Terreno> Listar()
        {
            _terrenos = _dmTerreno.GetAll();
            return _terrenos;
        }
    }
}

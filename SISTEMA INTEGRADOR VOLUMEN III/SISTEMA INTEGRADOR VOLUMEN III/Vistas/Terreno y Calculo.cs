using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Terreno_y_Calculo : Form
    {
        private GLControl? _glControl;
        private List<Coordenada> _coordenadas = new();
        private bool _glListo = false;

        // Rotación con mouse
        private bool _arrastrando = false;
        private Point _ultimoMouse;
        private float _rotX = 20f;
        private float _rotY = 30f;
        private float _zoom = -5f;

        public Terreno_y_Calculo()
        {
            InitializeComponent();
            InicializarGLControl();
        }

        // ── OpenTK setup ──────────────────────────────────────────────────
        private void InicializarGLControl()
        {
            _glControl = new GLControl();
            _glControl.Dock = DockStyle.Fill;
            _glControl.Load += GlControl_Load;
            _glControl.Paint += GlControl_Paint;
            _glControl.Resize += (s, e) => { if (_glListo) ConfigurarViewport(); };
            _glControl.MouseDown += GlControl_MouseDown;
            _glControl.MouseMove += GlControl_MouseMove;
            _glControl.MouseUp += (s, e) => _arrastrando = false;
            _glControl.MouseWheel += GlControl_MouseWheel;

            panelOpenGL.Controls.Add(_glControl);
        }

        private void GlControl_Load(object? sender, EventArgs e)
        {
            _glListo = true;
            GL.ClearColor(0.12f, 0.12f, 0.18f, 1f);   // fondo oscuro
            GL.Enable(EnableCap.DepthTest);
            ConfigurarViewport();
        }

        private void ConfigurarViewport()
        {
            if (_glControl == null) return;
            GL.Viewport(0, 0, _glControl.Width, _glControl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            double aspecto = _glControl.Width / (double)(_glControl.Height == 0 ? 1 : _glControl.Height);
            GL.Frustum(-aspecto * 0.5, aspecto * 0.5, -0.5, 0.5, 1.0, 100.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void GlControl_Paint(object? sender, PaintEventArgs e)
        {
            if (!_glListo || _glControl == null) return;
            _glControl.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            GL.Translate(0f, 0f, _zoom);
            GL.Rotate(_rotX, 1f, 0f, 0f);
            GL.Rotate(_rotY, 0f, 1f, 0f);

            DibujarEjes();

            if (_coordenadas.Count >= 3)
            {
                DibujarTerreno();
                DibujarPuntos();
            }

            _glControl.SwapBuffers();
        }

        private void DibujarEjes()
        {
            GL.LineWidth(2f);
            GL.Begin(PrimitiveType.Lines);
            // X — rojo
            GL.Color3(1f, 0f, 0f); GL.Vertex3(0, 0, 0); GL.Vertex3(2, 0, 0);
            // Y — verde
            GL.Color3(0f, 1f, 0f); GL.Vertex3(0, 0, 0); GL.Vertex3(0, 2, 0);
            // Z — azul
            GL.Color3(0f, 0.5f, 1f); GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 2);
            GL.End();
        }

        private void DibujarTerreno()
        {
            if (_coordenadas.Count < 3) return;

            // Normalizar coordenadas para que quepan en la escena
            var norm = Normalizar(_coordenadas);

            // Cara superior — polígono semitransparente verde
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Color4(0.1f, 0.8f, 0.3f, 0.45f);
            GL.Begin(PrimitiveType.Polygon);
            foreach (var p in norm) GL.Vertex3(p.X, p.Z, p.Y);
            GL.End();
            GL.Disable(EnableCap.Blend);

            // Contorno superior — línea blanca
            GL.LineWidth(2f);
            GL.Color3(1f, 1f, 1f);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (var p in norm) GL.Vertex3(p.X, p.Z, p.Y);
            GL.End();

            // Paredes laterales — de cada vértice superior al suelo
            GL.Color4(0.2f, 0.6f, 1f, 0.3f);
            GL.Enable(EnableCap.Blend);
            foreach (var p in norm)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(p.X, p.Z, p.Y);
                GL.Vertex3(p.X, 0, p.Y);
                GL.End();
            }
            GL.Disable(EnableCap.Blend);
        }

        private void DibujarPuntos()
        {
            var norm = Normalizar(_coordenadas);
            GL.PointSize(8f);
            GL.Color3(1f, 0.8f, 0f);   // amarillo
            GL.Begin(PrimitiveType.Points);
            foreach (var p in norm) GL.Vertex3(p.X, p.Z, p.Y);
            GL.End();
        }

        // Normaliza a rango [-1.5, 1.5]
        private static List<(double X, double Y, double Z)> Normalizar(List<Coordenada> coords)
        {
            double minX = double.MaxValue, maxX = double.MinValue;
            double minY = double.MaxValue, maxY = double.MinValue;
            double minZ = double.MaxValue, maxZ = double.MinValue;

            foreach (var c in coords)
            {
                if (c.X < minX) minX = c.X; if (c.X > maxX) maxX = c.X;
                if (c.Y < minY) minY = c.Y; if (c.Y > maxY) maxY = c.Y;
                if (c.Z < minZ) minZ = c.Z; if (c.Z > maxZ) maxZ = c.Z;
            }

            double rX = maxX - minX, rY = maxY - minY, rZ = maxZ - minZ;
            double rMax = Math.Max(Math.Max(rX == 0 ? 1 : rX, rY == 0 ? 1 : rY), rZ == 0 ? 1 : rZ);
            double escala = 3.0 / rMax;

            var result = new List<(double, double, double)>();
            foreach (var c in coords)
                result.Add(((c.X - minX - rX / 2) * escala,
                            (c.Y - minY - rY / 2) * escala,
                            (c.Z - minZ) * escala));
            return result;
        }

        // ── Interacción con mouse ─────────────────────────────────────────
        private void GlControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _arrastrando = true;
                _ultimoMouse = e.Location;
            }
        }

        private void GlControl_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_arrastrando) return;
            _rotY += (e.X - _ultimoMouse.X) * 0.5f;
            _rotX += (e.Y - _ultimoMouse.Y) * 0.5f;
            _ultimoMouse = e.Location;
            _glControl?.Invalidate();
        }

        private void GlControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            _zoom += e.Delta > 0 ? 0.3f : -0.3f;
            _zoom = Math.Clamp(_zoom, -20f, -1f);
            _glControl?.Invalidate();
        }

        // ── Métodos que usa CtlTerreno ────────────────────────────────────
        public ComboBox GetCmbCliente() => cmbClienteTerreno;
        public ComboBox GetCmbMaterial() => cbmMaterialTerreno;
        public string GetValorTerreno() => txtValorTerreno.Text.Trim();

        public (double X, double Y, double Z) GetCoordenada() =>
            ((double)numeriX.Value, (double)numeriY.Value, (double)numeriZ.Value);

        public void LimpiarNumericos()
        {
            numeriX.Value = 0;
            numeriY.Value = 0;
            numeriZ.Value = 0;
        }

        public void CargarGridCoordenadas(List<Coordenada> coords)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = coords.Select((c, i) => new
            {
                Punto = i + 1,
                X = c.X,
                Y = c.Y,
                Z = c.Z
            }).ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void MostrarResultado(double volumen, decimal costo)
        {
            label7.Text = $"Volumen: {volumen:F2} m³";
            label8.Text = $"Total:   {costo:C2}";
        }

        public void ActualizarGrafica(List<Coordenada> coords)
        {
            _coordenadas = coords;
            _glControl?.Invalidate();
        }

        public void MostrarMensaje(string msg, bool esError = false)
        {
            MessageBox.Show(msg,
                esError ? "Error" : "Información",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public DataGridView GetGrid() => dataGridView1;
    }
}

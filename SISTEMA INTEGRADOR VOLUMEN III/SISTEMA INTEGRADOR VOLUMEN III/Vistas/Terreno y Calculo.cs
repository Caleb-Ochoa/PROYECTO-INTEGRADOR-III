using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Terreno_y_Calculo : Form
    {
        private GLControl? _glControl;
        private List<Coordenada> _coordenadas = new();
        private double[]? _coeficientes = null;
        private bool _glListo = false;

        // Rotación con mouse
        private bool _arrastrando = false;
        private Point _ultimoMouse;
        private float _rotX = 25f;
        private float _rotY = -45f;
        private float _zoom = -5f;

        public Terreno_y_Calculo()
        {
            InitializeComponent();
            cmbMaterial.SelectedIndexChanged += (s, e) => MostrarCostoMaterial();

            panelOpenGL.VisibleChanged += (s, e) =>
            {
                if (!panelOpenGL.Visible || _glListo) return;
                InicializarGLControl();
            };
        }
        private void Terreno_y_Calculo_Load(object? sender, EventArgs e)
        {
            InicializarGLControl();
        }

        // ── OpenTK ───────────────────────────────────────────────────────
        private void InicializarGLControl()
        {
            _glControl = new GLControl();
            _glControl.Dock = DockStyle.Fill;
            _glControl.Paint += GlControl_Paint;
            _glControl.Resize += (s, e) => { if (_glListo) ConfigurarViewport(); };
            _glControl.MouseDown += GlControl_MouseDown;
            _glControl.MouseMove += GlControl_MouseMove;
            _glControl.MouseUp += (s, e) => _arrastrando = false;
            _glControl.MouseWheel += GlControl_MouseWheel;

            panelOpenGL.Controls.Add(_glControl);

            // Ahora sí el handle existe
            _glControl.MakeCurrent();
            _glListo = true;
            GL.ClearColor(0.10f, 0.10f, 0.16f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            ConfigurarViewport();
            _glControl.Invalidate();
        }

        

        private void ConfigurarViewport()
        {
            if (_glControl == null) return;
            GL.Viewport(0, 0, _glControl.Width, _glControl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            double asp = _glControl.Width / (double)Math.Max(_glControl.Height, 1);
            GL.Frustum(-asp * 0.4, asp * 0.4, -0.4, 0.4, 1.0, 200.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void GlControl_Paint(object? sender, PaintEventArgs e)
        {
            if (!_glListo || _glControl == null) return;
            _glControl.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            GL.Translate(0f, -0.3f, _zoom);
            GL.Rotate(_rotX, 1f, 0f, 0f);
            GL.Rotate(_rotY, 0f, 1f, 0f);

            DibujarEjes();
            DibujarGrid();

            if (_coordenadas.Count >= 3)
            {
                if (_coeficientes != null)
                    DibujarSuperficieContinua();
                else
                    DibujarMeshSimple();

                DibujarPuntos();
            }

            _glControl.SwapBuffers();
        }

        // ── Ejes ─────────────────────────────────────────────────────────
        private void DibujarEjes()
        {
            GL.LineWidth(2f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.9f, 0.2f, 0.2f); GL.Vertex3(0, 0, 0); GL.Vertex3(2, 0, 0);
            GL.Color3(0.2f, 0.9f, 0.2f); GL.Vertex3(0, 0, 0); GL.Vertex3(0, 2, 0);
            GL.Color3(0.2f, 0.5f, 1.0f); GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 2);
            GL.End();
        }

        // ── Grid de fondo (piso) ──────────────────────────────────────────
        private void DibujarGrid()
        {
            GL.LineWidth(0.5f);
            GL.Color4(0.3f, 0.3f, 0.4f, 0.5f);
            GL.Begin(PrimitiveType.Lines);
            for (float i = -2f; i <= 2f; i += 0.5f)
            {
                GL.Vertex3(i, 0, -2); GL.Vertex3(i, 0, 2);
                GL.Vertex3(-2, 0, i); GL.Vertex3(2, 0, i);
            }
            GL.End();
        }

        // ── Superficie continua con malla coloreada por altura (como la imagen) ──
        private void DibujarSuperficieContinua()
        {
            if (_coeficientes == null || _coordenadas.Count < 3) return;

            int pasos = 30;
            var norm = ObtenerRango();
            double xMin = norm.xMin, xMax = norm.xMax;
            double yMin = norm.yMin, yMax = norm.yMax;
            double zMin = norm.zMin, zMax = norm.zMax;
            double zRango = zMax - zMin == 0 ? 1 : zMax - zMin;

            double dx = (xMax - xMin) / pasos;
            double dy = (yMax - yMin) / pasos;

            // Calcular z en cada celda y colorear por altura (azul→verde→rojo)
            for (int i = 0; i < pasos; i++)
            {
                for (int j = 0; j < pasos; j++)
                {
                    double x0 = xMin + i * dx, y0 = yMin + j * dy;
                    double x1 = x0 + dx, y1 = y0 + dy;

                    double z00 = EvalNorm(x0, y0, zMin, zRango);
                    double z10 = EvalNorm(x1, y0, zMin, zRango);
                    double z11 = EvalNorm(x1, y1, zMin, zRango);
                    double z01 = EvalNorm(x0, y1, zMin, zRango);

                    double xn0 = Norm(x0, xMin, xMax);
                    double xn1 = Norm(x1, xMin, xMax);
                    double yn0 = Norm(y0, yMin, yMax);
                    double yn1 = Norm(y1, yMin, yMax);

                    // Cara rellena
                    GL.Begin(PrimitiveType.Quads);
                    SetColorAltura(z00); GL.Vertex3(xn0, z00, yn0);
                    SetColorAltura(z10); GL.Vertex3(xn1, z10, yn0);
                    SetColorAltura(z11); GL.Vertex3(xn1, z11, yn1);
                    SetColorAltura(z01); GL.Vertex3(xn0, z01, yn1);
                    GL.End();

                    // Líneas de malla encima
                    GL.LineWidth(0.8f);
                    GL.Color4(0f, 0f, 0f, 0.35f);
                    GL.Begin(PrimitiveType.LineLoop);
                    GL.Vertex3(xn0, z00, yn0);
                    GL.Vertex3(xn1, z10, yn0);
                    GL.Vertex3(xn1, z11, yn1);
                    GL.Vertex3(xn0, z01, yn1);
                    GL.End();
                }
            }
        }

        // Color heatmap: azul(bajo) → cian → verde → amarillo → rojo(alto)
        private static void SetColorAltura(double t)
        {
            // t ya viene normalizado [0,1]
            float r, g, b;
            if (t < 0.25f) { r = 0f; g = (float)(t * 4); b = 1f; }
            else if (t < 0.5f) { r = 0f; g = 1f; b = (float)((0.5 - t) * 4); }
            else if (t < 0.75f) { r = (float)((t - 0.5) * 4); g = 1f; b = 0f; }
            else { r = 1f; g = (float)((1 - t) * 4); b = 0f; }
            GL.Color4(r, g, b, 0.85f);
        }

        // ── Mesh simple cuando no hay suficientes puntos para el modelo ──
        private void DibujarMeshSimple()
        {
            var norm = Normalizar(_coordenadas);
            double zMin = norm.Min(p => p.Z);
            double zMax = norm.Max(p => p.Z);
            double zRango = zMax - zMin == 0 ? 1 : zMax - zMin;

            GL.Begin(PrimitiveType.Polygon);
            foreach (var p in norm)
            {
                double t = (p.Z - zMin) / zRango;
                SetColorAltura(t);
                GL.Vertex3(p.X, p.Z, p.Y);
            }
            GL.End();

            GL.LineWidth(1.5f);
            GL.Color4(0f, 0f, 0f, 0.5f);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (var p in norm) GL.Vertex3(p.X, p.Z, p.Y);
            GL.End();
        }

        // ── Puntos medidos ────────────────────────────────────────────────
        private void DibujarPuntos()
        {
            var norm = Normalizar(_coordenadas);
            GL.PointSize(10f);
            GL.Color3(1f, 1f, 0f);
            GL.Begin(PrimitiveType.Points);
            foreach (var p in norm) GL.Vertex3(p.X, p.Z, p.Y);
            GL.End();
        }

        // ── Helpers de normalización ──────────────────────────────────────
        private (double xMin, double xMax, double yMin, double yMax,
                 double zMin, double zMax) ObtenerRango()
        {
            return (_coordenadas.Min(c => c.X), _coordenadas.Max(c => c.X),
                    _coordenadas.Min(c => c.Y), _coordenadas.Max(c => c.Y),
                    _coordenadas.Min(c => c.Z), _coordenadas.Max(c => c.Z));
        }

        private double EvalNorm(double x, double y, double zMin, double zRango)
        {
            double z = CalculoService.EvaluarModelo(_coeficientes!, x, y);
            return (z - zMin) / zRango; // normalizado [0,1]
        }

        private static double Norm(double v, double min, double max) =>
            max == min ? 0 : (v - min) / (max - min) * 3.0 - 1.5;

        private static List<(double X, double Y, double Z)> Normalizar(
            List<Coordenada> coords)
        {
            double minX = coords.Min(c => c.X), maxX = coords.Max(c => c.X);
            double minY = coords.Min(c => c.Y), maxY = coords.Max(c => c.Y);
            double minZ = coords.Min(c => c.Z), maxZ = coords.Max(c => c.Z);
            double rX = maxX - minX == 0 ? 1 : maxX - minX;
            double rY = maxY - minY == 0 ? 1 : maxY - minY;
            double rMax = Math.Max(rX, rY);
            double esc = 3.0 / rMax;

            return coords.Select(c => (
                (c.X - minX - rX / 2) * esc,
                (c.Y - minY - rY / 2) * esc,
                (c.Z - minZ) / (maxZ - minZ == 0 ? 1 : maxZ - minZ)
            )).ToList();
        }

        // ── Mouse ─────────────────────────────────────────────────────────
        private void GlControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { _arrastrando = true; _ultimoMouse = e.Location; }
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
            _zoom = Math.Clamp(_zoom + (e.Delta > 0 ? 0.4f : -0.4f), -20f, -1.5f);
            _glControl?.Invalidate();
        }

        // ── Métodos que usa CtlTerreno ─────────────────────────────────────
        public ComboBox GetCmbCliente() => cmbCliente;
        public ComboBox GetCmbMaterial() => cmbMaterial;

        public (double X, double Y, double Z) GetCoordenada()
        {
            if (!double.TryParse(txtXLatitud.Text, out double x) ||
                !double.TryParse(txtYLongitud.Text, out double y) ||
                !double.TryParse(txtZElevacion.Text, out double z))
                throw new FormatException(
                    "Ingresa valores numéricos válidos en X, Y y Z. Usa punto como decimal (ej: 10.5).");
            return (x, y, z);
        }

        public void LimpiarNumericos()
        {
            txtXLatitud.Clear();
            txtYLongitud.Clear();
            txtZElevacion.Clear();
            txtXLatitud.Focus();
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
            lblTotalPuntos.Text = $"Total puntos: {coords.Count}";
        }

        public void MostrarResultado(double area, double volumen, decimal costo,
                                     string metodo)
        {
            lblVolumen.Text = $"{volumen:F2} m³";
            lblTotal.Text = $"{costo:C2}";
        }

        public void ActualizarGrafica(List<Coordenada> coords, double[]? coef = null)
        {
            _coordenadas = coords;
            _coeficientes = coef;
            _glControl?.Invalidate();
        }

        private void MostrarCostoMaterial()
        {
            if (cmbMaterial.SelectedItem is Models.Material m)
                lblCostoMaterial.Text = $"{m.CostoMetroCubico:C2}/m³";
            else
                lblCostoMaterial.Text = "$0.00/m³";
        }

        public void MostrarMensaje(string msg, bool esError = false)
        {
            MessageBox.Show(msg,
                esError ? "Error" : "Información",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }
    }
}

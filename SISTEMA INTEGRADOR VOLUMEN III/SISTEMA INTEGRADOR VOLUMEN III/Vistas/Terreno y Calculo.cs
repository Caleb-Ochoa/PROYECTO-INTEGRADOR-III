using Microsoft.Web.WebView2.WinForms;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Terreno_y_Calculo : Form
    {
        private WebView2 _webView;
        private List<Coordenada> _coordenadas = new();
        private double[]? _coeficientes = null;
        private bool _webListo = false;

        public Terreno_y_Calculo()
        {
            InitializeComponent();
            cmbMaterial.SelectedIndexChanged += (s, e) => MostrarCostoMaterial();
            this.Load += async (s, e) => await InicializarWebView();
        }

        private async System.Threading.Tasks.Task InicializarWebView()
        {
            _webView = new WebView2();
            _webView.Dock = DockStyle.Fill;
            panelOpenGL.Controls.Add(_webView);

            await _webView.EnsureCoreWebView2Async(null);
            _webListo = true;
            ActualizarGrafica(_coordenadas, null);
        }

        public void ActualizarGrafica(List<Coordenada> coords, double[]? coef = null)
        {
            _coordenadas = coords;
            _coeficientes = coef;
            if (!_webListo || _webView == null) return;

            string html = GenerarHTML(coords, coef);
            _webView.NavigateToString(html);
        }

        private string GenerarHTML(List<Coordenada> coords, double[]? coef)
        {
            int pasos = 40;
            StringBuilder zData = new StringBuilder("[");

            string xVec = "[]", yVec = "[]";

            if (coords.Count >= 3)
            {
                double xMin = coords.Min(c => c.X), xMax = coords.Max(c => c.X);
                double yMin = coords.Min(c => c.Y), yMax = coords.Max(c => c.Y);

                if (xMax == xMin) { xMin -= 1; xMax += 1; }
                if (yMax == yMin) { yMin -= 1; yMax += 1; }

                double dx = (xMax - xMin) / pasos;
                double dy = (yMax - yMin) / pasos;

                var xList = new List<string>();
                for (int i = 0; i <= pasos; i++)
                    xList.Add((xMin + i * dx).ToString(System.Globalization.CultureInfo.InvariantCulture));
                xVec = "[" + string.Join(",", xList) + "]";

                var yList = new List<string>();
                for (int j = 0; j <= pasos; j++)
                    yList.Add((yMin + j * dy).ToString(System.Globalization.CultureInfo.InvariantCulture));
                yVec = "[" + string.Join(",", yList) + "]";

                for (int j = 0; j <= pasos; j++)
                {
                    zData.Append("[");
                    for (int i = 0; i <= pasos; i++)
                    {
                        double x = xMin + i * dx;
                        double y = yMin + j * dy;
                        double z = coef != null
                            ? CalculoService.EvaluarModelo(coef, x, y)
                            : InterpolarIDW(coords, x, y);
                        zData.Append(z.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        if (i < pasos) zData.Append(",");
                    }
                    zData.Append("]");
                    if (j < pasos) zData.Append(",");
                }
            }
            else
            {
                zData.Append("[]");
            }

            zData.Append("]");

            string puntosX = coords.Count > 0
                ? string.Join(",", coords.Select(c => c.X.ToString(System.Globalization.CultureInfo.InvariantCulture)))
                : "";
            string puntosY = coords.Count > 0
                ? string.Join(",", coords.Select(c => c.Y.ToString(System.Globalization.CultureInfo.InvariantCulture)))
                : "";
            string puntosZ = coords.Count > 0
                ? string.Join(",", coords.Select(c => c.Z.ToString(System.Globalization.CultureInfo.InvariantCulture)))
                : "";

            return $@"<!DOCTYPE html>
<html>
<head>
<meta charset='utf-8'>
<script src='https://cdn.plot.ly/plotly-2.27.0.min.js'></script>
<style>
  body {{ margin:0; padding:0; background:#1a1a28; overflow:hidden; }}
  #plot {{ width:100vw; height:100vh; }}
</style>
</head>
<body>
<div id='plot'></div>
<script>
var surface = {{
    type: 'surface',
    x: {xVec},
    y: {yVec},
    z: {zData},
    colorscale: 'Jet',
    opacity: 0.92,
    contours: {{
        z: {{ show: true, usecolormap: true, highlightcolor: '#42f462', project: {{ z: true }} }}
    }},
    lighting: {{
        ambient: 0.6,
        diffuse: 0.8,
        specular: 0.5,
        roughness: 0.4,
        fresnel: 0.3
    }},
    colorbar: {{
        title: 'Z (m)',
        titlefont: {{ color: 'white' }},
        tickfont: {{ color: 'white' }}
    }}
}};

var puntos = {{
    type: 'scatter3d',
    mode: 'markers',
    x: [{puntosX}],
    y: [{puntosY}],
    z: [{puntosZ}],
    marker: {{ size: 6, color: 'yellow', line: {{ color: 'black', width: 1 }} }},
    name: 'Puntos'
}};

var layout = {{
    paper_bgcolor: '#1a1a28',
    font: {{ color: 'white' }},
    scene: {{
        bgcolor: '#1a1a28',
        xaxis: {{ title: 'X (Longitud)', titlefont: {{ color: 'white' }}, tickfont: {{ color: 'white' }}, gridcolor: 'rgba(255,255,255,0.2)' }},
        yaxis: {{ title: 'Y (Latitud)', titlefont: {{ color: 'white' }}, tickfont: {{ color: 'white' }}, gridcolor: 'rgba(255,255,255,0.2)' }},
        zaxis: {{ title: 'Z (m)', titlefont: {{ color: 'white' }}, tickfont: {{ color: 'white' }}, gridcolor: 'rgba(255,255,255,0.2)' }},
        camera: {{ eye: {{ x: 1.5, y: 1.5, z: 1.2 }} }}
    }},
    margin: {{ l:0, r:0, t:0, b:0 }},
    showlegend: false
}};

Plotly.newPlot('plot', [surface, puntos], layout, {{ responsive: true }});
</script>
</body>
</html>";
        }

        private static double InterpolarIDW(List<Coordenada> pts, double x, double y)
        {
            double num = 0, den = 0;
            foreach (var p in pts)
            {
                double d = Math.Sqrt((x - p.X) * (x - p.X) + (y - p.Y) * (y - p.Y));
                if (d < 1e-10) return p.Z;
                double w = 1.0 / (d * d);
                num += w * p.Z;
                den += w;
            }
            return den == 0 ? 0 : num / den;
        }

        public ComboBox GetCmbCliente() => cmbCliente;
        public ComboBox GetCmbMaterial() => cmbMaterial;

        public (double X, double Y, double Z) GetCoordenada()
        {
            if (!double.TryParse(txtXLatitud.Text, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double x) ||
                !double.TryParse(txtYLongitud.Text, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double y) ||
                !double.TryParse(txtZElevacion.Text, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double z))
                throw new FormatException(
                    "Ingresa valores numéricos válidos en X, Y y Z.\nUsa punto como decimal (ej: 10.5).");
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

        public void MostrarResultado(double area, double volumen, decimal costo, string metodo)
        {
            lblVolumen.Text = $"{volumen:F2} m³";
            lblTotal.Text = $"{costo:C2}";
        }

        private void MostrarCostoMaterial()
        {
            if (cmbMaterial.SelectedItem is Models.Material m)
                lblCostoMaterial.Text = $"{m.CostoMetroCubico:C2}/m³";
            else
                lblCostoMaterial.Text = "$0.00/m³";
        }

        // ── Nombre del terreno ──────────────────────────────────────────
        public string GetNombreTerreno() => txtNombreTerreno.Text.Trim();

        public void LimpiarNombreTerreno() => txtNombreTerreno.Clear();

        public void MostrarMensaje(string msg, bool esError = false)
        {
            MessageBox.Show(msg,
                esError ? "Error" : "Información",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }
    }
}

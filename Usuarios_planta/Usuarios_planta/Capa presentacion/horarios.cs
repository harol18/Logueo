using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class horarios : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=dblibranza;port=3306;persistsecurityinfo=True;");
       

        Comandos cmds = new Comandos();


        public horarios()
        {
            InitializeComponent();
        }

        private void Btn_busqueda_Click(object sender, EventArgs e)
        {
            cmds.Informe_horario(dgv_informes, dtpinicio, dtpfinal, cmbEtapa);
        }

        DateTime hoy = DateTime.Now;

        private void btnDescargar_Excel_Click(object sender, EventArgs e)
        {
            string archivo = "Informe_Horarios " + hoy.ToString("dd-MM-yyyy")+".xlsx";

            SLDocument sl = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.Bold = true;
            style.Font.FontSize = 11;
            style.Font.FontName = "Calibri";
            style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Lavender, System.Drawing.Color.LightGray);
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            int i = 1;
            foreach (DataGridViewColumn columna in dgv_informes.Columns)
            {
                sl.SetCellValue(1, i, columna.HeaderText.ToString());
                sl.SetCellStyle(1, i, style);
                i++;
            }

            int j = 2;
            foreach (DataGridViewRow row in dgv_informes.Rows)
            {
                sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                //sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                //sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                //sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                //sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                //sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                //sl.SetCellValue(j, 17, row.Cells[16].Value.ToString());
                j++;
            }
            sl.AutoFitColumn(1, 11); // ajustar ancho columna
            sl.AutoFitRow(1, 11); //
            sl.SaveAs(@"D:\Control_Horarios\" + archivo);
            MessageBox.Show("Ok archivo creado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

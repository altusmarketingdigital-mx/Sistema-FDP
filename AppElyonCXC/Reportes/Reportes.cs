using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


using System.IO;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;

namespace AppElyonCXC.Reportes
{
   public class Reportes
    {
        public void GenerarReporte(DataSet DsReport, string MsjTitulo) {
            

            Console.WriteLine("Generando documento...");

            //Creo el documento PDF y el archivo a escribir.
            
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
        Document document = new Document(PageSize.A4.Rotate(), 1, 1, 1, 1);
        PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

            document.Open();                     

            //PARRAFO
            Paragraph unParrafo = GenerarParrafo(MsjTitulo);
        document.Add(unParrafo);
            //FECHA  
            string now = DateTime.Now.ToShortDateString();          
            document.Add(new Paragraph(now.ToString()));

            //GENERO Y AGREGO SALTO DE LINEA
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            //IMAGEN
            Image unaImagen = GenerarImagen();
            document.Add(unaImagen);

            //GENERO Y AGREGO SALTO DE LINEA
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            //TABLA
            PdfPTable unaTabla = GenerarTabla(DsReport);
        document.Add(unaTabla);

            //CIERRO DOCUMENTO
            document.Close();


           // return document;
            //LO EJECUTO
            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = fileName;
            prc.Start();

        }

    public static Paragraph GenerarParrafo(string MsjTitulo)
    {

        //Creamos un nuevo parrafo, por ejemplo el titulo de nuestro reporte
        //Y le damos algunas propiedades.
        Console.WriteLine(MsjTitulo);

        Paragraph parrafo = new Paragraph();

        parrafo.Alignment = Element.ALIGN_CENTER;
        parrafo.Font = FontFactory.GetFont("Arial", 24);
        parrafo.Font.SetStyle(Font.BOLD);
        parrafo.Font.SetStyle(Font.UNDERLINE);

        parrafo.Add(MsjTitulo);

        return parrafo;
    }
        public static Image GenerarImagen()
        {
            //Generamos imágen
            Console.WriteLine("Generando una imágen...");

            byte[] bytesImagen = new System.Drawing.ImageConverter().ConvertTo(Recursos.LogoFruteria, typeof(byte[])) as byte[];
            Image imagen = Image.GetInstance(bytesImagen);
            imagen.Alignment = Element.ALIGN_TOP;
            imagen.ScaleAbsolute(100, 50);
            imagen.SetAbsolutePosition(20, 540);


            return imagen;
        }
        public static PdfPTable GenerarTabla(DataSet DsReport)
        {
            Console.WriteLine("Generando una tabla...");

            DataSet DS = DsReport;
            DataTable DT = DS.Tables[0];

            int NColumnas = DT.Columns.Count;
           
            PdfPTable unaTabla = new PdfPTable(NColumnas);

            float[] prueba = new float[NColumnas];
            for (int i = 0; i < NColumnas; i++)
            {
                prueba[i] = 50;
                Console.WriteLine(prueba[i]);
            }

            foreach (DataColumn column in DT.Columns)
            {
                Console.WriteLine(column.ColumnName);
                unaTabla.AddCell(new Paragraph(column.ColumnName));
                string NC = column.ColumnName;
                int tamaño = NC.Length;


                Console.WriteLine(tamaño);                

            }
            Console.WriteLine(prueba);

            unaTabla.SetWidthPercentage(prueba, PageSize.A4);
            //¿Le damos un poco de formato?
            foreach (PdfPCell celda in unaTabla.Rows[0].GetCells())
            {
                celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                //celda.HorizontalAlignment = 1;
                celda.Padding = 1;
                celda.HorizontalAlignment = 1;
                celda.BorderColor = BaseColor.BLUE;                

            }

            foreach (DataRow row in DT.Rows)
            {
                foreach (DataColumn col in DT.Columns)
                {
                    PdfPCell datos = new PdfPCell(new Paragraph(row[col].ToString().Trim(), FontFactory.GetFont("Arial", 10)));
                    unaTabla.AddCell(datos);

                }
            }

          

            return unaTabla;

    }

        internal class rptRepMovimientos : ReportDocument
        {
        }
    }
}

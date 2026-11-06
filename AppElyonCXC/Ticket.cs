using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace AppElyonCXC
{
    class Ticket
    {
        #region Variables
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        private Image headerImage = null;
        int intAjusteImg = 0;
        int count = 0;

        int maxChar =75;
        int maxCharDescription = 28; //22

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 3;

        string fontName = "FontA11";

        int fontSize = 7;
        //int fontSize = 8;

        Font printFont = null;

        SolidBrush myBrush = new SolidBrush(Color.Black);

        Graphics gfx = null;

        string line = null;
        #endregion
        #region Constructor
        public Ticket()
        {

        }
        #endregion
        #region Propiedades
        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }
        public int intAjusImg
        {
            get { return intAjusteImg; }
            set { intAjusteImg = value; }
        }
        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }
        #endregion
        #region Metodos Publicos
        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(string strCantidad, string strCveConcepto, string strConcepto, string strPrecio)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(strCantidad, strCveConcepto, strConcepto, strPrecio));
        }

        //public void AddItemPedido(string Cve, string strCantidad, string strConcepto)
        //{
        //    OrderItem newItem = new OrderItem('?');
        //    items.Add(newItem.GenerateItemPedido(Cve, strCantidad, strConcepto));
        //}


        public void AddItemPedido(string Cve, string strCantidad, string strConcepto, string strPrecio, string strDescuento, string strImporte)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItemPedido(Cve, strCantidad, strConcepto, strPrecio, strDescuento, strImporte));
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "-";
            return dotted;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }

        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            DrawImage();
            DrawHeader();
            DrawSubHeader();
            DrawItems();
            DrawTotales();
            DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
            count = 0;
        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx)+(imageHeight > 0? 45:0));
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin+intAjusteImg, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;  //58
                    imageHeight = (int)Math.Round(height) + 3; //3
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            StringFormat format = new StringFormat();
            foreach (string header in headerLines)
            {
                RectangleF rec = new RectangleF();
                rec.Y = imageHeight > 0 ? YPosition() - 10 : YPosition();
                rec.X = 10;
                rec.Width = 50;

                format.LineAlignment = StringAlignment.Center;
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, rec, format);

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, rec, format);
                    count++;
                }
                else
                {
                    line = header;

                    gfx.DrawString(line, printFont, myBrush, rec, format);

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeader in subHeaderLines)
            {
                float intY = imageHeight > 0 ? YPosition() - 10 : YPosition();
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;


                    string[] strTexto = subHeader.Split(' ');

                    if (strTexto.Length > 2)
                    {
                        gfx.DrawString(strTexto[0] + " " + strTexto[1] + " " + strTexto[2] + " " + strTexto[3], printFont, myBrush, leftMargin, intY, new StringFormat());
                        string strText = "";

                        for (int i = 4; i < strTexto.Length; i++)
                        {
                            strText += strTexto[i] + " ";
                        }
                        count++;
                        gfx.DrawString(strText, printFont, myBrush, leftMargin + 14, intY, new StringFormat());
                        count++;
                    }
                    else
                    {
                        while (subHeaderLenght > maxChar)
                        {
                            line = subHeader;
                            gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, intY, new StringFormat());
                            count++;
                            currentChar += maxChar;
                            subHeaderLenght -= maxChar;
                        }
                        line = subHeader;

                        for (int i = 0; i < subHeaderLenght - maxChar; i++)
                        {
                            line = " " + line;
                        }
                        gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, intY, new StringFormat());
                        count++;

                    }

                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, intY, new StringFormat());

                    count++;

                    //line = DottedLine();

                    //gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            // DrawEspacio();
        }
        public void DrawLine()
        {
            line = DottedLine();

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
        }
        private void DrawItems()
        {
            OrderItem ordIt = new OrderItem('?');
            float intY = imageHeight > 0 ? YPosition() - 10 : YPosition();
            //gfx.DrawString("        DETALLES DEL TICKET      ", printFont, myBrush, leftMargin, intY, new StringFormat());
            //DrawEspacio();
            count++;
            
            foreach (string item in items)
            {
                line = ordIt.GetCantidad(item.Trim());
                //line =  "\n" + line + "\n"; 
                intY = imageHeight > 0 ? YPosition() + 10 : YPosition();
                //gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                line = AlignRightText((55)) + line;
                gfx.DrawString(line, printFont, myBrush, leftMargin, intY, new StringFormat());

                //line = "$ " + ordIt.GetPrecio(item);
                //line = AlignRightText(line.Length) + line;
                //gfx.DrawString(line, printFont, myBrush, leftMargin, intY, new StringFormat());

                //line = ordIt.GetCveConcepto(item);
                //gfx.DrawString(line, printFont, myBrush, leftMargin, intY, new StringFormat());

                //line = ordIt.GetDescuento(item);
                //line = AlignRightText((line.Length + 20)) + line;
                //gfx.DrawString(line, printFont, myBrush, leftMargin, intY, new StringFormat());

                string name = ordIt.GetConcepto(item.Trim());
                //name = "\n" + name + "\n";

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    while (itemLenght > maxCharDescription)
                    {
                       
                        line = ordIt.GetConcepto(item);
                        gfx.DrawString(" " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin + 70, intY, new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;

                        intY = imageHeight > 0 ? YPosition() - 10 : YPosition();
                    }
                    intY = imageHeight > 0 ? YPosition() - 10 : YPosition();
                    line = ordIt.GetConcepto(item);
                    gfx.DrawString(" " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin + 70, intY, new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString(" " + ordIt.GetConcepto(item.Trim()), printFont, myBrush, leftMargin + 1, intY, new StringFormat());

                    count++;
                }               
            }
            
            leftMargin = 0;
            DrawEspacio();
            line = DottedLine();
            intY = imageHeight > 0 ? YPosition() -10 : YPosition();
            gfx.DrawString(line, printFont, myBrush, leftMargin, intY, new StringFormat());

            count++;
            //DrawEspacio();
        }

        private void DrawTotales()
        {
            OrderTotal ordTot = new OrderTotal('?');

            foreach (string total in totales)
            {
                float fY = imageHeight > 0 ? YPosition() - 10 : YPosition();
                line = ordTot.GetTotalCantidad(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, fY, new StringFormat());
                leftMargin = 0;

                line = "          " + ordTot.GetTotalName(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, fY, new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footer in footerLines)
            {
                float fY = imageHeight > 0 ? YPosition() - 10 : YPosition();

                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), line.Contains("(") ? new Font(fontName, 7, FontStyle.Regular) : printFont, myBrush, leftMargin, fY, new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), line.Contains("(") ? new Font(fontName, 7, FontStyle.Regular) : printFont, myBrush, leftMargin, fY, new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, fY, new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
        }

        private void DrawEspacio()
        {
            line = "";

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
        }
        #endregion
    }

    public class OrderItem
    {
        char[] delimitador = new char[] { '?' };

        public OrderItem(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetConcepto(string strOrden)
        {
            string[] delimitado = strOrden.Split(delimitador);
            return delimitado[1]; //2
        }

        public string GetCantidad(string strOrden)
        {
            string[] delimitado = strOrden.Split(delimitador);
            return delimitado[2];
        }

        public string GetDescuento(string strOrden)
        {
            string[] delimitado = strOrden.Split(delimitador);
            return delimitado[4];
        }

        public string GetPrecio(string strOrden)
        {
            string[] delimitado = strOrden.Split(delimitador);
            return delimitado[3]; //3
        }

        public string GetCveConcepto(string strOrden)
        {
            string[] delimitado = strOrden.Split(delimitador);
            return delimitado[0]; //1
        }
   
        public string GenerateItem(string strCantidad, string strCveConcepto, string strConcepto, string strPrecio)
        {
            return strCantidad + delimitador[0] + strCveConcepto + delimitador[0] + strConcepto + delimitador[0] + strPrecio;
        }

        //public string GenerateItemPedido(string Clave, string strCantidad, string strConcepto)
        //{
        //    return Clave + delimitador[0] + strConcepto + delimitador[0] + strCantidad + delimitador[0];
        //}

        public string GenerateItemPedido(string Clave, string strCantidad, string strConcepto, string strPrecio, string strDescuento, string strImporte)
        {
            return Clave + delimitador[0] + strCantidad + delimitador[0] + strConcepto + delimitador[0] + strPrecio + delimitador[0] + strDescuento + delimitador[0] + strImporte + delimitador[0];
        }
    }

    public class OrderTotal
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotal(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotal(string totalName, string precio)
        {
            return totalName + delimitador[0] + precio;
        }
    }
}



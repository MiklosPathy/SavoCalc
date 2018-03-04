using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavoCalcLib
{
    public class BFrec
    {
        public int Scale;
        public double Low;
        public double High;
        public string Text;

        public BFrec(int scale, double low, double high, string text)
        {
            Scale = scale;
            Low = low;
            High = high;
            Text = text;
        }
    }

    public class BeauFort
    {
        private List<BFrec> bfdata;

        internal List<BFrec> Bfdata
        {
            get { return bfdata; }
            set { bfdata = value; }
        }

        public BeauFort()
        {
            bfdata = new List<BFrec>();

            bfdata.Add(new BFrec(0, 0.0, 0.2, "Szélcsend"));
            bfdata.Add(new BFrec(1, 0.3, 1.5, "Gyenge szél"));
            bfdata.Add(new BFrec(2, 1.6, 3.3, "Gyenge szél"));
            bfdata.Add(new BFrec(3, 3.4, 5.4, "Mérsékelt szél"));
            bfdata.Add(new BFrec(4, 5.5, 7.9, "Mérsékelt szél"));
            bfdata.Add(new BFrec(5, 8.0, 10.7, "Élénk szél"));
            bfdata.Add(new BFrec(6, 10.8, 13.8, "Erős szél"));
            bfdata.Add(new BFrec(7, 13.9, 17.1, "Igen erős szél"));
            bfdata.Add(new BFrec(8, 17.2, 20.7, "Viharos szél"));
            bfdata.Add(new BFrec(9, 20.8, 24.4, "Vihar"));
            bfdata.Add(new BFrec(10, 24.5, 28.4, "Erős vihar"));
            bfdata.Add(new BFrec(11, 28.5, 32.6, "Orkánszerű vihar"));
            bfdata.Add(new BFrec(12, 32.7, 40.8, "Orkán"));
        }

        public BFrec BFfromWS(double wsinmps)
        {
            BFrec result=null;
            
            for (int i = 0; i < 12; i++)
            {
                if (bfdata[i].Low <= wsinmps) { result = bfdata[i]; }
            }
            return result;
        }

    }
}

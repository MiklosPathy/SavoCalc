using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Timers;


namespace SavoCalcLib
{

    public class SavoCalc : INotifyPropertyChanged
    {
        private double wsmps;
        private double height;
        private double width;
        private double rho;
        private double efficiency;
        private double angle;
        private Timer tim = new Timer(10);
        private BeauFort bfdata = new BeauFort();

        public double Angle
        {
            get { return angle; }
            set 
            { 
                angle = value;
                SendPropertyChanges(new String[] { "Angle" });
            }
        }

        public SavoCalc()
        {
            tim.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            tim.Enabled=true;
            Angle = 0;
            Reset();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            Angle += 360 / 100 * Rps;
            if (Angle > 360) Angle = Angle - 360;

        }

        public void Reset()
        {
            WSMps = 1;
            Height_cm = 240;
            Width_cm = 70;
            Rho = 1.293;
            Efficiency = 20;
        }

        private void WSPropertyChanges()
        {
            SendPropertyChanges(new String[] {
                    "WSMps", 
                    "WSKmpH", 
                    "Beaufort" , 
                    "Power" , 
                    "WindPressure", 
                    "Rps",
                    "Rpm"});
        }

        public double WSMps
        {
            get { return wsmps; }
            set
            {
                wsmps = value;
                WSPropertyChanges();
            }
        }

        public double WSKmpH
        {
            get { return wsmps * 3.6; }
            set
            {
                wsmps = value / 3.6;
                WSPropertyChanges();
            }
        }

        private void HeightPropertyChanges()
        {
            SendPropertyChanges(new String[] {
                    "Height_cm", 
                    "Height_m",     
                    "Surface_cm2", 
                    "Surface_m2",
                    "Power" , 
                    "WindPressure"});
        }

        public double Height_m
        {
            get { return height / 100; }
            set
            {
                height = value * 100;
                HeightPropertyChanges();
            }
        }

        public double Height_cm
        {
            get { return height; }
            set
            {
                height = value;
                HeightPropertyChanges();
            }
        }

        private void WidthPropertyChanges()
        {
            SendPropertyChanges(new String[] {
                    "Width_cm", 
                    "Width_m", 
                    "Surface_cm2", 
                    "Surface_m2",
                    "Power" , 
                    "WindPressure", 
                    "Rps",
                    "Rpm"});
        }

        public double Width_m
        {
            get { return width / 100; }
            set
            {
                width = value * 100;
                WidthPropertyChanges();
            }
        }

        public double Width_cm
        {
            get { return width; }
            set
            {
                width = value;
                WidthPropertyChanges();
            }
        }

        public double Surface_m2
        {
            get { return Height_m * Width_m; }
        }

        public double Surface_cm2
        {
            get { return Height_cm * Width_cm; }
        }

        private void RhoPropertyChanges()
        {
            SendPropertyChanges(new String[] {
                    "Rho", 
                    "Rho_gpgm", 
                    "WindPressure",
                    "Power"});
        }

        public double Rho
        {
            get { return rho; }
            set 
            {
                rho = value;
                RhoPropertyChanges();
            }
        }

        public double Rho_gpgm
        {
            get { return rho * 1000; }
            set 
            {
                rho = value / 1000;
                RhoPropertyChanges();
            }
        }

        public double Efficiency
        {
            get { return efficiency; }
            set
            {
                efficiency = value;
                SendPropertyChanges(new String[] {
                    "Efficiency", 
                    "Power"});
            }
        }

        public double Power
        {
            get { return 0.5 * Rho * Surface_m2 * WSMps * WSMps * WSMps * Efficiency / 100; }
        }

        public double WindPressure
        {
            get { return 0.5 * Rho * WSMps * WSMps * Surface_m2; }
        }

        public string Beaufort
        {
            get
            {
                BFrec tempbf = bfdata.BFfromWS(WSMps);
                return tempbf.Scale + " - " + tempbf.Text;
            }
        }

        public double Rps
        {
            get { return WSMps / Width_m / Math.PI; }
        }

        public double Rpm
        {
            get { return Rps * 60; }
        }

        private void SendPropertyChanges(String[] props)
        {
            if (PropertyChanged != null)
            {
                foreach (String s in props)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(s));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

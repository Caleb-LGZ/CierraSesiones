using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CierraSesiones
{
    class Usuario
    {
        public String nombre;
        public String id;
        public String console;
        public String estado;
        public String nose;
        public String fecha;
        public String hora;


        public Usuario()
        {
            nombre = "";
            id = "";
            console = "";
            estado = "";
            nose = "";
            fecha = "";
            hora = "";
        }

        public Usuario(String nombre = "", String console = "", String id = "", String estado = "", String nose = "", String fecha = "", String hora = "")
        {
            this.nombre = nombre;
            this.id = id;
            this.estado = estado;
            this.console = console;
            this.nose = nose;
            this.fecha = fecha;
            this.hora = hora;
        }
        public Usuario(String nombre = "", String id = "", String estado = "", String nose = "", String fecha = "", String hora = "")
        {
            this.nombre = nombre;
            this.id = id;
            this.estado = estado;
            this.nose = nose;
            this.fecha = fecha;
            this.hora = hora;
        }


        public void CloseSession(String args)
        {

            string command = "logoff";
            //string args = desc[0];

            try
            {
                var process = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                };

                var Proc = new Process
                {
                    StartInfo = process,
                    EnableRaisingEvents = true,
                };
                //Arranca el proceso
                Proc.Start();
                while (!Proc.StandardOutput.EndOfStream)
                {
                    string linetext = Proc.StandardOutput.ReadLine();
                    //Console.WriteLine(linetext);
                }
                //Console.ReadLine();
                Proc.Close();
                Proc?.Kill();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }


    }
}

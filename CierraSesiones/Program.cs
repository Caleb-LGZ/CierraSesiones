using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CierraSesiones
{
    class Program
    {
        static void Main(string[] args)
        {
            SendCommand("query", "user");
        }

        static void SendCommand(string command, string args)
        {
            try
            {
                var process = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };
                
                var Proc = new Process
                {
                    StartInfo = process
                };
                ///Arranca el proceso
                Proc.Start();

                string linetext = Proc.StandardOutput.ReadLine();
                //Array usuarios = new Array[100];
                int contador = 0;
                var usuarios = new List<Usuario>();
                var desc = new List<String>();


                while (!Proc.StandardOutput.EndOfStream)
                {


                    ///Cambia los espacios en blanco por @
                    linetext = Proc.StandardOutput.ReadLine();
                    string mensaje = "";
                    for (int i = 0; i < linetext.Length; i++)
                    {
                        //Console.WriteLine("{0}", linetext.Substring(i, 1));
                        if ( (linetext.Substring(i, 1) == " "))
                        {
                            mensaje += "@";
                        }
                        else
                        {
                            mensaje += linetext.Substring(i, 1);
                        }
                    }
                    
                                    
                    ///Los @ anteriormente cambiados, los detecta, elimina y agrega a un arreglo
                    String[] sub = mensaje.Split("@");
                    var prueba = new List<string>();
                    int cont = 0;

                    foreach(var usuario in sub)
                    {
                        if(usuario != "") 
                        {
                            prueba.Add(usuario);
                            //Console.Write(usuario + " ");
                            cont++;
                        }
                    }
                    Console.Write("\n");

                    

                    if(cont == 7)
                    {
                        usuarios.Add(new Usuario(prueba[0], prueba[1], prueba[2], prueba[3], prueba[4], prueba[5], prueba[6]));
                    }
                    else if(cont == 6)
                    {
                        usuarios.Add(new Usuario(prueba[0], prueba[1], prueba[2], prueba[3], prueba[4], prueba[5]));
                    }
                    
                    
                    contador++;
                 



                    //Console.Write(user.nombre);

                    //Console.WriteLine(mensaje);

                    //Console.WriteLine(linetext);
                }


                for (var i = 0; i < usuarios.Count; i++)
                {
                    Console.Write("Nombre: " + usuarios[i].nombre + " ");
                    Console.Write("Id: " + usuarios[i].id + " ");
                    Console.Write("Estado: " + usuarios[i].estado + " ");
                    Console.Write("\n");

                    if(usuarios[i].estado == "Desc")
                    {
                        desc.Add(usuarios[i].id);
                    }
                }

                CloseSession(desc);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        static void CloseSession(List<String> desc)
        {

            string command = "logoff";
            string args = desc[0];

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
                    StartInfo = process
                };
                //Arranca el proceso
                Proc.Start();
                while (!Proc.StandardOutput.EndOfStream)
                {
                    string linetext = Proc.StandardOutput.ReadLine();
                    Console.WriteLine(linetext);
                }
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }


    }


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


    }

}

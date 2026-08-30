using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoXelaDelivery
{
    class Persona
    {
        private int codigo;
        private string nombreCompleto;
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public Persona(int codigo, string nombreCompleto, string telefono)
        {
            Codigo = codigo;
            NombreCompleto = nombreCompleto;
            Telefono = telefono;
        }
        public void MostrarInformacion()
        {

        }
    }
    class Repartidor : Persona
    {
        private string numeroLicencia;
        private string tipoLicencia;
        private string disponibilidad;
        private int calificacionEntregas;

        public int CalificacionEntregas
        {
            get { return calificacionEntregas; }
            set { calificacionEntregas = value; }
        }

        public string Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }

        public string TipoLicencia
        {
            get { return tipoLicencia; }
            set { tipoLicencia = value; }
        }

        public string NumeroLicencia
        {
            get { return numeroLicencia; }
            set { numeroLicencia = value; }
        }
        public Repartidor(int codigo, string nombreCompleto, string telefono, string numeroLicencia, string tipoLicencia, string disponibilidad, int calificacionEntregas)
            : base(codigo, nombreCompleto, telefono)
        {
            NumeroLicencia = numeroLicencia;
            TipoLicencia = tipoLicencia;
            Disponibilidad = disponibilidad;
            CalificacionEntregas = calificacionEntregas;
        }

    }
    class Cliente : Persona
    {
        private string correoElectronico;
        private string direccion;
        private int cantidadSolicitudes;

        public int CantidadSolicitudes
        {
            get { return cantidadSolicitudes; }
            set { cantidadSolicitudes = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }
        public Cliente(int codigo, string nombreCompleto, string telefono, string correoElectronico, string direccion, int cantidadSolicitudes)
            : base(codigo, nombreCompleto, telefono)
        {
            CorreoElectronico = correoElectronico;
            Direccion = direccion;
            CantidadSolicitudes = cantidadSolicitudes;
        }

    }
    class Entrega
    {
        private DateTime fecha;
        private int codigo;
        private string direccionOrigen;
        private string direccionDestino;
        private double distanciaEstimada;
        private string tipoServicio;
        private string estado;
        private double tarifaBase;
        private double recargos;
        private double descuentos;
        private double total;


        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public double Descuentos
        {
            get { return descuentos; }
            set { descuentos = value; }
        }

        public double Recargos
        {
            get { return recargos; }
            set { recargos = value; }
        }

        public double TarifaBase
        {
            get { return tarifaBase; }
            set { tarifaBase = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string TipoServicio
        {
            get { return tipoServicio; }
            set { tipoServicio = value; }
        }

        public double DistanciaEstimada
        {
            get { return distanciaEstimada; }
            set { distanciaEstimada = value; }
        }

        public string DireccionDestino
        {
            get { return direccionDestino; }
            set { direccionDestino = value; }
        }

        public string DireccionOrigen
        {
            get { return direccionOrigen; }
            set { direccionOrigen = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Entrega(DateTime fecha, int codigo, string direccionOrigen, string direccionDestino, double distanciaEstimada, string tipoServicio, string estado, double tarifaBase, double recargos, double descuentos, double total)
        {
            Fecha = fecha;
            Codigo = codigo;
            DireccionOrigen = direccionOrigen;
            DireccionDestino = direccionDestino;
            DistanciaEstimada = distanciaEstimada;
            TipoServicio = tipoServicio;
            Estado = estado;
            TarifaBase = tarifaBase;
            Recargos = recargos;
            Descuentos = descuentos;
            Total = total;
        }

    }
    class Vehiculo
    {
        private int codigo;
        private string marca;
        private string modelo;
        private double capacidadMaximaCarga;
        private string estado;
        private double costoOperativo;


        public double CostoOperativo
        {
            get { return costoOperativo; }
            set { costoOperativo = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public double CapacidadMaximaCarga
        {
            get { return capacidadMaximaCarga; }
            set { capacidadMaximaCarga = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public Vehiculo(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadMaximaCarga = capacidadMax;
            Estado = estado;
            CostoOperativo = CostoOperativo;
        }

    }
    class Automovil : Vehiculo
    {
        private string placa;

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public Automovil(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo, string placa)
            : base(codigo, marca, modelo, capacidadMax, estado, costoOperativo)
        {
            Placa = placa;
        }

    }
    class Moticicleta : Vehiculo
    {
        private string placa;

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public Moticicleta(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo, string placa)
            : base(codigo, marca, modelo, capacidadMax, estado, costoOperativo)
        {
            Placa = placa;
        }
    }
    class Bicicleta : Vehiculo
    {
        public Bicicleta(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo)
            : base(codigo, marca, modelo, capacidadMax, estado, costoOperativo)
        {

        }
    }
    class Paquete
    {
        private int codigo;
        private string descripcion;
        private double peso;
        private double valorDeclarado;
        private string direccionOrigen;
        private string direccionDestino;
        private string estado;
        public Paquete(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Peso = peso;
            ValorDeclarado = valorDeclarado;
            DireccionOrigen = direccionOrigen;
            DireccionDestino = direccionDestino;
            Estado = estado;
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string DireccionDestino
        {
            get { return direccionDestino; }
            set { direccionDestino = value; }
        }

        public string DireccionOrigen
        {
            get { return direccionOrigen; }
            set { direccionOrigen = value; }
        }

        public double ValorDeclarado
        {
            get { return valorDeclarado; }
            set { valorDeclarado = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
    class ProductoRefrigerado : Paquete
    {
        public ProductoRefrigerado(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
            : base(codigo, descripcion, peso, valorDeclarado, direccionOrigen, direccionDestino, estado)
        {

        }

    }
    class PaqueteFragil : Paquete
    {
        public PaqueteFragil(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
            : base(codigo, descripcion, peso, valorDeclarado, direccionOrigen, direccionDestino, estado)
        {

        }

    }
    class PaqueteEstandar : Paquete
    {
        public PaqueteEstandar(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
            : base(codigo, descripcion, peso, valorDeclarado, direccionOrigen, direccionDestino, estado)
        {

        }
    }
    class Documento : Paquete
    {
        public Documento(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
            : base(codigo, descripcion, peso, valorDeclarado, direccionOrigen, direccionDestino, estado)
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> Clientes = new List<Cliente>();
            List<Repartidor> Repartidores = new List<Repartidor>();
            List<Automovil> Automoviles = new List<Automovil>();
            List<Moticicleta> Mocoticletas = new List<Moticicleta>();
            List<Bicicleta> Bicicletas = new List<Bicicleta>();

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("========================================\r\n GOXELA DELIVERY\r\n========================================\r\n1. Gestión de clientes\r\n2. Gestión de repartidores\r\n3. Gestión de vehículos\r\n4. Gestión de paquetes\r\n5. Gestión de entregas\r\n6. Gestión de incidencias\r\n7. Reportes\r\n8. Salir");
                opcion = ValidacionEntradas("Ingrese una opción: ");
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese nombre completo: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese número de telefono: ");
                        string numeroTelefono = Console.ReadLine();
                        Console.WriteLine("I");

                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Saliendo del programa...");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 8);
        }
        static int ValidacionEntradas(string mensaje)
        {
            int valor;
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out valor);
                if (!esValido)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor ingrese un numero");
                }

            } while (!esValido);
            return valor;
        }

    }
}

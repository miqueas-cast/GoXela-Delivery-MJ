using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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
        public void MostrarInformacion()
        {
            Console.WriteLine($"Código: REP-{Codigo}");
            Console.WriteLine($"Nombre: {NombreCompleto}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Numero de licencia: {numeroLicencia}");
            Console.WriteLine($"Tipo Licencia: {TipoLicencia}");
            Console.WriteLine($"Estado: {Disponibilidad}");
            Console.WriteLine($"Calificación entregas: {CalificacionEntregas}");
        }
        public void actualizarDisponibilidad(string nuevoEstado)
        {
            Disponibilidad = nuevoEstado; 
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
        public void MostrarInformacion()
        {
            Console.WriteLine($"Código: CLI-{Codigo}");
            Console.WriteLine($"Nombre: {NombreCompleto}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Correo electrónico: {CorreoElectronico}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Cantidad de solicitudes: {CantidadSolicitudes}");
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
                opcion = ValidacionEntradas("Ingrese una opción: ",1, 8, "Opción fuera del rango");
                switch (opcion)
                {
                    case 1:
                        int opcionCliente;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1. Registrar\n2. Consultar\n3. Actualizar\n4. Mostrar Información\n5. Volver al menu principal");
                            opcionCliente = ValidacionEntradas("Ingrese una opción: ",1,5, "Opción fuera del rango");
                            switch (opcionCliente)
                            {
                                case 1:
                                    Console.Clear();
                                    int contadorCodigo = Clientes.Count +1;
                                    
                                    Console.Write("Ingrese nombre cliente: ");
                                    string nombre = Console.ReadLine();
                                    string numeroTelefono;
                                    while (true)
                                    {
                                        Console.Write("Ingrese número de telefono: ");
                                        numeroTelefono = Console.ReadLine();

                                        if(ValidarTelefono(numeroTelefono))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Número de teléfono inválido. Debe tener 8 dígitos y solo contener números.");
                                        }
                                    }
                                    string correoCliente;
                                    while(true)
                                    {
                                        Console.Write("Ingrese correo electrónico: ");
                                        correoCliente = Console.ReadLine();
                                        if (ValidarCorreoElectronico(correoCliente))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Correo electrónico inválido. Debe contener un '@'.");
                                        }
                                    }
                                    Console.Write("Ingrese dirección: ");
                                    string direccion = Console.ReadLine();


                                    int cantidadSolicitudes = ValidacionEntradas("Ingrese cantidad de solicitudes: ",1, 100, "Cantidad de solicitudes no permitida" );

                                    Clientes.Add(new Cliente(contadorCodigo, nombre, numeroTelefono, correoCliente, direccion, cantidadSolicitudes));

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
                                    Console.WriteLine("Información de cliente: ");
                                    foreach (Cliente cliente in Clientes)
                                    {
                                        cliente.MostrarInformacion();
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    break;
                            }

                        } while (opcionCliente != 5);

                        break;
                    case 2:
                        Console.Clear();
                        int opcionRepartidor;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1. Registrar \n2. Actualizar disponibilidad\n3. Actualizar entregas\n4. Mostrar Información\n5. Volver al menu principal");
                            opcionRepartidor = ValidacionEntradas("Ingrese una opción: ", 1, 4, "Opción fuera del rango");
                            switch (opcionRepartidor)
                            {
                                case 1:
                                    Console.Clear();
                                    int contadorRepartidores = Repartidores.Count + 1;
                                    Console.WriteLine("Ingrese nombre repartidor: ");
                                    string repartidorNombre = Console.ReadLine();
                                    string numeroRepartidor;
                                    while (true)
                                    {
                                        Console.Write("Ingrese número: ");
                                        numeroRepartidor = Console.ReadLine();
                                        if (ValidarTelefono(numeroRepartidor))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Número de teléfono inválido. Debe tener 8 dígitos y solo contener números.");
                                        }
                                    }
                                    string numeroLicencia;
                                    while (true)
                                    {
                                        Console.WriteLine("Ingrese número licencia");
                                        numeroLicencia = Console.ReadLine();
                                        if (ValidarLicencia(numeroLicencia))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Numero de licencia invaldia");
                                        }
                                    }
                                    string tipoLicencia;
                                    while (true)
                                    {
                                        int tipoLicenciaa = ValidacionEntradas("Seleccióne tipo de licencia: \n1. C\n2. B\n3. A\n4. M\n5. E\n", 1, 5, "Opción invalida");
                                        if(tipoLicenciaa == 1)
                                        {
                                            tipoLicencia = "C";
                                            break;
                                        }
                                        else if(tipoLicenciaa == 1)
                                        {
                                            tipoLicencia = "B";
                                            break;
                                        }
                                        else if(tipoLicenciaa == 3)
                                        {
                                            tipoLicencia = "A";
                                            break;
                                        }
                                        else if(tipoLicenciaa == 4)
                                        {
                                            tipoLicencia = "M";
                                            break;
                                        }
                                        else
                                        {
                                            tipoLicencia = "E";
                                            break;
                                        }
                                    }
                                    string estado;
                                    while (true)
                                    {
                                        int estadoRepartidor = ValidacionEntradas("Estado: \n1. Disponible\n2. Asignado\n3. Fuera de servicio\n Opción: ", 1, 3, "Estado no valido");
                                        if(estadoRepartidor == 1)
                                        {
                                            estado = "Disponible";
                                            break;
                                        }
                                        else if(estadoRepartidor == 2)
                                        {
                                            estado = "Asignado";
                                            break;
                                        }
                                        else
                                        {
                                            estado = "Fuera de servicio";
                                            break;
                                        }
                                    }
                                    int cantidadEntregas = ValidacionEntradas("Ingrese cantidad de entregas: ", 1, 500, "Cantidad de entregas no valida");

                                    Repartidores.Add(new Repartidor(contadorRepartidores, repartidorNombre, numeroRepartidor, numeroLicencia, tipoLicencia, estado, 5));
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Actualizar disponibilidad de un repartidor");
                                    Console.WriteLine();
                                    Console.Write("Ingrese nombre de repartidor: ");
                                    string repartidor = Console.ReadLine();
                                    int indiceRep= -1;
                                    for(int i = 0; i< Repartidores.Count; i++)
                                    {
                                        if (Repartidores[i].NombreCompleto == repartidor)
                                        {
                                            indiceRep = i;
                                            break;
                                        }
                                    }
                                    if(indiceRep != -1)
                                    {
                                        Console.WriteLine("Repartidor encontrado");
                                        Console.WriteLine($"Estado actual: {Repartidores[indiceRep].Disponibilidad}");
                                        Console.WriteLine();
                                        Console.WriteLine("Selecciona nuevo estado");
                                        while (true)
                                        {
                                            int estadoRepartidorNuevo = ValidacionEntradas("Estado: \n1. Disponible\n2. Asignado\n3. Fuera de servicio", 1, 3, "Estado no valido");
                                            if (estadoRepartidorNuevo == 1)
                                            {
                                                if(Repartidores[indiceRep].Disponibilidad == "Disponible")
                                                {
                                                    Console.WriteLine("No puede asignarse el mismo estado!");
                                                }
                                                else
                                                {
                                                    Repartidores[indiceRep].actualizarDisponibilidad("Disponible");
                                                    break;

                                                }
                                            }
                                            else if (estadoRepartidorNuevo == 2)
                                            {
                                                if (Repartidores[indiceRep].Disponibilidad == "Asignado")
                                                {
                                                    Console.WriteLine("No puede asignarse el mismo estado!");
                                                }
                                                else
                                                {
                                                    Repartidores[indiceRep].actualizarDisponibilidad("Asignado");
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (Repartidores[indiceRep].Disponibilidad == "Fuera de servicio")
                                                {
                                                    Console.WriteLine("No puede asignarse el mismo estado!");
                                                }
                                                else
                                                {
                                                    Repartidores[indiceRep].actualizarDisponibilidad("Fuera de servicio");
                                                    break;
                                                }
                                            }
                                        }
                                        Console.Clear();
                                        Console.WriteLine("Estado cambiado exitosamente!");
                                        Console.ReadKey();
                                        break;
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Repartidor no encontrado");
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();

                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    foreach(Repartidor repartidorSin in Repartidores)
                                    {
                                        repartidorSin.MostrarInformacion();
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    break;
                            }
                        }while(opcionRepartidor != 5);
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
        static int ValidacionEntradas(string mensaje, int min, int max, string errorMensaje)
        {
            int valor;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out valor);
                if (!esValido)
                {
                    Console.WriteLine("Por favor ingrese un número");
                }
                else if(valor < min || valor > max)
                {
                    Console.WriteLine(errorMensaje);
                    esValido = false;
                }

            } while (!esValido);
            return valor;
        }
        static bool ValidarLicencia(string telefono)
        {
            if (telefono.Length != 13)
            {
                return false;
            }
            foreach (char c in telefono)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        static bool ValidarTelefono(string telefono)
        {
            if(telefono.Length != 8)
            {
                return false;
            }
            foreach(char c in telefono)
            {
                if(!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        static bool ValidarCorreoElectronico(string correo)
        {
           foreach(char c in correo)
            {
                if (c == '@')
                {
                    return true;
                }
            }
            return false;
        }


    }
}

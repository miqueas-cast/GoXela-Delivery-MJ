using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
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
            set
            {
                if (value != "")
                {
                    telefono = value;
                }
            }
        }
        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set
            {
                if (value != "")
                {
                    nombreCompleto = value;
                }
            }
        }
        public int Codigo
        {
            get { return codigo; }
            set
            {
                if (value > 0)
                {
                    codigo = value;
                }
            }
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
        private int cantidadEntregas;

        public int CantidadEntregas
        {
            get { return cantidadEntregas; }
            set
            {
                if (value > 0)
                {
                    cantidadEntregas = value;
                }

            }
        }

        public int CalificacionEntregas
        {
            get { return calificacionEntregas; }
            set
            {
                if (value > 0)
                {
                    calificacionEntregas = value;
                }
            }
        }

        public string Disponibilidad
        {
            get { return disponibilidad; }
            set
            {
                if (value != "")
                {
                    disponibilidad = value;
                }
            }
        }

        public string TipoLicencia
        {
            get { return tipoLicencia; }
            set
            {
                if (value != "")
                {
                    tipoLicencia = value;
                }
            }
        }

        public string NumeroLicencia
        {
            get { return numeroLicencia; }
            set
            {
                if (value != "")
                {
                    numeroLicencia = value;
                }
            }
        }
        public Repartidor(int codigo, string nombreCompleto, string telefono, string numeroLicencia, string tipoLicencia, string disponibilidad, int cantidadEntregas, int calificacionEntregas)
            : base(codigo, nombreCompleto, telefono)
        {
            NumeroLicencia = numeroLicencia;
            TipoLicencia = tipoLicencia;
            Disponibilidad = disponibilidad;
            CantidadEntregas = cantidadEntregas;
            CalificacionEntregas = calificacionEntregas;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ REP-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Nombre:",-25} {NombreCompleto}");
            Console.WriteLine($"{"Teléfono:",-25} {Telefono}");
            Console.WriteLine($"{"Número de licencia:",-25} {numeroLicencia}");
            Console.WriteLine($"{"Tipo Licencia:",-25} {TipoLicencia}");
            Console.WriteLine($"{"Estado:",-25} {Disponibilidad}");
            Console.WriteLine($"{"Cantidad entregas:",-25} {CantidadEntregas}");
            Console.WriteLine($"{"Calificación entregas:",-25} {CalificacionEntregas}");
            Console.WriteLine("--------------------------------------------\n");
        }
        public void actualizarDisponibilidad(string nuevoEstado)
        {
            Disponibilidad = nuevoEstado;
        }
        public void ActualizarEntregas(int nuevasEntregas)
        {
            CantidadEntregas += nuevasEntregas;
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
            set
            {

                if (value > 0)
                {
                    cantidadSolicitudes = value;
                }
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value != "")
                {
                    direccion = value;
                }
            }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set
            {
                if (value != "" && value.Contains("@"))
                {
                    correoElectronico = value;
                }
            }
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
            Console.WriteLine($"                [ CLI-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Nombre:",-25} {NombreCompleto}");
            Console.WriteLine($"{"Teléfono:",-25} {Telefono}");
            Console.WriteLine($"{"Correo electrónico:",-25} {CorreoElectronico}");
            Console.WriteLine($"{"Dirección:",-25} {Direccion}");
            Console.WriteLine($"{"Cantidad de solicitudes:",-25} {CantidadSolicitudes}");
            Console.WriteLine("--------------------------------------------\n");
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
            set
            {
                if (value > 0)
                {
                    codigo = value;

                }
            }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public double Descuentos
        {
            get { return descuentos; }
            set
            {
                if (value > 0)
                {
                    descuentos = value;
                }
            }
        }

        public double Recargos
        {
            get { return recargos; }
            set
            {
                if (value > 0)
                {
                    recargos = value;
                }
            }
        }

        public double TarifaBase
        {
            get { return tarifaBase; }
            set
            {
                if (value > 0)
                {
                    tarifaBase = value;
                }
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value != "")
                {
                    estado = value;
                }
            }
        }

        public string TipoServicio
        {
            get { return tipoServicio; }
            set
            {
                if (value != "")
                {
                    tipoServicio = value;
                }
            }
        }

        public double DistanciaEstimada
        {
            get { return distanciaEstimada; }
            set { distanciaEstimada = value; }
        }

        public string DireccionDestino
        {
            get { return direccionDestino; }
            set
            {
                if (value != "")
                {
                    direccionDestino = value;
                }
            }
        }

        public string DireccionOrigen
        {
            get { return direccionOrigen; }
            set
            {
                if (value != "")
                {
                    direccionOrigen = value;
                }
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (value >= DateTime.Now)
                {
                    fecha = value;
                }
            }
        }


        public List<Incidencias> IncidenciasHistorial { get; set; } = new List<Incidencias>();
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
            IncidenciasHistorial = new List<Incidencias>();
        }
        public void AgregarNuevaIncidencia(Incidencias incidencia)
        {
            IncidenciasHistorial.Add(incidencia);
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
            set
            {
                if (value > 0)
                {
                    costoOperativo = value;
                }
            }
        }
        public string Estado
        {
            get { return estado; }
            set
            {
                if (value != "")
                {
                    estado = value;
                }
            }
        }

        public double CapacidadMaximaCarga
        {
            get { return capacidadMaximaCarga; }
            set
            {
                if (value > 0)
                {
                    capacidadMaximaCarga = value;
                }
            }
        }

        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (value != "")
                {
                    modelo = value;
                }
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (value != "")
                {
                    marca = value;
                }
            }
        }

        public int Codigo
        {
            get { return codigo; }
            set
            {
                if (value > 0)
                {
                    codigo = value;
                }
            }
        }
        public Vehiculo(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadMaximaCarga = capacidadMax;
            Estado = estado;
            CostoOperativo = costoOperativo;
        }

    }
    class Automovil : Vehiculo
    {
        private string placa;

        public string Placa
        {
            get { return placa; }
            set
            {
                if (value != "")
                {
                    placa = value;
                }
            }
        }
        public Automovil(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo, string placa)
            : base(codigo, marca, modelo, capacidadMax, estado, costoOperativo)
        {
            Placa = placa;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ AUT-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Placa:",-28} {Placa}");
            Console.WriteLine($"{"Marca:",-28} {Marca}");
            Console.WriteLine($"{"Modelo:",-28} {Modelo}");
            Console.WriteLine($"{"Capacidad máxima de carga:",-28} {CapacidadMaximaCarga} kg");
            Console.WriteLine($"{"Estado:",-28} {Estado}");
            Console.WriteLine($"{"Costo operativo:",-28} Q.{CostoOperativo}");
            Console.WriteLine("--------------------------------------------\n");
        }

    }
    class Moticicleta : Vehiculo
    {
        private string placa;

        public string Placa
        {
            get { return placa; }
            set
            {
                if (value != "")
                {
                    placa = value;
                }
            }
        }
        public Moticicleta(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo, string placa)
            : base(codigo, marca, modelo, capacidadMax, estado, costoOperativo)
        {
            Placa = placa;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ MOT-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Placa:",-28} {Placa}");
            Console.WriteLine($"{"Marca:",-28} {Marca}");
            Console.WriteLine($"{"Modelo:",-28} {Modelo}");
            Console.WriteLine($"{"Capacidad máxima de carga:",-28} {CapacidadMaximaCarga} kg");
            Console.WriteLine($"{"Estado:",-28} {Estado}");
            Console.WriteLine($"{"Costo operativo:",-28} Q.{CostoOperativo}");
            Console.WriteLine("--------------------------------------------\n");
        }
    }
    class Bicicleta : Vehiculo
    {
        public Bicicleta(int codigo, string marca, string modelo, double capacidadMax, string estado, double costoOperativo)
            : base(codigo, marca, modelo, capacidadMax, estado, costoOperativo)
        {

        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ BIC-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Marca:",-28} {Marca}");
            Console.WriteLine($"{"Modelo:",-28} {Modelo}");
            Console.WriteLine($"{"Capacidad máxima de carga:",-28} {CapacidadMaximaCarga} kg");
            Console.WriteLine($"{"Estado:",-28} {Estado}");
            Console.WriteLine($"{"Costo operativo:",-28} Q.{CostoOperativo}");
            Console.WriteLine("--------------------------------------------\n");
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

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value != "")
                {
                    estado = value;
                }
            }
        }

        public string DireccionDestino
        {
            get { return direccionDestino; }
            set
            {
                if (value != "")
                {
                    direccionDestino = value;
                }
            }
        }

        public string DireccionOrigen
        {
            get { return direccionOrigen; }
            set
            {
                if (value != "")
                {
                    direccionOrigen = value;
                }
            }
        }

        public double ValorDeclarado
        {
            get { return valorDeclarado; }
            set
            {
                if (value > 0)
                {
                    valorDeclarado = value;
                }
            }
        }

        public double Peso
        {
            get { return peso; }
            set
            {
                if (value > 0)
                {
                    peso = value;
                }
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (value != "")
                {
                    descripcion = value;
                }
            }
        }

        public int Codigo
        {
            get { return codigo; }
            set
            {
                if (value > 0)
                {
                    codigo = value;
                }
            }
        }
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
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ PAQ-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Descripción:",-25} {Descripcion}");
            Console.WriteLine($"{"Peso:",-25} {Peso} kg");
            Console.WriteLine($"{"Valor declarado:",-25} Q.{ValorDeclarado}");
            Console.WriteLine($"{"Dirección de origen:",-25} {DireccionOrigen}");
            Console.WriteLine($"{"Dirección de destino:",-25} {DireccionDestino}");
            Console.WriteLine($"{"Estado:",-25} {Estado}");
            Console.WriteLine("--------------------------------------------\n");
        }
        public void ActualizarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }
        public virtual void CalcularCostoEnvio()
        {

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
    class Incidencias
    {
        private int codigo;
        private string tipo;
        private string descripcion;
        private DateTime fecha;
        private string estado;
        private string accionTomada;

        public string AccionTomada
        {
            get { return accionTomada; }
            set { accionTomada = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public Incidencias(int codigo, string tipo, string descripcion, DateTime fecha, string estado, string accionTomada)
        {
            Codigo = codigo;
            Tipo = tipo;
            Descripcion = descripcion;
            Fecha = fecha;
            Estado = estado;
            AccionTomada = accionTomada;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ INC-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Tipo:",-25} {Tipo}");
            Console.WriteLine($"{"Descripción:",-25} {Descripcion}");
            Console.WriteLine($"{"Fecha:",-25} {Fecha}");
            Console.WriteLine($"{"Estado:",-25} {Estado}");
            Console.WriteLine($"{"Acción tomada:",-25} {AccionTomada}");
            Console.WriteLine("--------------------------------------------\n");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> Clientes = new List<Cliente>();
            List<Repartidor> Repartidores = new List<Repartidor>();
            List<Automovil> Automoviles = new List<Automovil>();
            List<Moticicleta> Motocicletas = new List<Moticicleta>();
            List<Bicicleta> Bicicletas = new List<Bicicleta>();
            List<Paquete> Paquetes = new List<Paquete>();
            List<Documento> Documentos = new List<Documento>();
            List<PaqueteEstandar> PaquetesEstandar = new List<PaqueteEstandar>();
            List<PaqueteFragil> PaquetesFragiles = new List<PaqueteFragil>();
            List<ProductoRefrigerado> ProductosRefrigerados = new List<ProductoRefrigerado>();
            List<Entrega> Entregass = new List<Entrega>();
            List<Incidencias> IncidenciasList = new List<Incidencias>();


            int opcion;
            do
            {
                Console.Clear();
                opcion = ValidacionEntradas("========================================\r\n GOXELA DELIVERY\r\n========================================\r\n1. Gestión de clientes\r\n2. Gestión de repartidores\r\n3. Gestión de vehículos\r\n4. Gestión de paquetes\r\n5. Gestión de entregas\r\n6. Gestión de incidencias\r\n7. Reportes\r\n8. Salir\nIngrese una opción: ", 1, 8, "Opción fuera del rango");
                switch (opcion)
                {
                    case 1:
                        int opcionCliente;

                        do
                        {
                            Console.Clear();
                            
                            opcionCliente = ValidacionEntradas("CLIENTES\n\n1. Registrar\n2. Consultar\n3. Actualizar información\n4. Volver al menu principal\n\nIngrese una opción: ", 1, 4, "Opción fuera del rango");
                            switch (opcionCliente)
                            {
                                case 1:
                                    Console.Clear();
                                    int contadorCodigo = Clientes.Count + 1;

                                    Console.Write("Ingrese nombre cliente: ");
                                    string nombre = Console.ReadLine();
                                    Console.Clear();
                                    string numeroTelefono;
                                    while (true)
                                    {
                                        Console.Write("Ingrese número de telefono: ");
                                        numeroTelefono = Console.ReadLine();

                                        if (ValidarTelefono(numeroTelefono))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            MostrarErrorAnimado("Error: Número de teléfono inválido. Debe tener 8 dígitos y solo contener números. ");
                                        }
                                    }
                                    Console.Clear();
                                    string correoCliente;
                                    while (true)
                                    {
                                        Console.Write("Ingrese su usuario de correo: ");
                                        correoCliente = Console.ReadLine();
                                        if (!string.IsNullOrWhiteSpace(correoCliente) && !correoCliente.Contains("@"))
                                        {
                                            break;
                                        }
                                        MostrarErrorAnimado("Error: Ingrese un usuario válido  y no incluya el símbolo '@'");
                                    }
                                    int opcionDominio = ValidacionEntradas("Seleccione el dominio de correo electrónico:\n1. @gmail.com\n2. @hotmail.com\n3. @outlook.com\n4. @yahoo.com\n5. @icloud.com\n\nIngrese una opción: ", 1, 5, "Opción fuera del rango");
                                    string dominioElegido = "";
                                    switch (opcionDominio)
                                    {
                                        case 1: dominioElegido = "@gmail.com"; break;
                                        case 2: dominioElegido = "@outlook.com"; break;
                                        case 3: dominioElegido = "@hotmail.com"; break;
                                        case 4: dominioElegido = "@yahoo.com"; break;
                                        case 5: dominioElegido = "@icloud.com"; break;
                                    }

                                    Console.Clear();
                                    string correoElectronico = correoCliente + dominioElegido;

                                    Console.Write("Ingrese dirección: ");
                                    string direccion = Console.ReadLine();

                                    Console.Clear();
                                    int confirmacionCliente = ValidacionEntradas($"Resumen de datos:\n \nNombre: {nombre}\nNúmero de teléfono: {numeroTelefono}\nCorreo electronico: {correoElectronico}\nDirección: {direccion}\n\n¿Esta seguro que desea agreagar CLI-{contadorCodigo}?\n1. Sí\n2. No\nIngrese una opción: ",1, 2, "Erro: Opción no valida");
                                    if(confirmacionCliente == 1)
                                    {
                                        Console.Clear();
                                        Clientes.Add(new Cliente(contadorCodigo, nombre, numeroTelefono, correoElectronico, direccion, 0));
                                        MostrarAnimacionPuntos();

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        MostrarErrorAnimado("Operación cancelada");
                                        break;
                                    }
 
                                    break;
                                case 2:
                                    Console.Clear();
                                    if(Clientes.Count == 0)
                                    {
                                        Console.Clear();
                                        MostrarErrorAnimado("No hay clientes registrados");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Clientes registrados: ");
                                        Console.WriteLine();
                                        foreach (Cliente cliente in Clientes)
                                        {
                                            cliente.MostrarInformacion();
                                            Console.WriteLine();
                                        }

                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();

                                    int codigoClienteActualizar = ValidacionEntradas("Ingrese el codigo del cliente: CLI-", 1, int.MaxValue, "Cliente no encontrado");
                                    int indiceCliente = -1;
                                    for(int i = 0; i<Clientes.Count; i++)
                                    {
                                        if (Clientes[i].Codigo == codigoClienteActualizar)
                                        {
                                            indiceCliente = i;
                                            break;
                                        }
                                    }
                                    if (indiceCliente == -1) 
                                    {
                                        MostrarErrorAnimado("Cliente no encontrado");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Cliente encontrado");
                                        Console.WriteLine();
                                        Clientes[indiceCliente].MostrarInformacion();
                                        Console.ReadKey();
                                        Console.WriteLine();

                                        int opcionActualizar;
                                        do
                                        {
                                            Console.Clear();
                                            opcionActualizar = ValidacionEntradas($"\n Seleccióne información a cambiar:\n \n1. Teléfono\n2. Correo electronico\n3. Dirección\n4. Volver atrás\n\nIngrese una opción: ", 1, 4, "Opción no valida");
                                            switch (opcionActualizar)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    while (true)
                                                    {
                                                        Console.Write("Ingrese nuevo número de teléfono: ");
                                                        string nuevoNumeroTelefono = Console.ReadLine();
                                                        if (ValidarTelefono(nuevoNumeroTelefono))
                                                        {
                                                            Console.WriteLine();
                                                            Clientes[indiceCliente].Telefono = nuevoNumeroTelefono;
                                                            Console.WriteLine("Numero de teléfono cambiado exitosamente!");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            MostrarErrorAnimado("Error: Número de teléfono inválido. Debe tener 8 dígitos y solo contener números.");
                                                        }
                                                    }
                                                   
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    while (true)
                                                    {
                                                        string correoClienteNuevo;
                                                        while (true)
                                                        {
                                                            Console.Write("Ingrese su usuario de correo: ");
                                                            correoClienteNuevo = Console.ReadLine();
                                                            if (!string.IsNullOrWhiteSpace(correoClienteNuevo) && !correoClienteNuevo.Contains("@")) 
                                                            {
                                                                break;
                                                            }
                                                            Console.Clear();
                                                            MostrarErrorAnimado("Error: Ingrese un usuario válido  y no incluya el símbolo '@'");
                                                        }
                                                        int opcionDominio2 = ValidacionEntradas("Seleccione el dominio de correo electrónico:\n1. @gmail.com\n2. @hotmail.com\n3. @outlook.com\n4. @yahoo.com\n5. @icloud.com\nIngrese una opción: ", 1, 5, "Opción fuera del rango");
                                                        string dominioElegido2 = "";
                                                        switch (opcionDominio2)
                                                        {
                                                            case 1: dominioElegido2 = "@gmail.com"; break;
                                                            case 2: dominioElegido2 = "@outlook.com"; break;
                                                            case 3: dominioElegido2 = "@hotmail.com"; break;
                                                            case 4: dominioElegido2 = "@yahoo.com"; break;
                                                            case 5: dominioElegido2 = "@icloud.com"; break;
                                                        }

                                                        string correoElectronicoNuevo = correoClienteNuevo + dominioElegido2;
                                                        Clientes[indiceCliente].CorreoElectronico = correoElectronicoNuevo;
                                                        Console.WriteLine("Correo electronico actualizado con exito!");
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    Console.Write("Ingrese nueva dirección: ");
                                                    string nuevaDirección = Console.ReadLine();
                                                    Clientes[indiceCliente].Direccion = nuevaDirección;
                                                    Console.WriteLine();
                                                    Console.WriteLine("Nuevo dirección actualizada exitosamente!");
                                                    break;
                                                case 4:
                                                    break;
                                            }
                                        } while (opcionActualizar != 4);
                                    }
                                    break;
                                case 4:
                                    break;
                            }

                        } while (opcionCliente != 4);

                        break;
                    case 2:
                        Console.Clear();
                        int opcionRepartidor;

                        do
                        {
                            Console.Clear();
                            opcionRepartidor = ValidacionEntradas("REPARTIDORES\n\n1. Registrar\n2. Consultar\n3. Actualizar información\n4. Volver al menu principal\n\nIngrese una opción: ", 1, 4, "Opción fuera del rango");
                            switch (opcionRepartidor)
                            {
                                case 1:
                                    Console.Clear();
                                    int contadorRepartidores = Repartidores.Count + 1;
                                    Console.Write("Ingrese nombre repartidor: ");
                                    string repartidorNombre = Console.ReadLine();
                                    Console.Clear();
                                    string numeroRepartidor;
                                    while (true)
                                    {
                                        Console.Write("Ingrese número de telefono: ");
                                        numeroRepartidor = Console.ReadLine();
                                        if (ValidarTelefono(numeroRepartidor))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            MostrarErrorAnimado("Error: Número de teléfono inválido. Debe tener 8 dígitos y solo contener números.");
                                        }
                                    }
                                    Console.Clear();
                                    string numeroLicencia;
                                    while (true)
                                    {
                                        Console.Write("Ingrese número licencia: ");
                                        numeroLicencia = Console.ReadLine();
                                        if (ValidarLicencia(numeroLicencia))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            MostrarErrorAnimado("Error: Número de licencia inválido");
                                        }
                                    }
                                    Console.WriteLine();
                                    string tipoLicencia;
                                    while (true)
                                    {
                                        int tipoLicenciaa = ValidacionEntradas("Seleccióne tipo de licencia: \n1. C\n2. B\n3. A\n4. M\n5. E\nIngrese una opción: ", 1, 5, "Error: Opción invalida");
                                        if (tipoLicenciaa == 1)
                                        {
                                            tipoLicencia = "C";
                                            break;
                                        }
                                        else if (tipoLicenciaa == 1)
                                        {
                                            tipoLicencia = "B";
                                            break;
                                        }
                                        else if (tipoLicenciaa == 3)
                                        {
                                            tipoLicencia = "A";
                                            break;
                                        }
                                        else if (tipoLicenciaa == 4)
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
                                    Console.Clear();
                                    string estadoRepartidor;
                                    while (true)
                                    {
                                        int estadoRepartidorIn = ValidacionEntradas("Estado: \n1. Disponible\n2. Asignado\n3. Fuera de servicio\n\nIngrese opción: ", 1, 3, "Estado no valido");
                                        if (estadoRepartidorIn == 1)
                                        {
                                            estadoRepartidor = "Disponible";
                                            break;
                                        }
                                        else if (estadoRepartidorIn == 2)
                                        {
                                            estadoRepartidor = "Asignado";
                                            break;
                                        }
                                        else
                                        {
                                            estadoRepartidor = "Fuera de servicio";
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                    int confirmacionRepartidor = ValidacionEntradas($"Resumen de datos: \n \nNombre: {repartidorNombre}\nNúmero: {numeroRepartidor}\nNúmero de licencia: {numeroLicencia}\nTipo de licencia: {tipoLicencia}\nEstado: {estadoRepartidor}\n\nConfirmar registro de REP-{contadorRepartidores}\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Opción no valida");
                                    if(confirmacionRepartidor == 1)
                                    {
                                        Console.Clear();
                                        Repartidores.Add(new Repartidor(contadorRepartidores, repartidorNombre, numeroRepartidor, numeroLicencia, tipoLicencia, estadoRepartidor, 0, 0));
                                        MostrarAnimacionPuntos();
                                    }
                                    else
                                    {
                                        MostrarErrorAnimado("Operación cancelada.");
                                        break;
                                    }
                                    break;
                                case 2:
                                    Console.Clear();
                                    if (Repartidores.Count == 0)
                                    {
                                        Console.Clear();
                                        MostrarErrorAnimado("No hay repartidores registrados.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Repartidores registrados: ");
                                        Console.WriteLine();
                                        foreach (Repartidor repartidorSin in Repartidores)
                                        {
                                            repartidorSin.MostrarInformacion();
                                            Console.WriteLine();
                                        }
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    if (Repartidores.Count == 0)
                                    {
                                        Console.Clear();
                                        MostrarErrorAnimado("No hay repartidores registrados.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Actualizar disponibilidad de un repartidor");
                                        Console.WriteLine();

                                        int codigoRepartidor = ValidacionEntradas("Ingrese codigo de repartidor: ", 1, int.MaxValue, "Repartidor no encontrado ");

                                        int indiceRep = -1;
                                        for (int i = 0; i < Repartidores.Count; i++)
                                        {
                                            if (Repartidores[i].Codigo == codigoRepartidor)
                                            {
                                                indiceRep = i;
                                                break;
                                            }
                                        }
                                        if (indiceRep != -1)
                                        {
                                            while (true)
                                            {
                                                int estadoRepartidorNuevo = ValidacionEntradas($"Repartidor encontrado: \n\nNombre: {Repartidores[indiceRep].NombreCompleto}\nEstado actual: {Repartidores[indiceRep].Disponibilidad}\n\n Seleccione nuevo estado: \n1. Disponible\n2. Asignado\n3. Fuera de servicio\nIngrese opción: ", 1, 3, "Error: Estado no valido");
                                                if (estadoRepartidorNuevo == 1)
                                                {
                                                    if (Repartidores[indiceRep].Disponibilidad == "Disponible")
                                                    {
                                                        MostrarErrorAnimado("Erorr: No puede asignarse el mismo estado!");
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
                                                        MostrarErrorAnimado("Erorr: No puede asignarse el mismo estado!");
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
                                                        MostrarErrorAnimado("Erorr: No puede asignarse el mismo estado!");
                                                    }
                                                    else
                                                    {
                                                        Repartidores[indiceRep].actualizarDisponibilidad("Fuera de servicio");
                                                        break;
                                                    }
                                                }
                                            }
                                            Console.Clear();
                                            MostrarExitoAnimado("Estado actualizado correctamente");
                                            Console.ReadKey();
                                            break;

                                        }
                                        else
                                        {
                                            MostrarErrorAnimado("Error: Repartidor no encontrado");
                                        }
                                        Console.ReadKey();
                                    }
                                    break;
                                case 4:
                                    break;
                            }
                        } while (opcionRepartidor != 4);
                        break;
                    case 3:
                        int opcionVehiculo;
                        do
                        {
                            Console.Clear();
                            opcionVehiculo = ValidacionEntradas("VEHICULOS\n\n1. Registrar vehiculo\n2. Consultar Vehiculo\n3. Volver al menu principal \n\nEliga una opción: ", 1, 3, "Error: Opción no valida");
                            switch (opcionVehiculo)
                            {
                                case 1:
                                    int tipoVehiculo;
                                    do
                                    {
                                        Console.Clear();
                                        tipoVehiculo = ValidacionEntradas("Tipo de vehiculo: \n\n1. Automovil\n2. Motocicleta\n3. Bicicleta\n4. Volver\n\nEliga una opción: ", 1, 4, "Error: Opción no valida");
                                        switch (tipoVehiculo)
                                        {
                                            case 1:
                                                Console.Clear();
                                                int codigoAuto = Automoviles.Count + 1;
                                                Console.Write("Ingrese placa: ");
                                                string placaAutomovil = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese marca: ");
                                                string marca = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese modelo: ");
                                                string modelo = Console.ReadLine();
                                                double capacidadMaxima = 250.00;
                                                Console.Clear();
                                                string estadoAutomovil;
                                                while (true)
                                                {
                                                    int opcionAutomovil = ValidacionEntradas("Seleccione estado: \n1. Disponible\n2. Asignado\n3. En mantenimiento\n\nSeleccione una opción: ", 1, 3, "Error: Opción invalida");
                                                    if (opcionAutomovil == 1)
                                                    {
                                                        estadoAutomovil = "Disponible";
                                                        break;
                                                    }
                                                    else if (opcionAutomovil == 1)
                                                    {
                                                        estadoAutomovil = "Asignado";
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        estadoAutomovil = "En mantenimiento";
                                                        break;
                                                    }
                                                }
                                                double costoOperativo = 35.00;
                                                int confirmacionAutomovil = ValidacionEntradas($"Resumen de datos: \n\nPlaca: {placaAutomovil}\nMarca: {marca}\nModelo: {modelo}\nCapacidad maxima: {capacidadMaxima}\nEstado: {estadoAutomovil}\n\nConfirmar registro de AUTO-{codigoAuto}\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                if(confirmacionAutomovil == 1)
                                                {
                                                    Console.Clear();
                                                    Automoviles.Add(new Automovil(codigoAuto, marca, modelo, capacidadMaxima, estadoAutomovil, costoOperativo, placaAutomovil));
                                                    MostrarAnimacionPuntos();

                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    MostrarErrorAnimado("Operación cancelada.");
                                                    break;
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                int codigoMoticicleta = Motocicletas.Count + 1;
                                                Console.Write("Ingrese placa: ");
                                                string placaMoto = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese marca: ");
                                                string marcaMoto = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese modelo: ");
                                                string modeloMoto = Console.ReadLine();
                                                double capacidadMaximaMoto = 30.00;
                                                Console.Clear();
                                                string estadoMotocicleta;
                                                while (true)
                                                {
                                                    int opcionMoticicleta = ValidacionEntradas("Seleccione estado: \n1. Disponible\n2. Asignado\n3. En mantenimiento\n >", 1, 3, "Opción invalida");
                                                    if (opcionMoticicleta == 1)
                                                    {
                                                        estadoMotocicleta = "Disponible";
                                                        break;
                                                    }
                                                    else if (opcionMoticicleta == 1)
                                                    {
                                                        estadoMotocicleta = "Asignado";
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        estadoMotocicleta = "En mantenimiento";
                                                        break;
                                                    }
                                                }
                                                double costoOperativoMoto = 15.00;
                                                Console.Clear();
                                                int confirmacionMotocicleta = ValidacionEntradas($"Resumen de datos: \n\nPlaca: {placaMoto}\nMarca: {marcaMoto}\nModelo: {modeloMoto}\nCapacidad maxima: {capacidadMaximaMoto}\nEstado: {estadoMotocicleta}\nCosto operativo: {costoOperativoMoto}\n\n¿Esta seguro que desea registrar MOT-{codigoMoticicleta}?\n1. Sí. \n2. No.\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                if (confirmacionMotocicleta == 1)
                                                {
                                                    Console.Clear();
                                                    Motocicletas.Add(new Moticicleta(codigoMoticicleta, marcaMoto, modeloMoto, capacidadMaximaMoto, estadoMotocicleta, costoOperativoMoto, placaMoto));
                                                    MostrarAnimacionPuntos();
                                                }
                                                else
                                                {
                                                    MostrarErrorAnimado("Operación cancelada.");
                                                    break;
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                int codigoBicicleta = Bicicletas.Count + 1;
                                                Console.Write("Ingrese marca: ");
                                                string marcaBicicleta = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese modelo: ");
                                                string modeloBicleta = Console.ReadLine();
                                                Console.Clear();
                                                double capacidadMaximaBici = 10.00;
                                                string estadoBicicleta;
                                                while (true)
                                                {
                                                    int opcionBicicleta = ValidacionEntradas("Seleccione estado: \n1. Disponible\n2. Asignado\n3. En mantenimiento\n >", 1, 3, "Opción invalida");
                                                    if (opcionBicicleta == 1)
                                                    {
                                                        estadoBicicleta = "Disponible";
                                                        break;
                                                    }
                                                    else if (opcionBicicleta == 1)
                                                    {
                                                        estadoBicicleta = "Asignado";
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        estadoBicicleta = "En mantenimiento";
                                                        break;
                                                    }
                                                }
                                                double costoOperativoBicicleta = 15.00;
                                                Console.Clear();
                                                Console.WriteLine($"Costo operativo: {costoOperativoBicicleta}");
                                                int confirmacionBicicleta = ValidacionEntradas($"Resumen de datos: \n\n\nMarca: {marcaBicicleta}\nModelo: {modeloBicleta}\nCapacidad máxima: {capacidadMaximaBici}\nEstado: {estadoBicicleta}\nCosto operativo: {costoOperativoBicicleta}\n\nConfirmar registro de BICI-{codigoBicicleta}\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                if(confirmacionBicicleta == 1)
                                                {
                                                    Console.Clear();
                                                    Bicicletas.Add(new Bicicleta(codigoBicicleta, marcaBicicleta, modeloBicleta, capacidadMaximaBici, estadoBicicleta, costoOperativoBicicleta));
                                                    MostrarAnimacionPuntos();
                                                }
                                                else
                                                {
                                                    MostrarErrorAnimado("Operación cancelada.");
                                                    break;
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 4:
                                                break;
                                        }
                                    } while (tipoVehiculo != 4);
                                    break;
                                case 2:

                                    int opcionConsultaVehiculo;
                                    do
                                    {
                                        Console.Clear();
                                        opcionConsultaVehiculo = ValidacionEntradas("Consultar Vehiculos\n \n1. Automoviles\n2. Motocicletas\n3. Bicicletas\n4. Volver atras\n\nIngrese una opción: ", 1, 4, "Error: Opción no valida");
                                        switch (opcionConsultaVehiculo)
                                        {
                                            case 1:
                                                Console.Clear();
                                                if (Automoviles.Count == 0)
                                                {
                                                    MostrarErrorAnimado("Error: No hay automoviles registrados");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Automoviles:");
                                                    Console.WriteLine();
                                                    foreach (Automovil automovil in Automoviles)
                                                    {
                                                        automovil.MostrarInformacion();
                                                        Console.WriteLine();
                                                    }
                                                }

                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                if (Motocicletas.Count == 0)
                                                {
                                                    MostrarErrorAnimado("Error: No hay motocicletas registradas");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Motocicletas: ");
                                                    Console.WriteLine();
                                                    foreach (Moticicleta motocicleta in Motocicletas)
                                                    {
                                                        motocicleta.MostrarInformacion();
                                                        Console.WriteLine();
                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                if (Bicicletas.Count == 0)
                                                {
                                                    MostrarErrorAnimado("Error: No hay bicicletas registradas");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Bicicletas: ");
                                                    Console.WriteLine();
                                                    foreach (Bicicleta bicicleta in Bicicletas)
                                                    {
                                                        bicicleta.MostrarInformacion();
                                                        Console.WriteLine();
                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 4:
                                                break;
                                        }
                                    } while (opcionConsultaVehiculo != 4);
                                    break;
                                case 3:
                                    break;
                            }
                        } while (opcionVehiculo != 3);
                        break;
                    case 4:
                        Console.Clear();
                        int opcionPaquete;
                        do
                        {
                            Console.Clear();
                            opcionPaquete = ValidacionEntradas("PAQUETES\n\n1. Registrar nuevo paquete\n2. Actualizar estado\n3. Calcular tarifa\n4. Mostrar información\n5. Volver al menu principal\n\nIngrese una opción: ", 1, 5, "Opción no valida");
                            switch (opcionPaquete)
                            {
                                case 1:
                                    int tipoPaquete;
                                    do
                                    {
                                        Console.Clear();
                                        tipoPaquete = ValidacionEntradas("Tipo de paquete:\n\n1. Documento\n2. Estandar\n3. Fragil\n3. Documento\n4. Refrigerado\n5. Volver atras\n\nIngrese una opción: ", 1, 5, "Error: Opción no valida");
                                        switch (tipoPaquete)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    int codigoDocumento = Documentos.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    Console.Clear();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 2, "Eror: Peso permitido para documentos: 1kg a 2kg");
                                                    Console.Clear();
                                                    double valorDeclarado = ValidacionEntradasDouble("Ingrese valor declarado: ", 1, 10000, "Erro: Valor fuera del rango permitido");
                                                    Console.Clear();
                                                    Console.Write("Ingrese dirección de origen: ");
                                                    string direccionOrigen = Console.ReadLine();
                                                    Console.Clear();
                                                    Console.Write("Ingrese dirección de destino: ");
                                                    string direccionDestino = Console.ReadLine();
                                                    Console.Clear();
                                                    string estadoPaquete;
                                                    while (true)
                                                    {
                                                        int opcionEstado = ValidacionEntradas("Seleccione estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n\nIngrese una opción: ", 1, 4, "Opción invalida");
                                                        if (opcionEstado == 1)
                                                        {
                                                            estadoPaquete = "Pendiente";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 2)
                                                        {
                                                            estadoPaquete = "En tránsito";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 3)
                                                        {
                                                            estadoPaquete = "Entregado";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            estadoPaquete = "Cancelado";
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    int confirmacionDoc = ValidacionEntradas($"Resumen de datos: \n\nDescripción: {descripcionPaquete}\nPeso: {pesoPaquete} kg\nValor declarado: ${valorDeclarado}\nDirección de origen: {direccionOrigen}\nDirección de destino: {direccionDestino}\nEstado: {estadoPaquete}\n\n¿Esta seguro que desea agregar PAQD-{codigoDocumento}?\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                    if(confirmacionDoc == 1)
                                                    {
                                                        Console.Clear();
                                                        Documentos.Add(new Documento(codigoDocumento, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                        MostrarAnimacionPuntos();
                                                    }
                                                    else
                                                    {
                                                        MostrarErrorAnimado("Operación cancelada.");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    int codigoPaqueteEstandar = PaquetesEstandar.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    Console.Clear();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 50, "Eror: peso permitido para paquetes estandar 1kg a 50kg");
                                                    Console.Clear();
                                                    double valorDeclarado = ValidacionEntradasDouble("Ingrese valor declarado: ", 1, 10000, "Erro: Valor fuera del rango permitido");
                                                    Console.Clear();
                                                    Console.Write("Ingrese dirección de origen: ");
                                                    string direccionOrigen = Console.ReadLine();
                                                    Console.Clear();
                                                    Console.Write("Ingrese dirección de destino: ");
                                                    string direccionDestino = Console.ReadLine();
                                                    Console.Clear();
                                                    string estadoPaquete;
                                                    while (true)
                                                    {
                                                        int opcionEstado = ValidacionEntradas("Seleccione estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                        if (opcionEstado == 1)
                                                        {
                                                            estadoPaquete = "Pendiente";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 2)
                                                        {
                                                            estadoPaquete = "En tránsito";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 3)
                                                        {
                                                            estadoPaquete = "Entregado";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            estadoPaquete = "Cancelado";
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    int confirmacionEstandar = ValidacionEntradas($"Resumen de datos: \n\nDescripción: {descripcionPaquete}\nPeso: {pesoPaquete}kg\nValor declarado: ${valorDeclarado}\nDirección de origen: {direccionOrigen}\nDirección de destino: {direccionDestino}\nEstado: {estadoPaquete}\n\n¿Esta seguro que desea registrar PAQE-{codigoPaqueteEstandar}?\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                    if(confirmacionEstandar == 1)
                                                    {
                                                        Console.Clear();
                                                        PaquetesEstandar.Add(new PaqueteEstandar(codigoPaqueteEstandar, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                        MostrarAnimacionPuntos();
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        MostrarErrorAnimado("Operación cancelada.");
                                                        break;

                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                {
                                                    Console.Clear();
                                                    int codigoPaqueteFragil = PaquetesFragiles.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    Console.Clear();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 20, "Error: peso permitido para paquetes fragiles 1kg a 20kg");
                                                    Console.Clear();
                                                    double valorDeclarado = ValidacionEntradasDouble("Ingrese valor declarado: ", 1, 10000, "Valor fuera del rango permitido");
                                                    Console.Clear();
                                                    Console.Write("Ingrese dirección de origen: ");
                                                    string direccionOrigen = Console.ReadLine();
                                                    Console.Clear();
                                                    Console.Write("Ingrese dirección de destino: ");
                                                    string direccionDestino = Console.ReadLine();
                                                    Console.Clear();
                                                    string estadoPaquete;
                                                    while (true)
                                                    {
                                                        int opcionEstado = ValidacionEntradas("Seleccione estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                        if (opcionEstado == 1)
                                                        {
                                                            estadoPaquete = "Pendiente";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 2)
                                                        {
                                                            estadoPaquete = "En tránsito";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 3)
                                                        {
                                                            estadoPaquete = "Entregado";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            estadoPaquete = "Cancelado";
                                                            break;
                                                        }
                                                    }

                                                    Console.Clear();
                                                    int confirmacioonFragil = ValidacionEntradas($"Resumen de datos: \n\nDescripción: {descripcionPaquete}\nPeso: {pesoPaquete}kg\nValor declarado: ${valorDeclarado}\nDirección de origen: {direccionOrigen}\nDirección de destino: {direccionDestino}\nEstado: {estadoPaquete}\n\n¿Esta seguro de registrar PAQF-{codigoPaqueteFragil}?\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Erro: Opción no valida");
                                                    if (confirmacioonFragil == 1)
                                                    {
                                                        Console.Clear();
                                                        PaquetesFragiles.Add(new PaqueteFragil(codigoPaqueteFragil, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                        MostrarAnimacionPuntos();
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        MostrarErrorAnimado("Operación cancelada.");
                                                        break;
                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 4:
                                                {
                                                    Console.Clear();
                                                    int codigoProductoRefrigerado = ProductosRefrigerados.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 15, "Eror: peso permitido para productos refigerados 1kg a 15kg");
                                                    double valorDeclarado = ValidacionEntradasDouble("Ingrese valor declarado: ", 1, 10000, "Valor fuera del rango permitido");
                                                    Console.Write("Ingrese dirección de origen: ");
                                                    string direccionOrigen = Console.ReadLine();
                                                    Console.Write("Ingrese dirección de destino: ");
                                                    string direccionDestino = Console.ReadLine();
                                                    string estadoPaquete;
                                                    while (true)
                                                    {
                                                        int opcionEstado = ValidacionEntradas("Seleccione estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                        if (opcionEstado == 1)
                                                        {
                                                            estadoPaquete = "Pendiente";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 2)
                                                        {
                                                            estadoPaquete = "En tránsito";
                                                            break;
                                                        }
                                                        else if (opcionEstado == 3)
                                                        {
                                                            estadoPaquete = "Entregado";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            estadoPaquete = "Cancelado";
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();

                                                    int confirmacionRefrigerado = ValidacionEntradas($"Resumen de datos: \n\nDescripción: {descripcionPaquete}\nPeso: {pesoPaquete}\nValor declarado: {valorDeclarado}\nDirección de origen: {direccionOrigen}\nDirección de destino: {direccionDestino}\nEstado: {estadoPaquete}\n\n¿Esta seguro de registrar PAQR-{codigoProductoRefrigerado}?\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                    if (confirmacionRefrigerado == 1)
                                                    {
                                                        Console.Clear();
                                                        ProductosRefrigerados.Add(new ProductoRefrigerado(codigoProductoRefrigerado, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));

                                                        MostrarAnimacionPuntos();
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        MostrarErrorAnimado("Operación cancelada.");
                                                        break;
                                                    }
                                                }
                                                
                                                break;
                                            case 5:
                                                break;
                                        }

                                    } while (tipoPaquete != 5);

                                    break;
                                case 2:

                                    Console.Clear();

                                    int opcionEstadoPaquete;
                                    do
                                    {
                                        Console.Clear();
                                        opcionEstadoPaquete = ValidacionEntradas("Actualizar estado de paquete\n\n1. Documento\n2. Estandar\n3. Fragil\n4. Refrigerado\n5. Volver atras\nIngrese una opción: ", 1, 5, "Error: Opción no valida");
                                        switch (opcionEstadoPaquete)
                                        {
                                            case 1:
                                                CambiarEstadoPaquete(Documentos, "PAQD-");
                                                break;
                                            case 2:
                                                CambiarEstadoPaquete(PaquetesEstandar, "PAQE-");
                                                break;
                                            case 3:
                                                CambiarEstadoPaquete(PaquetesFragiles, "PAQF-");
                                                break;
                                            case 4:
                                                CambiarEstadoPaquete(ProductosRefrigerados, "PAQR-");
                                                break;
                                            case 5:
                                                break;
                                        }
                                    } while (opcionEstadoPaquete != 5);

                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Calculo de tarifa");
                                    Console.WriteLine();

                                    break;
                                case 4:
                                    Console.Clear();
                                    int opcionMostrar;
                                    do
                                    {
                                        Console.Clear();
                                        opcionMostrar = ValidacionEntradas("Mostrar información\n\nSeleccione tipo de paquete: \n1. Documento\n2. Estandar\n3. Fragil\n4. Refrigerado\n5. Volver atras\n\nIngrese una opción: ", 1, 5, "Error: Opción no valida");
                                        switch (opcionMostrar)
                                        {
                                            case 1:
                                                Console.Clear();
                                                if (Documentos.Count == 0)
                                                {
                                                    MostrarErrorAnimado("Error: No hay documentos registrados");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Documentos: ");
                                                    Console.WriteLine();
                                                    foreach (Documento documento in Documentos)
                                                    {
                                                        documento.MostrarInformacion();
                                                        Console.WriteLine();

                                                    }

                                                }
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                if (PaquetesEstandar.Count == 0)
                                                {
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Paquetes estandar: ");
                                                    Console.WriteLine();
                                                    foreach (PaqueteEstandar paqueteEstandar in PaquetesEstandar)
                                                    {
                                                        paqueteEstandar.MostrarInformacion();
                                                        Console.WriteLine();
                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                if (PaquetesFragiles.Count == 0)
                                                {
                                                    MostrarErrorAnimado("Error: No hay paquetes fragiles registrados");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Paquetes fragiles: ");
                                                    Console.WriteLine();
                                                    foreach (PaqueteFragil paqueteFragil in PaquetesFragiles)
                                                    {
                                                        paqueteFragil.MostrarInformacion();
                                                        Console.WriteLine();
                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 4:
                                                Console.Clear();
                                                if (ProductosRefrigerados.Count == 0)
                                                {
                                                    MostrarErrorAnimado("Error: No hay productos refrigerados registrados");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Productos refrigerados: ");
                                                    Console.WriteLine();
                                                    foreach (ProductoRefrigerado productoRefrigerado in ProductosRefrigerados)
                                                    {
                                                        productoRefrigerado.MostrarInformacion();
                                                        Console.WriteLine();
                                                    }
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 5:
                                                break;
                                        }
                                    } while (opcionMostrar != 5);
                                    break;
                                case 5:
                                    break;
                            }
                        } while (opcionPaquete != 5);

                        break;
                    case 5:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        int opcionMenuIncidencia;
                        do
                        {
                            Console.Clear();    
                            opcionMenuIncidencia = ValidacionEntradas("Gestión de incidencias\n\n1. Registrar incidencia\n2. Mostrar información de incidencias\n3. Volver al menu principal\n\nIngrese una opción: ", 1, 3, "Error: Opción no valida");
                            switch (opcionMenuIncidencia)
                            {
                                case 1:
                                    int codigoPaqueteIncidencia = IncidenciasList.Count + 1;
                                    int codigoEntregaBuscar = ValidacionEntradas("Ingrese codigo de paquete: PAQ-", 1, int.MaxValue, "Codigo no encontrado");
                                    int indiceEntrega = -1;
                                    for (int i = 0; i < Entregass.Count; i++)
                                    {
                                        if (codigoEntregaBuscar == Entregass[i].Codigo)
                                        {
                                            indiceEntrega = i;
                                            break;
                                        }
                                    }
                                    if (indiceEntrega == -1)
                                    {
                                        MostrarErrorAnimado("Paquete no encontrado");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        string tipoIndicenaciaString;
                                        int tipoIncidencia = ValidacionEntradas("Seleccione tipo de incidencia: \n1. Retraso\n2. Perdido\n3. Dañado\n4. Cancelado\n5. Volver atras\n\n Ingrese una opción: ", 1, 5, "Error: Opción no valida");
                                        if (tipoIncidencia == 1)
                                        {
                                            tipoIndicenaciaString = "Retraso";
                                        }
                                        else if (tipoIncidencia == 2)
                                        {
                                            tipoIndicenaciaString = "Perdido";
                                        }
                                        else if (tipoIncidencia == 3)
                                        {
                                            tipoIndicenaciaString = "Dañado";
                                        }
                                        else if (tipoIncidencia == 4)
                                        {
                                            tipoIndicenaciaString = "Cancelado";
                                        }
                                        else
                                        {
                                            tipoIndicenaciaString = "";
                                        }
                                        Console.Clear();
                                        Console.Write("Ingrese descripción: ");
                                        string descripcion = Console.ReadLine();
                                        string estadoIncidencia;
                                        Console.Clear();
                                        int estadoIncidenciaOpcion = ValidacionEntradas("Seleccione estado de incidencia: \n1. Pendiente\n2. En proceso\n3. Resuelto\n\nIngrese una opción: ", 1, 3, "Error: Opción no valida");
                                        if (estadoIncidenciaOpcion == 1)
                                        {
                                            estadoIncidencia = "Pendiente";

                                        }
                                        else if (estadoIncidenciaOpcion == 2)
                                        {
                                            estadoIncidencia = "En proceso";
                                        }
                                        else
                                        {
                                            estadoIncidencia = "Resuelto";
                                        }
                                        Console.Clear();

                                        Console.Write("Acción tomada: ");
                                        string accionTomada = Console.ReadLine();
                                        int confirmacionIncidencia = ValidacionEntradas($"Resumen de datos: \n\nCódigo del paquete: {codigoPaqueteIncidencia}\nTipo de incidencia: {tipoIndicenaciaString}\nDescripción: {descripcion}\nEstado: {estadoIncidencia}\nAcción tomada: {accionTomada}\n\n¿Desea registrar esta incidencia? \n1. Sí, \n2. No: ", 1, 2, "Error: Opción no valida");
                                        if(confirmacionIncidencia == 1)
                                        {
                                            Console.Clear();
                                            Incidencias nuevaIncidencia = new Incidencias(codigoPaqueteIncidencia, tipoIndicenaciaString, descripcion, DateTime.Now, estadoIncidencia, accionTomada);
                                            IncidenciasList.Add(nuevaIncidencia);

                                            Entregass[indiceEntrega].AgregarNuevaIncidencia(nuevaIncidencia);
                                            MostrarAnimacionPuntos();
                                        }
                                        else
                                        {
                                            MostrarErrorAnimado("Operación calcelada");
                                            break;
                                        }
                                        
                                    }
                                    break;
                                case 2:
                                    if(IncidenciasList.Count == 0)
                                    {
                                        MostrarErrorAnimado("Sin incidencias registradas.");
                                        Console.ReadKey();
                                        
                                    }
                                    else
                                    {
                                        foreach (Incidencias incidencia in IncidenciasList)
                                        {
                                            incidencia.MostrarInformacion();
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                                case 3:
                                    break;
                            }
                        } while (opcionMenuIncidencia != 3);
                        break;
                    case 7:
                        Console.Clear();
                        int opcionReportes;
                        do
                        {
                            Console.Clear();
                            opcionReportes = ValidacionEntradas("1.Entregas activas.\r\n2. Entregas finalizadas.\r\n3. Entregas canceladas.\r\n4. Entregas con incidencias.\r\n5. Repartidores disponibles.\r\n6. Repartidor con más entregas.\r\n7. Vehículo más utilizado.\r\n8. Cantidad de paquetes por tipo.\r\n9. Total de ingresos.\r\n10.Entrega con mayor costo\n11. Volver al menu pricipal\nEliga una opción: ",1,11,"Opción invalida");
                            switch (opcionReportes)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Entregas activas");
                                    Console.WriteLine();
                                    
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Entregas finalizadas");
                                    Console.WriteLine();
                                    Console.ReadKey();

                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Entregas canceladas");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Entregas con incidencias");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.Clear();
                                   
                                    if(Repartidores.Count == 0)
                                    {
                                        Console.WriteLine("Sin repartidores registrados aun");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Repartidores disponibles");
                                        int contadorRepartidoresActivos = 0;
                                        for (int i = 0; i < Repartidores.Count; i++)
                                        {
                                            if (Repartidores[i].Disponibilidad == "Disponible")
                                            {
                                                contadorRepartidoresActivos += 1;
                                            }
                                        }

                                        Console.WriteLine($"Disponibilidad: {contadorRepartidoresActivos}");
                                    }
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("Repartidores con mas entregas");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                    break;
                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("Vehiculo más utilizado");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                    break;
                                case 8:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de paquetes por tipo");
                                    Console.WriteLine();

                                    Console.ReadKey();
                                    break;
                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("Total de ingresos");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                    break;
                                case 10:
                                    Console.Clear();
                                    Console.WriteLine("Entrega con mayor costo");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                    break;
                                case 11:
                                    break;
                            }
                        } while(opcionReportes != 11);

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
        static void CambiarEstadoPaquete<T>(List<T> listaPaquetes, string tipoPaquete) where T : Paquete
        {
            Console.Clear();
            int codigoBuscar = ValidacionEntradas($"Ingrese codigo de paquete: {tipoPaquete}", 1, int.MaxValue, "Codigo no encontrado");

            int indicePaquete = -1;
            for(int i = 0; i < listaPaquetes.Count; i++)
            {
                if (listaPaquetes[i].Codigo == codigoBuscar)
                {
                    indicePaquete = i;
                    break;
                }
            }
            if(indicePaquete == -1)
            {
                Console.Clear();
                Console.WriteLine("Codigo no encontrado");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Paquete encontrado");
            Console.WriteLine();
            Console.WriteLine("Estado actual: " + listaPaquetes[indicePaquete].Estado);

            string[] estados = { "Pendiente", "En Transito", "Entregado", "Cancelado" };
            while (true)
            {
                int opcion = ValidacionEntradas("Seleccione un nuevo estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\nIngrese una opción: ", 1, 4, "Error: Opción invalida");
                string estadoElegido = estados[opcion - 1];
                if (listaPaquetes[indicePaquete].Estado == estadoElegido)
                {
                    Console.Clear();
                    MostrarErrorAnimado("Erorr: No se puede asignar el mismo estado.");
                }
                else
                {
                    Console.Clear();
                    listaPaquetes[indicePaquete].ActualizarEstado(estadoElegido);
                    Console.WriteLine("Estado cambiado exitosamente!");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static double ValidacionEntradasDouble(string mensaje, int min, int max, string errorMensaje)
        {
            double valor;
            bool esValido;
            do
            {
                Console.Clear();
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = double.TryParse(entrada, out valor);
                if (!esValido)
                {
                    Console.Clear();
                    MostrarErrorAnimado("Error: Por favor ingrese un número");
                    Console.WriteLine(mensaje);

                }
                else if (valor < min || valor > max)
                {
                    Console.Clear();
                    MostrarErrorAnimado(errorMensaje);
                    Console.WriteLine(mensaje);
                    esValido = false;
                }

            } while (!esValido);
            return valor;
        }
        static int ValidacionEntradas(string mensaje, int min, int max, string errorMensaje)
        {
            int valor;
            bool esValido;
            do
            {
                Console.Clear();
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out valor);

                if (!esValido)
                {
                    Console.Clear();
                    MostrarErrorAnimado("ERROR: Por favor ingrese un número válido.");
                    Console.WriteLine(mensaje);

                }
                else if (valor < min || valor > max)
                {
                    Console.Clear();
                    MostrarErrorAnimado($"► ERROR: {errorMensaje}");
                    Console.WriteLine(mensaje);
                    esValido = false;
                }

            } while (!esValido);
            return valor;
        }

        static void MostrarErrorAnimado(string textoError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(textoError);
            Thread.Sleep(1400);
            Console.Write("\r" + new string(' ', textoError.Length) + "\r");
            Console.ResetColor();
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
            if (telefono.Length != 8)
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
        static void MostrarExitoAnimado(string mensajeExito)
        {
            Console.ForegroundColor = ConsoleColor.Green;

      

            Console.Write($" {mensajeExito}");

            Thread.Sleep(2000);

            Console.Write("\r" + new string(' ', mensajeExito.Length + 5) + "\r");

            Console.ResetColor();
        }
        static void MostrarAnimacionPuntos()
        {
            Console.Write("Procesando y guardando datos");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(400); 
            }
            Console.Clear();
            MostrarExitoAnimado("Registro completado con éxito!");
        }
    }
}

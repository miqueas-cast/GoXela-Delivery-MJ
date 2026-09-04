using System;
using System.CodeDom;
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

        public int CantidadEntreas
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
            CantidadEntreas = cantidadEntregas;
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
            Console.WriteLine($"Cantidad entregas: {CalificacionEntregas}");
            Console.WriteLine($"Calificación entregas: {CalificacionEntregas}");
        }
        public void actualizarDisponibilidad(string nuevoEstado)
        {
            Disponibilidad = nuevoEstado;
        }
        public void ActualizarEntregas(int nuevasEntregas)
        {
            CantidadEntreas += nuevasEntregas;
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
            Console.WriteLine($"Código: AUT-{Codigo}");
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Capacidad máxima de carga: {CapacidadMaximaCarga}.kg");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Costo operativo: Q.{CostoOperativo}");
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
            Console.WriteLine($"Código: MOT-{Codigo}");
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Capacidad máxima de carga: {CapacidadMaximaCarga} kg");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Costo operativo: Q.{CostoOperativo}");
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
            Console.WriteLine($"Código: BIC-{Codigo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Capacidad máxima de carga: {CapacidadMaximaCarga} kg");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Costo operativo: Q.{CostoOperativo}");
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
            Console.WriteLine($"Código: PAQ-{Codigo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Peso: {Peso} kg");
            Console.WriteLine($"Valor declarado: Q.{ValorDeclarado}");
            Console.WriteLine($"Dirección de origen: {DireccionOrigen}");
            Console.WriteLine($"Dirección de destino: {DireccionDestino}");
            Console.WriteLine($"Estado: {Estado}");
        }
        public void ActualizarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }
        public virtual void CalcularCostoEnvio()
        {
            // Implementación del cálculo de costo de envío para paquetes estándar
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
            List<Moticicleta> Motocicletas = new List<Moticicleta>();
            List<Bicicleta> Bicicletas = new List<Bicicleta>();
            List<Paquete> Paquetes = new List<Paquete>();
            List<Documento> Documentos = new List<Documento>();
            List<PaqueteEstandar> PaquetesEstandar = new List<PaqueteEstandar>();
            List<PaqueteFragil> PaquetesFragiles = new List<PaqueteFragil>();
            List<ProductoRefrigerado> ProductosRefrigerados = new List<ProductoRefrigerado>();
            List<Entrega> Entregas = new List<Entrega>();

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("========================================\r\n GOXELA DELIVERY\r\n========================================\r\n1. Gestión de clientes\r\n2. Gestión de repartidores\r\n3. Gestión de vehículos\r\n4. Gestión de paquetes\r\n5. Gestión de entregas\r\n6. Gestión de incidencias\r\n7. Reportes\r\n8. Salir");
                opcion = ValidacionEntradas("Ingrese una opción: ", 1, 8, "Opción fuera del rango");
                switch (opcion)
                {
                    case 1:
                        int opcionCliente;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1. Registrar\n2. Consultar\n3. Actualizar\n4. Mostrar Información\n5. Volver al menu principal");
                            opcionCliente = ValidacionEntradas("Ingrese una opción: ", 1, 5, "Opción fuera del rango");
                            switch (opcionCliente)
                            {
                                case 1:
                                    Console.Clear();
                                    int contadorCodigo = Clientes.Count + 1;

                                    Console.Write("Ingrese nombre cliente: ");
                                    string nombre = Console.ReadLine();
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
                                            Console.WriteLine("Número de teléfono inválido. Debe tener 8 dígitos y solo contener números.");
                                        }
                                    }
                                    string correoCliente;
                                    while (true)
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


                                    int cantidadSolicitudes = ValidacionEntradas("Ingrese cantidad de solicitudes: ", 1, 100, "Cantidad de solicitudes no permitida");

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
                            opcionRepartidor = ValidacionEntradas("Ingrese una opción: ", 1, 5, "Opción fuera del rango");
                            switch (opcionRepartidor)
                            {
                                case 1:
                                    Console.Clear();
                                    int contadorRepartidores = Repartidores.Count + 1;
                                    Console.Write("Ingrese nombre repartidor: ");
                                    string repartidorNombre = Console.ReadLine();
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
                                            Console.WriteLine("Número de teléfono inválido. Debe tener 8 dígitos y solo contener números.");
                                        }
                                    }
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
                                            Console.WriteLine("Numero de licencia invaldia");
                                        }
                                    }
                                    string tipoLicencia;
                                    while (true)
                                    {
                                        int tipoLicenciaa = ValidacionEntradas("Seleccióne tipo de licencia: \n1. C\n2. B\n3. A\n4. M\n5. E\n", 1, 5, "Opción invalida");
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
                                    string estadoRepartidor;
                                    while (true)
                                    {
                                        int estadoRepartidorIn = ValidacionEntradas("Estado: \n1. Disponible\n2. Asignado\n3. Fuera de servicio\n>", 1, 3, "Estado no valido");
                                        if(estadoRepartidorIn == 1)
                                        {
                                            estadoRepartidor = "Disponible";
                                            break;
                                        }
                                        else if(estadoRepartidorIn == 2)
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
                                    int cantidadEntregas = ValidacionEntradas("Ingrese cantidad de entregas: ", 1, 500, "Cantidad de entregas no valida");
                                    int calificacion = ValidacionEntradas("Ingrese promedio: ", 1, 5, "Promedio no valido");
                                    Repartidores.Add(new Repartidor(contadorRepartidores, repartidorNombre, numeroRepartidor, numeroLicencia, tipoLicencia, estadoRepartidor, cantidadEntregas, calificacion));
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Actualizar disponibilidad de un repartidor");
                                    Console.WriteLine();
                                    Console.Write("Ingrese nombre de repartidor: ");
                                    string repartidor = Console.ReadLine();
                                    int indiceRep = -1;
                                    for (int i = 0; i < Repartidores.Count; i++)
                                    {
                                        if (Repartidores[i].NombreCompleto == repartidor)
                                        {
                                            indiceRep = i;
                                            break;
                                        }
                                    }
                                    if (indiceRep != -1)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Repartidor encontrado");
                                        Console.WriteLine();
                                        Console.WriteLine($"Estado actual: {Repartidores[indiceRep].Disponibilidad}");
                                        Console.WriteLine();
                                        Console.WriteLine("Selecciona nuevo estado");
                                        while (true)
                                        {
                                            int estadoRepartidorNuevo = ValidacionEntradas("Estado: \n1. Disponible\n2. Asignado\n3. Fuera de servicio\n>", 1, 3, "Estado no valido");
                                            if (estadoRepartidorNuevo == 1)
                                            {
                                                if (Repartidores[indiceRep].Disponibilidad == "Disponible")
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
                                    Console.WriteLine("Actualizar entregas");
                                    Console.WriteLine();
                                    Console.WriteLine("Ingrese nombre: ");
                                    string nombreRep = Console.ReadLine();

                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    foreach (Repartidor repartidorSin in Repartidores)
                                    {
                                        repartidorSin.MostrarInformacion();
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    break;
                            }
                        } while (opcionRepartidor != 5);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Gestion de vehiculos");
                        Console.WriteLine();
                        int opcionVehiculo;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1. Registrar vehiculo\n2. Consultar Vehiculo\n3. Volver al menu principal");
                            opcionVehiculo = ValidacionEntradas("Eliga una opción: ", 1, 3, "Opción no valida");
                            switch (opcionVehiculo)
                            {
                                case 1:
                                    int tipoVehiculo;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1. Automovil\n2. Motocicleta\n3. Bicicleta\n4. Volver");
                                        tipoVehiculo = ValidacionEntradas("Eliga una opción: ", 1, 4, "Opción no valida");
                                        switch (tipoVehiculo)
                                        {
                                            case 1:
                                                Console.Clear();
                                                int codigoAuto = Automoviles.Count + 1;
                                                Console.Write("Ingrese placa: ");
                                                string placaAutomovil = Console.ReadLine();
                                                Console.Write("Ingrese marca: ");
                                                string marca = Console.ReadLine();
                                                Console.Write("Ingrese modelo: ");
                                                string modelo = Console.ReadLine();
                                                double capacidadMaxima = 250.00;
                                                string estadoAutomovil;
                                                while (true)
                                                {
                                                    int opcionAutomovil = ValidacionEntradas("Seleccione estado: \n1. Disponible\n2. Asignado\n3. En mantenimiento\n >", 1, 3, "Opción invalida");
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
                                                Automoviles.Add(new Automovil(codigoAuto, marca, modelo, capacidadMaxima, estadoAutomovil, costoOperativo, placaAutomovil));
                                                Console.WriteLine();
                                                Console.WriteLine("Automovil registrado con exito!");
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                int codigoMoticicleta = Motocicletas.Count + 1;
                                                Console.Write("Ingrese placa");
                                                string placaMoto = Console.ReadLine();
                                                Console.Write("Ingrese marca: ");
                                                string marcaMoto = Console.ReadLine();
                                                Console.Write("Ingrese modelo: ");
                                                string modeloMoto = Console.ReadLine();
                                                double capacidadMaximaMoto = 30.00;
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
                                                Motocicletas.Add(new Moticicleta(codigoMoticicleta, marcaMoto, modeloMoto, capacidadMaximaMoto, estadoMotocicleta, costoOperativoMoto, placaMoto));
                                                Console.WriteLine();
                                                Console.WriteLine("Moticleta registrada con exito");
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                int codigoBicicleta = Bicicletas.Count + 1;
                                                Console.Write("Ingrese marca: ");
                                                string marcaBicicleta = Console.ReadLine();
                                                Console.Write("Ingrese modelo: ");
                                                string modeloBicleta = Console.ReadLine();
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
                                                Bicicletas.Add(new Bicicleta(codigoBicicleta, marcaBicicleta, modeloBicleta, capacidadMaximaBici, estadoBicicleta, costoOperativoBicicleta));
                                                Console.WriteLine();
                                                Console.WriteLine("Bicicleta registrada con exito!");
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
                                        Console.WriteLine("Consultar Vehiculos");
                                        Console.WriteLine("1. Automoviles\n2. Motocicletas\n3. Bicicletas\n4. Volver atras");
                                        opcionConsultaVehiculo = ValidacionEntradas("Ingrese una opción: ", 1, 4, "Opción no valida");
                                        switch (opcionConsultaVehiculo)
                                        {
                                            case 1:
                                                Console.Clear();
                                                foreach (Automovil automovil in Automoviles)
                                                {
                                                    automovil.MostrarInformacion();
                                                    Console.WriteLine();
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                foreach (Moticicleta motocicleta in Motocicletas)
                                                {
                                                    motocicleta.MostrarInformacion();
                                                    Console.WriteLine();
                                                }
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                foreach (Bicicleta bicicleta in Bicicletas)
                                                {
                                                    bicicleta.MostrarInformacion();
                                                    Console.WriteLine();
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
                            Console.WriteLine("1. Registrar nuevo paquete\n2. Actualizar estado\n3. Calcular tarifa\n4. Mostrar información\n5. Volver al menu principal");
                            opcionPaquete = ValidacionEntradas("Ingrese una opción: ", 1, 5, "Opción no valida");
                            switch (opcionPaquete)
                            {
                                case 1:
                                    int tipoPaquete;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Tipo de paquete: ");
                                        Console.WriteLine();
                                        tipoPaquete = ValidacionEntradas("1. Documento\n2. Estandar\n3. Fragil\n3. Documento\n4. Refrigerado\n5. Volver atras\n>", 1, 5, "Opción no valida");
                                        switch (tipoPaquete)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    int codigoDocumento = Documentos.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 2, "Peso fuera del rango permitido para documento");
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

                                                    Documentos.Add(new Documento(codigoDocumento, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                    Console.Clear();
                                                    Console.WriteLine("Paquete registrado con exito!");

                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    int codigoPaqueteEstandar = PaquetesEstandar.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 50, "Peso fuera del rango permitido para paquete estandar");
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

                                                    PaquetesEstandar.Add(new PaqueteEstandar(codigoPaqueteEstandar, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                    Console.Clear();
                                                    Console.WriteLine("Paquete registrado con exito!");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.Clear();
                                                    int codigoPaqueteFragil = PaquetesFragiles.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 20, "Peso fuera del rango permitido para paquete estandar");
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

                                                    PaquetesFragiles.Add(new PaqueteFragil(codigoPaqueteFragil, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                    Console.Clear();
                                                    Console.WriteLine("Paquete registrado con exito!");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.Clear();
                                                    int codigoProductoRefrigerado = ProductosRefrigerados.Count + 1;
                                                    Console.Write("Ingrese descripción del paquete: ");
                                                    string descripcionPaquete = Console.ReadLine();
                                                    double pesoPaquete = ValidacionEntradasDouble("Ingrese peso: ", 1, 15, "Peso fuera del rango permitido para producto refigerado");
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

                                                    ProductosRefrigerados.Add(new ProductoRefrigerado(codigoProductoRefrigerado, descripcionPaquete, pesoPaquete, valorDeclarado, direccionOrigen, direccionDestino, estadoPaquete));
                                                    Console.Clear();
                                                    Console.WriteLine("Paquete registrado con exito!");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 5:
                                                break;
                                        }
                                        

                                    }while(tipoPaquete != 5);

                                    break;
                                case 2:

                                    Console.Clear();
                                    Console.WriteLine("Actualizar estado de paquete: ");

                                    int opcionEstadoPaquete;
                                    do
                                    {
                                        opcionEstadoPaquete = ValidacionEntradas("1. Documento\n2. Estandar\n3. Fragil\n4. Refrigerado\n5. Volver atras\n>", 1, 5, "Opción no valida");
                                        switch (opcionEstadoPaquete)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine();

                                                    int codigoPaqueteBuscar = ValidacionEntradas("Ingrese codigo de paquete: PAQ-", 1, int.MaxValue, "Codigo no encontrado") - 1;
                                                    int indicePaquete = -1;
                                                    for (int i = 0; i < Documentos.Count; i++)
                                                    {
                                                        if (codigoPaqueteBuscar == Documentos[i].Codigo)
                                                        {
                                                            indicePaquete = i;
                                                            break;
                                                        }
                                                    }

                                                    Console.WriteLine("Estado Actual: " + Documentos[codigoPaqueteBuscar].Estado);

                                                    if (indicePaquete == -1)
                                                    {
                                                        Console.WriteLine("Codigo no encontrado");
                                                        Console.ReadKey();
                                                        break; 
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Paquete encontrado");
                                                        Console.WriteLine("Estado actual: ");
                                                        while (true)
                                                        {

                                                            int opcionEstado = ValidacionEntradas("Seleccione nuevo estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                            if (opcionEstado == 1)
                                                            {
                                                                if (Documentos[codigoPaqueteBuscar].Estado == "Pendiente")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    Documentos[codigoPaqueteBuscar].ActualizarEstado("Pendiente");
                                                                    break;
                                                                }
                                                            }
                                                            else if (opcionEstado == 2)
                                                            {
                                                                if (Documentos[codigoPaqueteBuscar].Estado == "En transito")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    Documentos[codigoPaqueteBuscar].ActualizarEstado("En transito");
                                                                    break;
                                                                }

                                                            }
                                                            else if (opcionEstado == 3)
                                                            {
                                                                if (Documentos[codigoPaqueteBuscar].Estado == "Entregado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    Documentos[codigoPaqueteBuscar].ActualizarEstado("Entregado");
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (Documentos[codigoPaqueteBuscar].Estado == "Cancelado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    Documentos[codigoPaqueteBuscar].ActualizarEstado("Cancelado");
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        Console.WriteLine("Estado cambiado exitosamente!");
                                                        Console.ReadKey();
                                                    }

                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine();

                                                    int codigoPaqueteBuscar = ValidacionEntradas("Ingrese codigo de paquete: PAQ-", 1, int.MaxValue, "Codigo no encontrado") - 1;
                                                    int indicePaquete = -1;
                                                    for (int i = 0; i < PaquetesEstandar.Count; i++)
                                                    {
                                                        if (codigoPaqueteBuscar == PaquetesEstandar[i].Codigo)
                                                        {
                                                            indicePaquete = i;
                                                            break;
                                                        }
                                                    }

                                                    Console.WriteLine("Estado Actual: " + PaquetesEstandar[codigoPaqueteBuscar].Estado);

                                                    if (indicePaquete == -1)
                                                    {
                                                        Console.WriteLine("Codigo no encontrado");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Paquete encontrado");
                                                        Console.WriteLine("Estado actual: ");
                                                        while (true)
                                                        {

                                                            int opcionEstado = ValidacionEntradas("Seleccione nuevo estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                            if (opcionEstado == 1)
                                                            {
                                                                if (PaquetesEstandar[codigoPaqueteBuscar].Estado == "Pendiente")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesEstandar[codigoPaqueteBuscar].ActualizarEstado("Pendiente");
                                                                    break;
                                                                }
                                                            }
                                                            else if (opcionEstado == 2)
                                                            {
                                                                if (PaquetesEstandar[codigoPaqueteBuscar].Estado == "En transito")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesEstandar[codigoPaqueteBuscar].ActualizarEstado("En transito");
                                                                    break;
                                                                }

                                                            }
                                                            else if (opcionEstado == 3)
                                                            {
                                                                if (PaquetesEstandar[codigoPaqueteBuscar].Estado == "Entregado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesEstandar[codigoPaqueteBuscar].ActualizarEstado("Entregado");
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (PaquetesEstandar[codigoPaqueteBuscar].Estado == "Cancelado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesEstandar[codigoPaqueteBuscar].ActualizarEstado("Cancelado");
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        Console.WriteLine("Estado cambiado exitosamente!");
                                                        Console.ReadKey();
                                                    }

                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine();

                                                    int codigoPaqueteBuscar = ValidacionEntradas("Ingrese codigo de paquete: PAQ-", 1, int.MaxValue, "Codigo no encontrado") - 1;
                                                    int indicePaquete = -1;
                                                    for (int i = 0; i < Paquetes.Count; i++)
                                                    {
                                                        if (codigoPaqueteBuscar == PaquetesFragiles[i].Codigo)
                                                        {
                                                            indicePaquete = i;
                                                            break;
                                                        }
                                                    }

                                                    Console.WriteLine("Estado Actual: " + PaquetesFragiles[codigoPaqueteBuscar].Estado);

                                                    if (indicePaquete == -1)
                                                    {
                                                        Console.WriteLine("Codigo no encontrado");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Paquete encontrado");
                                                        Console.WriteLine("Estado actual: ");
                                                        while (true)
                                                        {

                                                            int opcionEstado = ValidacionEntradas("Seleccione nuevo estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                            if (opcionEstado == 1)
                                                            {
                                                                if (PaquetesFragiles[codigoPaqueteBuscar].Estado == "Pendiente")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesFragiles[codigoPaqueteBuscar].ActualizarEstado("Pendiente");
                                                                    break;
                                                                }
                                                            }
                                                            else if (opcionEstado == 2)
                                                            {
                                                                if (PaquetesFragiles[codigoPaqueteBuscar].Estado == "En transito")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesFragiles[codigoPaqueteBuscar].ActualizarEstado("En transito");
                                                                    break;
                                                                }

                                                            }
                                                            else if (opcionEstado == 3)
                                                            {
                                                                if (PaquetesFragiles[codigoPaqueteBuscar].Estado == "Entregado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesFragiles[codigoPaqueteBuscar].ActualizarEstado("Entregado");
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (PaquetesFragiles[codigoPaqueteBuscar].Estado == "Cancelado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    PaquetesFragiles[codigoPaqueteBuscar].ActualizarEstado("Cancelado");
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        Console.WriteLine("Estado cambiado exitosamente!");
                                                        Console.ReadKey();
                                                    }

                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.WriteLine();

                                                    int codigoPaqueteBuscar = ValidacionEntradas("Ingrese codigo de paquete: PAQ-", 1, int.MaxValue, "Codigo no encontrado") - 1;
                                                    int indicePaquete = -1;
                                                    for (int i = 0; i < ProductosRefrigerados.Count; i++)
                                                    {
                                                        if (codigoPaqueteBuscar == ProductosRefrigerados[i].Codigo)
                                                        {
                                                            indicePaquete = i;
                                                            break;
                                                        }
                                                    }

                                                    Console.WriteLine("Estado Actual: " + ProductosRefrigerados[codigoPaqueteBuscar].Estado);

                                                    if (indicePaquete == -1)
                                                    {
                                                        Console.WriteLine("Codigo no encontrado");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Paquete encontrado");
                                                        Console.WriteLine("Estado actual: ");
                                                        while (true)
                                                        {

                                                            int opcionEstado = ValidacionEntradas("Seleccione nuevo estado: \n1. Pendiente\n2. En tránsito\n3. Entregado\n4. Cancelado\n >", 1, 4, "Opción invalida");
                                                            if (opcionEstado == 1)
                                                            {
                                                                if (ProductosRefrigerados[codigoPaqueteBuscar].Estado == "Pendiente")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    ProductosRefrigerados[codigoPaqueteBuscar].ActualizarEstado("Pendiente");
                                                                    break;
                                                                }
                                                            }
                                                            else if (opcionEstado == 2)
                                                            {
                                                                if (ProductosRefrigerados[codigoPaqueteBuscar].Estado == "En transito")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    ProductosRefrigerados[codigoPaqueteBuscar].ActualizarEstado("En transito");
                                                                    break;
                                                                }

                                                            }
                                                            else if (opcionEstado == 3)
                                                            {
                                                                if (ProductosRefrigerados[codigoPaqueteBuscar].Estado == "Entregado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    ProductosRefrigerados[codigoPaqueteBuscar].ActualizarEstado("Entregado");
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (ProductosRefrigerados[codigoPaqueteBuscar].Estado == "Cancelado")
                                                                {
                                                                    Console.WriteLine("No se puede asignar el mismo estado");
                                                                }
                                                                else
                                                                {
                                                                    ProductosRefrigerados[codigoPaqueteBuscar].ActualizarEstado("Cancelado");
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        Console.WriteLine("Estado cambiado exitosamente!");
                                                        Console.ReadKey();
                                                    }

                                                }
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
                                    foreach (Paquete paquete in Paquetes)
                                    {
                                        paquete.MostrarInformacion();
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    break;
                            }
                        } while (opcionPaquete != 3);

                        break;
                    case 5:
                        Console.Clear();
                        int option, option2, entregasPendientes = 0, entregasCumplidas = 0, entregas = 0, codigoCliente, codigoProducto, codigoRepartidor, codigoVehiculo, tipoServicio;
                        bool encontrado = false;
                        string direccionInicial, direccionFinal, servicio;
                        double distancia;
                        do
                        {
                            Console.WriteLine("GESTIÓN DE ENTREGAS\n1. Generar nueva entrega\n2. Ver entregas pendientes\n3. Ver entregas cumplidas\n4. Buscar entrega específica\n5. Mostrar total de entregas\n6. Actualizar estado de entrega\n7. Regresar\nIngrese una opción:");
                            option = ValidarEntero();
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Listado de clientes:");
                                    foreach (Cliente clien in Clientes)
                                    {
                                        Console.WriteLine($"Código: {clien.Codigo}");
                                        Console.WriteLine($"Nombre: {clien.NombreCompleto}");
                                    }
                                    do
                                    {
                                        Console.WriteLine("Ingrese el código del cliente:");
                                        codigoCliente = ValidarEntero();
                                        foreach (Cliente clien in Clientes)
                                        {
                                            if (clien.Codigo == codigoCliente)
                                            {
                                                encontrado = true;
                                            }
                                        }
                                        if (encontrado == false)
                                        {
                                            Console.WriteLine("Error: cliente no encontrado");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } while (true);
                                    Console.WriteLine("Ingrese la dirección de origen:");
                                    direccionInicial = Console.ReadLine();
                                    Console.WriteLine("Ingrese la dirección de destino:");
                                    direccionFinal = Console.ReadLine();
                                    Console.WriteLine("Ingrese la distancia aproximada (en kilómetros):");
                                    distancia = ValidacionEntradasDouble("Ingrese la distancia aproximada (en kilómetros):", 1, 100, "Error: el dato debe ser numérico y estar entre 1 y 100");
                                    Console.WriteLine("Tipo de servicio:\n1. Normal\n2. Prioritario\n3. Urgente");
                                    tipoServicio = ValidacionEntradas("Ingrese una opción:", 1, 3, "Error: dato incorrecto o fuera de rango");
                                    if (tipoServicio == 1)
                                    {
                                        servicio = "Normal";
                                    }
                                    else if(tipoServicio==2)
                                    {
                                        servicio = "Prioritario";
                                    }
                                    else if(tipoServicio==3)
                                    {
                                        servicio = "Urgente";
                                    }
                                    option2 = ValidacionEntradas("Ingrese el tipo de paquete:\n1. Documento\n2. Estándar\n3. Fragil\n4. Refrigerado\nIngrese una opción:", 1, 4, "Error: dato fuera de rango");
                                    switch (option2)
                                    {
                                        case 1:
                                            Console.WriteLine("Listado de documentos:");
                                            foreach(Documento doc in Documentos)
                                            {
                                                Console.WriteLine($"Descripción: {doc.Descripcion}\nCódigo: {doc.Codigo}");
                                                Entregas.Add(new Entrega())
                                            }
                                            break;
                                        case 2:
                                            Console.WriteLine("Listado de paquetes estándar:");
                                            foreach (PaqueteEstandar pac in PaquetesEstandar)
                                            {
                                                Console.WriteLine($"Descripción: {pac.Descripcion}\nCódigo: {pac.Codigo}");
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("Listado de paquetes frágiles:");
                                            foreach (PaqueteFragil doc in PaquetesFragiles)
                                            {
                                                Console.WriteLine($"Descripción: {doc.Descripcion}\nCódigo: {doc.Codigo}");
                                            }
                                            break;
                                        case 4:
                                            Console.WriteLine("Listado de paquetes refrigerados:");
                                            foreach (ProductoRefrigerado doc in ProductosRefrigerados)
                                            {
                                                Console.WriteLine($"Descripción: {doc.Descripcion}\nCódigo: {doc.Codigo}");
                                            }
                                            break;
                                    }
                                    break;
                            }
                            Console.ReadKey();
                        } while (option != 7);
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
        static double ValidacionEntradasDouble(string mensaje, int min, int max, string errorMensaje)
        {
            double valor;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = double.TryParse(entrada, out valor);
                if (!esValido)
                {
                    Console.WriteLine("Por favor ingrese un número");
                }
                else if (valor < min || valor > max)
                {
                    Console.WriteLine(errorMensaje);
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
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out valor);
                if (!esValido)
                {
                    Console.WriteLine("Por favor ingrese un número");
                }
                else if (valor < min || valor > max)
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
        static bool ValidarCorreoElectronico(string correo)
        {
            foreach (char c in correo)
            {
                if (c == '@')
                {
                    return true;
                }
            }
            return false;
        }
        static int ValidarEntero()
        {
            int dato;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out dato))
                {
                    Console.WriteLine("Error: el dato debe ser un número\nIntente nuevamente");
                }
                else
                {
                    if (dato < 0)
                    {
                        Console.WriteLine("Error: el número debe ser positivo");
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);
            return dato;
        }
    }
}

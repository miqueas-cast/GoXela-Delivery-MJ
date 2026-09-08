using System;
using System.Collections.Generic;

using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Permissions;

using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.CodeDom;

namespace GoXelaDelivery
{
    public struct DatosReceptor { public string Nombre; }
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
                if (value >= 0)
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
    }
    class Repartidor : Persona
    {
        private static int ultimoIdRepartidor = 0;
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
                if (value >= 0)
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
                if (value >= 0)
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
        public Repartidor(string nombreCompleto, string telefono, string numeroLicencia, string tipoLicencia, string disponibilidad, int cantidadEntregas, int calificacionEntregas)
            : base(++ultimoIdRepartidor, nombreCompleto, telefono)
        {
            NumeroLicencia = numeroLicencia;
            TipoLicencia = tipoLicencia;
            Disponibilidad = disponibilidad;
            CantidadEntregas = cantidadEntregas;
            CalificacionEntregas = calificacionEntregas;
        }
        public Repartidor(int codigo, string nombreCompleto, string telefono, string numeroLicencia, string tipoLicencia, string disponibilidad, int cantidadEntregas, int calificacionEntregas)
            : base(codigo, nombreCompleto, telefono)
        {
            NumeroLicencia = numeroLicencia;
            TipoLicencia = tipoLicencia;
            Disponibilidad = disponibilidad;
            CantidadEntregas = cantidadEntregas;
            CalificacionEntregas = calificacionEntregas;
            if (codigo > ultimoIdRepartidor)
            {
                ultimoIdRepartidor = codigo;
            }
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

        private int sumaCalificaciones = 0;
        public void RegistrarCalificacion(int nuevaCalificacion)
        {
            if (sumaCalificaciones == 0 && CalificacionEntregas != 0 && CantidadEntregas != 0)
            {
                sumaCalificaciones = CalificacionEntregas * CantidadEntregas;
            }
            sumaCalificaciones += nuevaCalificacion;
            if (CantidadEntregas > 0)
            {
                CalificacionEntregas = sumaCalificaciones / CantidadEntregas;
            }
        }

        public void ActualizarEntregas(int nuevasEntregas)
        {
            CantidadEntregas += nuevasEntregas;
        }
    }
    class Cliente : Persona
    {
        private static int ultimoIdCliente = 0;
        private string correoElectronico;
        private string direccion;
        private int cantidadSolicitudes;

        public int CantidadSolicitudes
        {
            get { return cantidadSolicitudes; }
            set
            {

                if (value >= 0)
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
        public Cliente(string nombreCompleto, string telefono, string correoElectronico, string direccion, int cantidadSolicitudes)
            : base(++ultimoIdCliente, nombreCompleto, telefono)
        {
            CorreoElectronico = correoElectronico;
            Direccion = direccion;
            CantidadSolicitudes = cantidadSolicitudes;
        }
        public Cliente(int codigo, string nombreCompleto, string telefono, string correoElectronico, string direccion, int cantidadSolicitudes)
            : base(codigo, nombreCompleto, telefono)
        {
            CorreoElectronico = correoElectronico;
            Direccion = direccion;
            CantidadSolicitudes = cantidadSolicitudes;
            if (codigo > ultimoIdCliente)
            {
                ultimoIdCliente = codigo;
            }
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

        public Cliente ClienteSolicitante { get; set; }
        public Paquete PaqueteAEnviar { get; set; }
        public Repartidor RepartidorAsignado { get; set; }
        public Vehiculo VehiculoAsignado { get; set; }
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

        public DateTime Fecha { get; set; }



        public DatosReceptor Receptor { get; set; }
        public int Calificacion { get; set; }

        public List<Incidencias> IncidenciasHistorial { get; set; } = new List<Incidencias>();
        public Entrega(int codigo, Cliente cliente, Paquete paquete, double distanciaEstimada, string tipoServicio, string estado, double tarifaBase, double recargos, double descuentos, double total)
        {
            Fecha = DateTime.Now;
            Codigo = codigo;
            ClienteSolicitante = cliente;
            PaqueteAEnviar = paquete;
            DistanciaEstimada = distanciaEstimada;
            TipoServicio = tipoServicio;
            Estado = estado;
            TarifaBase = tarifaBase;
            Recargos = recargos;
            Descuentos = descuentos;
            Total = total;
            RepartidorAsignado = null;
            VehiculoAsignado = null;

            IncidenciasHistorial = new List<Incidencias>();
        }
        public void AgregarNuevaIncidencia(Incidencias incidencia)
        {
            IncidenciasHistorial.Add(incidencia);
        }
        public void CalcularTarifaTotal()
        {
            if (VehiculoAsignado != null && PaqueteAEnviar != null)
            {
                TarifaBase = (PaqueteAEnviar.Peso * 3) + (DistanciaEstimada * 5);
                Recargos = VehiculoAsignado.CalcularTarifaVehiculo() + PaqueteAEnviar.CalcularCostoEnvio();
                if (TipoServicio == "Prioritario") Recargos += 10;
                if (TipoServicio == "Urgente") Recargos += 20;
                Total = TarifaBase + Recargos - Descuentos;
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ ENT-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Fecha de registro:",-23} {Fecha:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"{"Dirección de origen:",-23} {PaqueteAEnviar.DireccionOrigen}");
            Console.WriteLine($"{"Dirección de destino:",-23} {PaqueteAEnviar.DireccionDestino}");
            Console.WriteLine($"{"Distancia estimada:",-23} {DistanciaEstimada}");
            Console.WriteLine($"{"Tipo de servicio:",-23} {TipoServicio}");
            Console.WriteLine($"{"Estado:",-23} {Estado}");
            Console.WriteLine($"{"Tarifa base:",-23} {TarifaBase:F2}");
            Console.WriteLine($"{"Recargos:",-23} {Recargos:F2}");
            Console.WriteLine($"{"Descuentos:",-23} {Descuentos:F2}");
            Console.WriteLine($"{"Total:",-23} {Total:F2}");

            if (RepartidorAsignado != null && VehiculoAsignado != null)
            {
                Console.WriteLine($"{"Repartidor:",-23} {RepartidorAsignado.NombreCompleto}");
                Console.WriteLine($"{"Vehículo:",-23} {VehiculoAsignado.Marca} ");
            }
            else
            {
                Console.WriteLine($"{"Repartidor:",-23} Aún no asignado");
                Console.WriteLine($"{"Vehículo:",-23} Aún no asignado");
            }

            Console.WriteLine("--------------------------------------------\n");
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
        public virtual double CalcularTarifaVehiculo()
        {
            double total;
            total = CostoOperativo;
            return total;
        }
        public virtual bool PuedeTransportar(Paquete paquete)
        {
            return paquete.Peso <= CapacidadMaximaCarga;
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
        public Automovil(int codigo, string marca, string modelo, string estado, string placa)
            : base(codigo, marca, modelo, 250, estado, 35)
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
        public override double CalcularTarifaVehiculo()
        {
            return CostoOperativo + 50;
        }

    }
    class Motocicleta : Vehiculo
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
        public Motocicleta(int codigo, string marca, string modelo, string estado, string placa)
            : base(codigo, marca, modelo, 30, estado, 15)
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
        public override double CalcularTarifaVehiculo()
        {
            return CostoOperativo + 25;
        }
        public override bool PuedeTransportar(Paquete paquete)
        {
            return base.PuedeTransportar(paquete) && !(paquete is ProductoRefrigerado);
        }
    }
    class Bicicleta : Vehiculo
    {
        public Bicicleta(int codigo, string marca, string modelo, string estado)
            : base(codigo, marca, modelo, 10, estado, 15)
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
        public override double CalcularTarifaVehiculo()
        {
            return CostoOperativo + 10;
        }
        public override bool PuedeTransportar(Paquete paquete)
        {
            return base.PuedeTransportar(paquete) && !(paquete is ProductoRefrigerado);
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
        public virtual double CalcularCostoEnvio()
        {
            return Peso * 2.0;
        }

    }
    class ProductoRefrigerado : Paquete
    {
        public ProductoRefrigerado(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
            : base(codigo, descripcion, peso, valorDeclarado, direccionOrigen, direccionDestino, estado)
        {

        }


        public override double CalcularCostoEnvio()
        {
            return base.CalcularCostoEnvio() + 15.0;
        }
    }
    class PaqueteFragil : Paquete
    {
        public PaqueteFragil(int codigo, string descripcion, double peso, double valorDeclarado, string direccionOrigen, string direccionDestino, string estado)
            : base(codigo, descripcion, peso, valorDeclarado, direccionOrigen, direccionDestino, estado)
        {

        }


        public override double CalcularCostoEnvio()
        {
            return base.CalcularCostoEnvio() + 10.0;
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

        public override double CalcularCostoEnvio()
        {
            return 5.0;
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

        public DateTime Fecha { get; set; }

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
        public Incidencias(int codigo, string tipo, string descripcion, string estado, string accionTomada)
        {
            Codigo = codigo;
            Tipo = tipo;
            Descripcion = descripcion;
            Fecha = DateTime.Now;
            Estado = estado;
            AccionTomada = accionTomada;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"                [ INC-{Codigo} ]                  ");
            Console.WriteLine();
            Console.WriteLine($"{"Tipo:",-25} {Tipo}");
            Console.WriteLine($"{"Descripción:",-25} {Descripcion}");
            Console.WriteLine($"{"Fecha:",-25} {Fecha:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"{"Estado:",-25} {Estado}");
            Console.WriteLine($"{"Acción tomada:",-25} {AccionTomada}");
            Console.WriteLine("----------------------------------------------------\n");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> Clientes = new List<Cliente>();
            List<Repartidor> Repartidores = new List<Repartidor>();
            List<Automovil> Automoviles = new List<Automovil>();
            List<Motocicleta> Motocicletas = new List<Motocicleta>();
            List<Bicicleta> Bicicletas = new List<Bicicleta>();
            List<Paquete> Paquetes = new List<Paquete>();
            List<Documento> Documentos = new List<Documento>();
            List<PaqueteEstandar> PaquetesEstandar = new List<PaqueteEstandar>();
            List<PaqueteFragil> PaquetesFragiles = new List<PaqueteFragil>();
            List<ProductoRefrigerado> ProductosRefrigerados = new List<ProductoRefrigerado>();
            List<Incidencias> IncidenciasList = new List<Incidencias>();
            List<Entrega> Entregas = new List<Entrega>();

            // datos de prueba

            Clientes.Add(new Cliente(1, "Miqueas", "44904473", "miqueas@gmail.com", "Zona 2 Xela", 0));
            Repartidores.Add(new Repartidor(1, "Juan Perez", "12345678", "LIC12345", "B", "Disponible", 0, 0));
            Automoviles.Add(new Automovil(1, "Toyota", "Camry", "Disponible", "PLACA123"));
            Motocicletas.Add(new Motocicleta(1, "Honda", "Chart", "Disponible", "PLACA456"));
            Bicicletas.Add(new Bicicleta(1, "Trek", "Marlin", "Disponible"));
            Documentos.Add(new Documento(1, "Documento importante", 0.5, 100, "Zona 1", "Zona 2", "Pendiente"));
            PaquetesEstandar.Add(new PaqueteEstandar(1, "Paquete estándar", 2, 200, "Zona 3", "Zona 4", "Pendiente"));
            PaquetesFragiles.Add(new PaqueteFragil(1, "Paquete frágil", 1, 100, "Zona 5", "Zona 6", "Pendiente"));
            ProductosRefrigerados.Add(new ProductoRefrigerado(1, "Producto refrigerado", 0.5, 100, "Zona 7", "Zona 8", "Pendiente"));

            int opcion;
            do
            {
                Console.Clear();
                opcion = ValidacionEntradas("========================================\r\n          GOXELA DELIVERY\r\n========================================\r\n\n1. Gestión de clientes\r\n2. Gestión de repartidores\r\n3. Gestión de vehículos\r\n4. Gestión de paquetes\r\n5. Gestión de entregas\r\n6. Gestión de incidencias\r\n7. Reportes\r\n8. Salir\n\nIngrese una opción: ", 1, 8, "Opción fuera del rango");
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
                                    int confirmacionCliente = ValidacionEntradas($"Resumen de datos:\n \nNombre: {nombre}\nNúmero de teléfono: {numeroTelefono}\nCorreo electronico: {correoElectronico}\nDirección: {direccion}\n\n¿Esta seguro que desea registrar nuevo cliente?\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Erro: Opción no valida");
                                    if (confirmacionCliente == 1)
                                    {
                                        Console.Clear();
                                        Clientes.Add(new Cliente(nombre, numeroTelefono, correoElectronico, direccion, 0));
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
                                    if (Clientes.Count == 0)
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
                                    for (int i = 0; i < Clientes.Count; i++)
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
                            opcionRepartidor = ValidacionEntradas("REPARTIDORES\n\n1. Registrar\n2. Consultar\n3. Actualizar estado\n4. Volver al menu principal\n\nIngrese una opción: ", 1, 4, "Opción fuera del rango");
                            switch (opcionRepartidor)
                            {
                                case 1:
                                    Console.Clear();
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

                                    int confirmacionRepartidor = ValidacionEntradas($"Resumen de datos: \n \nNombre: {repartidorNombre}\nNúmero: {numeroRepartidor}\nNúmero de licencia: {numeroLicencia}\nTipo de licencia: {tipoLicencia}\nEstado: {estadoRepartidor}\n\n¿Esta seguro que desea registrar nuevo repartidor?\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Opción no valida");
                                    if (confirmacionRepartidor == 1)
                                    {
                                        Console.Clear();
                                        Repartidores.Add(new Repartidor(repartidorNombre, numeroRepartidor, numeroLicencia, tipoLicencia, estadoRepartidor, 0, 0));
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

                                        int codigoRepartidor1 = ValidacionEntradas("Ingrese codigo de repartidor: ", 1, int.MaxValue, "Repartidor no encontrado ");

                                        int indiceRep = -1;
                                        for (int i = 0; i < Repartidores.Count; i++)
                                        {
                                            if (Repartidores[i].Codigo == codigoRepartidor1)
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

                                                int confirmacionAutomovil = ValidacionEntradas($"Resumen de datos: \n\nPlaca: {placaAutomovil}\nMarca: {marca}\nModelo: {modelo}\nEstado: {estadoAutomovil}\n\nConfirmar registro de AUTO-{codigoAuto}\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                if (confirmacionAutomovil == 1)
                                                {
                                                    Console.Clear();
                                                    Automoviles.Add(new Automovil(codigoAuto, marca, modelo, estadoAutomovil, placaAutomovil));
                                                    MostrarAnimacionPuntos();

                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    MostrarErrorAnimado("Operación cancelada.");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Console.Clear();
                                                int codigoMotocicleta = Motocicletas.Count + 1;
                                                Console.Write("Ingrese placa: ");
                                                string placaMoto = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese marca: ");
                                                string marcaMoto = Console.ReadLine();
                                                Console.Clear();
                                                Console.Write("Ingrese modelo: ");
                                                string modeloMoto = Console.ReadLine();

                                                Console.Clear();
                                                string estadoMotocicleta;
                                                while (true)
                                                {
                                                    int opcionMotocicleta = ValidacionEntradas("Seleccione estado: \n1. Disponible\n2. Asignado\n3. En mantenimiento\n >", 1, 3, "Opción invalida");
                                                    if (opcionMotocicleta == 1)
                                                    {
                                                        estadoMotocicleta = "Disponible";
                                                        break;
                                                    }
                                                    else if (opcionMotocicleta == 1)
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

                                                Console.Clear();
                                                int confirmacionMotocicleta = ValidacionEntradas($"Resumen de datos: \n\nPlaca: {placaMoto}\nMarca: {marcaMoto}\nModelo: {modeloMoto}\nEstado: {estadoMotocicleta}\n\n¿Esta seguro que desea registrar MOT-{codigoMotocicleta}?\n1. Sí. \n2. No.\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                if (confirmacionMotocicleta == 1)
                                                {
                                                    Console.Clear();
                                                    Motocicletas.Add(new Motocicleta(codigoMotocicleta, marcaMoto, modeloMoto, estadoMotocicleta, placaMoto));
                                                    MostrarAnimacionPuntos();
                                                }
                                                else
                                                {
                                                    MostrarErrorAnimado("Operación cancelada.");
                                                    Console.ReadKey();
                                                    break;
                                                }
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
                                                Console.Clear();

                                                int confirmacionBicicleta = ValidacionEntradas($"Resumen de datos: \n\n\nMarca: {marcaBicicleta}\nModelo: {modeloBicleta}\nEstado: {estadoBicicleta}\n\nConfirmar registro de BICI-{codigoBicicleta}\n1. Sí\n2. No\nIngrese una opción: ", 1, 2, "Error: Opción no valida");
                                                if (confirmacionBicicleta == 1)
                                                {
                                                    Console.Clear();
                                                    Bicicletas.Add(new Bicicleta(codigoBicicleta, marcaBicicleta, modeloBicleta, estadoBicicleta));
                                                    MostrarAnimacionPuntos();
                                                }
                                                else
                                                {
                                                    MostrarErrorAnimado("Operación cancelada.");
                                                    Console.ReadKey();
                                                    break;
                                                }
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
                                                    foreach (Motocicleta motocicleta in Motocicletas)
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
                                                    if (confirmacionDoc == 1)
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
                                                    if (confirmacionEstandar == 1)
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
                        int opcionEntregasSwitch;
                        int entregasPendientes = 0, entregasCumplidas = 0, tipoServicio;

                        do
                        {
                            Console.Clear();
                            opcionEntregasSwitch = ValidacionEntradas("GESTIÓN DE ENTREGAS\n\n1. Generar nueva entrega\n2. Ver entregas pendientes\n3. Ver entregas cumplidas\n4. Buscar entrega específica\n5. Mostrar total de entregas\n6. Actualizar estado de entrega\n7. Regresar\n\nIngrese una opción: ", 1, 7, "Error: opción no valida");
                            switch (opcionEntregasSwitch)
                            {
                                case 1:
                                    Console.Clear();
                                    int codigoPaquete = Entregas.Count + 1;
                                    Console.WriteLine("Listado de clientes:");
                                    foreach (Cliente clien in Clientes)
                                    {
                                        Console.WriteLine($"Código: CLI-{clien.Codigo}");
                                        Console.WriteLine($"Nombre: {clien.NombreCompleto}");
                                    }
                                    Console.ReadKey();
                                    Console.WriteLine();
                                    int codigoClienteRelacion = ValidacionEntradas("Ingrese el código del cliente para relacionarlo con la entrega:CLI-", 1, int.MaxValue, "Error: cliente no valido");
                                    int indiceRelacion = -1;
                                    for (int i = 0; i < Clientes.Count; i++)
                                    {
                                        if (Clientes[i].Codigo == codigoClienteRelacion)
                                        {
                                            indiceRelacion = i;
                                            break;
                                        }
                                    }
                                    if (indiceRelacion == -1)
                                    {
                                        MostrarErrorAnimado("Error: cliente no encontrado");
                                        break;
                                    }
                                    Cliente clienteSeleccionado = Clientes[indiceRelacion];
                                    Console.Clear();

                                    int indicePaqueteRelacion = -1;
                                    int tipoPaqueteRelacion;
                                    string tipoPaqueteS = "";
                                    Paquete paqueteSeleccionado = null;

                                    tipoPaqueteRelacion = ValidacionEntradas($"Tipo de paquete: \n1. Documento\n2. Estándar\n3. Fragil\n4. Refrigerado\n\nIngrese una opción: ", 1, 4, "Error: dato fuera de rango");

                                    switch (tipoPaqueteRelacion)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("Documentos: ");
                                            Console.WriteLine();
                                            foreach (Documento doc in Documentos)
                                            {
                                                Console.WriteLine($"Codigo: DOC-{doc.Codigo}");
                                                Console.WriteLine($"Descripción: {doc.Descripcion}");
                                            }
                                            Console.ReadKey();
                                            Console.Clear();
                                            int codigoDoc = ValidacionEntradas("Ingrese el código del documento: DOC-", 1, int.MaxValue, "Error: código incorrecto");
                                            for (int i = 0; i < Documentos.Count; i++)
                                            {
                                                if (Documentos[i].Codigo == codigoDoc)
                                                {
                                                    indicePaqueteRelacion = i;
                                                    paqueteSeleccionado = Documentos[i];
                                                    tipoPaqueteS = "Documento";
                                                    break;
                                                }
                                            }
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Console.WriteLine("Paquetes estandar: ");
                                            Console.WriteLine();
                                            foreach (PaqueteEstandar paque in PaquetesEstandar)
                                            {
                                                Console.WriteLine($"Codigo: PAQE-{paque.Codigo}");
                                                Console.WriteLine($"Descripción: {paque.Descripcion}");
                                            }
                                            Console.ReadKey();
                                            Console.Clear();

                                            int codigoEstandar = ValidacionEntradas("Ingrese el código del paquete estándar: PAQE-", 1, int.MaxValue, "Error: código incorrecto");
                                            for (int i = 0; i < PaquetesEstandar.Count; i++)
                                            {
                                                if (PaquetesEstandar[i].Codigo == codigoEstandar)
                                                {
                                                    indicePaqueteRelacion = i;
                                                    paqueteSeleccionado = PaquetesEstandar[i];
                                                    tipoPaqueteS = "Estandar";
                                                    break;
                                                }
                                            }
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine("Paquetes fragiles: ");
                                            Console.WriteLine();
                                            foreach (PaqueteFragil paquef in PaquetesFragiles)
                                            {
                                                Console.WriteLine($"Codigo: PAQF-{paquef.Codigo}");
                                                Console.WriteLine($"Descripción: {paquef.Descripcion}");
                                            }
                                            Console.ReadKey();
                                            Console.Clear();
                                            int codigoFragil = ValidacionEntradas("Ingrese el código del paquete frágil: PAQF-", 1, int.MaxValue, "Error: código incorrecto");
                                            for (int i = 0; i < PaquetesFragiles.Count; i++)
                                            {
                                                if (PaquetesFragiles[i].Codigo == codigoFragil)
                                                {
                                                    indicePaqueteRelacion = i;
                                                    paqueteSeleccionado = PaquetesFragiles[i];
                                                    tipoPaqueteS = "Fragil";
                                                    break;
                                                }
                                            }
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine("Producotos refrigerados: ");
                                            Console.WriteLine();
                                            foreach (ProductoRefrigerado paquere in ProductosRefrigerados)
                                            {
                                                Console.WriteLine($"Codigo: PAQR-{paquere.Codigo}");
                                                Console.WriteLine($"Descripción: {paquere.Descripcion}");
                                            }
                                            Console.ReadKey();
                                            Console.Clear();
                                            int codigoRefrigerado = ValidacionEntradas("Ingrese el código del paquete refrigerado: PAQR-", 1, int.MaxValue, "Error: código incorrecto");
                                            for (int i = 0; i < ProductosRefrigerados.Count; i++)
                                            {
                                                if (ProductosRefrigerados[i].Codigo == codigoRefrigerado)
                                                {
                                                    indicePaqueteRelacion = i;
                                                    paqueteSeleccionado = ProductosRefrigerados[i];
                                                    tipoPaqueteS = "Refrigerado";
                                                    break;
                                                }
                                            }
                                            break;
                                    }

                                    if (indicePaqueteRelacion == -1 || paqueteSeleccionado == null)
                                    {
                                        MostrarErrorAnimado("Error: paquete no encontrado");
                                        break;
                                    }

                                    bool paqueteYaEnUso = false;
                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.PaqueteAEnviar != null && ent.PaqueteAEnviar == paqueteSeleccionado)
                                        {
                                            if (ent.Estado != "Entregada" && ent.Estado != "Cancelada")
                                            {
                                                paqueteYaEnUso = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (paqueteYaEnUso)
                                    {
                                        MostrarErrorAnimado("Error: El paquete seleccionado ya se encuentra asignado a una entrega activa.");
                                        break;
                                    }

                                    double distancia = ValidacionEntradasDouble("Ingrese la distancia aproximada (en kilómetros):", 1, 100, "Error: el dato debe ser numérico y estar entre 1 y 100");
                                    tipoServicio = ValidacionEntradas("Tipo de servicio:\n1. Normal\n2. Prioritario\n3. Urgente\nIngrese una opción:", 1, 3, "Error: dato incorrecto o fuera de rango");
                                    string tipoServicioS;

                                    if (tipoServicio == 1) tipoServicioS = "Normal";
                                    else if (tipoServicio == 2) tipoServicioS = "Prioritario";
                                    else tipoServicioS = "Urgente";

                                    double tarifaCalculada = CalcularTarifaBase(paqueteSeleccionado.Peso, distancia, tipoPaqueteS, tipoServicioS);

                                    Entregas.Add(new Entrega(codigoPaquete, clienteSeleccionado, paqueteSeleccionado, distancia, tipoServicioS, "Solicitada", tarifaCalculada, 0, 0, 0));
                                    MostrarAnimacionPuntos();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("ENTREGAS PENDIENTES");
                                    entregasPendientes = 0;
                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.Estado != "Entregada" && ent.Estado != "Cancelada")
                                        {
                                            ent.MostrarInformacion();
                                            entregasPendientes++;
                                        }
                                    }
                                    if (entregasPendientes == 0)
                                    {
                                        MostrarErrorAnimado("No hay entregas pendientes");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\nTotal de entregas pendientes: {entregasPendientes}");
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("ENTREGAS CUMPLIDAS");
                                    entregasCumplidas = 0;
                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.Estado == "Entregada")
                                        {
                                            ent.MostrarInformacion();
                                            entregasCumplidas++;
                                        }
                                    }
                                    if (entregasCumplidas == 0)
                                    {
                                        MostrarErrorAnimado("No hay entregas cumplidas");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\nTotal de entregas cumplidas: {entregasCumplidas}");
                                    }
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("BUSCAR ENTREGA ESPECÍFICA");
                                    int codigoEntregaBuscar = ValidacionEntradas("Ingrese el código de la entrega a buscar: ENT-", 1, int.MaxValue, "Error: entrega no encontrada");
                                    int indiceEntregaBuscar = -1;
                                    for (int i = 0; i < Entregas.Count; i++)
                                    {
                                        if (Entregas[i].Codigo == codigoEntregaBuscar)
                                        {
                                            indiceEntregaBuscar = i;
                                            break;
                                        }
                                    }
                                    if (indiceEntregaBuscar == -1)
                                    {
                                        MostrarErrorAnimado("Error: entrega no encontrada");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Entregas[indiceEntregaBuscar].MostrarInformacion();
                                    }
                                    break;

                                case 5:
                                    Console.Clear();
                                    if (Entregas.Count == 0)
                                    {
                                        MostrarErrorAnimado("No hay entregas registradas");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Total de entregas registradas: {Entregas.Count}");
                                    }
                                    break;

                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("ACTUALIZAR ESTADO DE ENTREGA");

                                    Console.WriteLine();
                                    Console.WriteLine("Lista de entregas: ");

                                    for (int i = 0; i < Entregas.Count; i++)
                                    {
                                        Console.WriteLine($"- ENT-{Entregas[i].Codigo}: {Entregas[i].Estado}");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();

                                    int codigoEntregaActualizar = ValidacionEntradas("Ingrese código de la entrega a actualizar: ENT-", 1, int.MaxValue, "Error: entrega no encontrada");
                                    int indiceEntregaActualizar = -1;

                                    for (int i = 0; i < Entregas.Count; i++)
                                    {
                                        if (Entregas[i].Codigo == codigoEntregaActualizar)
                                        {
                                            indiceEntregaActualizar = i;
                                            break;
                                        }
                                    }

                                    if (indiceEntregaActualizar == -1)
                                    {
                                        MostrarErrorAnimado("Error: entrega no encontrada");
                                        break;
                                    }

                                    Console.Clear();
                                    Console.WriteLine($"Estado actual: {Entregas[indiceEntregaActualizar].Estado}");


                                    if (Entregas[indiceEntregaActualizar].Estado == "Entregada" || Entregas[indiceEntregaActualizar].Estado == "Cancelada")
                                    {
                                        Console.WriteLine("Error: No se puede modificar una entrega que ya está finalizada o cancelada.");
                                        break;
                                    }

                                    bool estadoActualizadoExitosamente = false;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Estado actual: {Entregas[indiceEntregaActualizar].Estado}");
                                        int opcionEstadoActualizar = ValidacionEntradas("Seleccione el nuevo estado:\n1. Asignada\n2. Recogida\n3. En ruta\n4. Entregada\n5. Volver\nIngrese una opción:", 1, 5, "Error: opción no valida");

                                        if (opcionEstadoActualizar == 5)
                                        {
                                            break;
                                        }

                                        switch (opcionEstadoActualizar)
                                        {
                                            case 1:
                                                if (Entregas[indiceEntregaActualizar].Estado != "Solicitada")
                                                {
                                                    MostrarErrorAnimado("Error: Secuencia incorrecta. Solo una entrega 'Solicitada' puede pasar a 'Asignada'.");
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("Repartidores: ");
                                                Console.WriteLine();
                                                foreach (Repartidor rep in Repartidores)
                                                {
                                                    Console.WriteLine($"Codigo: REP-{rep.Codigo}");
                                                    Console.WriteLine($"Nombre: {rep.NombreCompleto}");
                                                    Console.WriteLine();
                                                }
                                                Console.ReadKey();
                                                Console.Clear();
                                                int codRep = ValidacionEntradas("Ingrese el código del repartidor a asignar: ", 1, int.MaxValue, "Error: código inválido");
                                                int indiceRep = -1;
                                                for (int i = 0; i < Repartidores.Count; i++)
                                                {
                                                    if (Repartidores[i].Codigo == codRep) { indiceRep = i; break; }
                                                }

                                                if (indiceRep == -1)
                                                {
                                                    MostrarErrorAnimado("Error: Repartidor no encontrado.");
                                                    break;
                                                }
                                                if (Repartidores[indiceRep].Disponibilidad != "Disponible")
                                                {
                                                    MostrarErrorAnimado("Error: El repartidor seleccionado se encuentra ocupado o fuera de servicio.");
                                                    break;
                                                }

                                                int tipoVehiculo = ValidacionEntradas("Tipo de vehículo a asignar:\n1. Automóvil\n2. Motocicleta\n3. Bicicleta\nIngrese una opción:", 1, 3, "Error: opción no válida");

                                                switch (tipoVehiculo)
                                                {
                                                    case 1:
                                                        Console.Clear();
                                                        Console.WriteLine("Automoviles: ");
                                                        Console.WriteLine();
                                                        foreach (Automovil auto in Automoviles)
                                                        {
                                                            Console.WriteLine($"Codigo: AUT-{auto.Codigo}");
                                                            Console.WriteLine($"Marca: {auto.Marca}");
                                                        }
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        break;
                                                    case 2:
                                                        Console.Clear();
                                                        Console.WriteLine("Motocicletas: ");
                                                        Console.WriteLine();
                                                        foreach (Motocicleta moto in Motocicletas)
                                                        {
                                                            Console.WriteLine($"Codigo: MOT-{moto.Codigo}");
                                                            Console.WriteLine($"Marca: {moto.Marca}");
                                                        }
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        break;
                                                    case 3:
                                                        Console.Clear();
                                                        Console.WriteLine("Bicicletas: ");
                                                        Console.WriteLine();
                                                        foreach (Bicicleta bici in Bicicletas)
                                                        {
                                                            Console.WriteLine($"Codigo: BIC-{bici.Codigo}");
                                                            Console.WriteLine($"Marca: {bici.Marca}");
                                                        }
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        break;
                                                    case 4:
                                                        break;
                                                }
                                                int codVeh = ValidacionEntradas("Ingrese el código del vehículo: ", 1, int.MaxValue, "Error: código inválido");

                                                int indiceVeh = -1;
                                                string estadoVehiculo = "";
                                                double capacidadVehiculo = 0;
                                                object vehiculoSeleccionado = null;

                                                switch (tipoVehiculo)
                                                {
                                                    case 1:
                                                        for (int i = 0; i < Automoviles.Count; i++)
                                                        {
                                                            if (Automoviles[i].Codigo == codVeh)
                                                            {
                                                                indiceVeh = i;
                                                                estadoVehiculo = Automoviles[i].Estado;
                                                                capacidadVehiculo = Automoviles[i].CapacidadMaximaCarga;
                                                                vehiculoSeleccionado = Automoviles[i];
                                                                break;
                                                            }
                                                        }
                                                        if (Repartidores[indiceRep].TipoLicencia != "B") { Console.WriteLine("Licencia incompatible."); break; }
                                                        break;
                                                    case 2:
                                                        for (int i = 0; i < Motocicletas.Count; i++)
                                                        {
                                                            if (Motocicletas[i].Codigo == codVeh)
                                                            {
                                                                indiceVeh = i;
                                                                estadoVehiculo = Motocicletas[i].Estado;
                                                                capacidadVehiculo = Motocicletas[i].CapacidadMaximaCarga;
                                                                vehiculoSeleccionado = Motocicletas[i];
                                                                break;
                                                            }
                                                        }
                                                        break;
                                                    case 3:
                                                        for (int i = 0; i < Bicicletas.Count; i++)
                                                        {
                                                            if (Bicicletas[i].Codigo == codVeh)
                                                            {
                                                                indiceVeh = i;
                                                                estadoVehiculo = Bicicletas[i].Estado;
                                                                capacidadVehiculo = Bicicletas[i].CapacidadMaximaCarga;
                                                                vehiculoSeleccionado = Bicicletas[i];
                                                                break;
                                                            }
                                                        }
                                                        break;
                                                }

                                                if (indiceVeh == -1)
                                                {
                                                    MostrarErrorAnimado("Error: Vehículo no encontrado.");
                                                    break;
                                                }
                                                if (estadoVehiculo != "Disponible")
                                                {
                                                    MostrarErrorAnimado("Error: El vehículo seleccionado no está disponible.");
                                                    break;
                                                }

                                                double pesoDelPaquete = Entregas[indiceEntregaActualizar].PaqueteAEnviar.Peso;

                                                if (!((Vehiculo)vehiculoSeleccionado).PuedeTransportar(Entregas[indiceEntregaActualizar].PaqueteAEnviar))
                                                {
                                                    Console.WriteLine("Error de compatibilidad: El vehículo no puede transportar este paquete por peso o tipo.");
                                                    break;
                                                }

                                                if (tipoVehiculo == 3 && Entregas[indiceEntregaActualizar].PaqueteAEnviar is ProductoRefrigerado)
                                                {
                                                    Console.WriteLine("Error de compatibilidad: No se puede transportar un Producto Refrigerado en una Bicicleta.");
                                                    break;
                                                }


                                                Entregas[indiceEntregaActualizar].Estado = "Asignada";
                                                Repartidores[indiceRep].Disponibilidad = "Asignado";

                                                if (tipoVehiculo == 1) Automoviles[indiceVeh].Estado = "Asignado";
                                                else if (tipoVehiculo == 2) Motocicletas[indiceVeh].Estado = "Asignado";
                                                else if (tipoVehiculo == 3) Bicicletas[indiceVeh].Estado = "Asignado";


                                                Entregas[indiceEntregaActualizar].RepartidorAsignado = Repartidores[indiceRep];


                                                Entregas[indiceEntregaActualizar].VehiculoAsignado = (Vehiculo)vehiculoSeleccionado;
                                                Entregas[indiceEntregaActualizar].CalcularTarifaTotal();

                                                Console.WriteLine("\n¡Repartidor y Vehículo asignados exitosamente!");
                                                Console.WriteLine("La entrega ha pasado a estado ASIGNADA.");
                                                Console.ReadKey();
                                                estadoActualizadoExitosamente = true;
                                                break;

                                            case 2:
                                                if (Entregas[indiceEntregaActualizar].Estado != "Asignada")
                                                {
                                                    MostrarErrorAnimado("Error: La entrega debe estar 'Asignada' antes de ser 'Recogida'.");
                                                    break;
                                                }
                                                Entregas[indiceEntregaActualizar].Estado = "Recogida";
                                                Console.WriteLine("¡Entrega actualizada a RECOGIDA!");
                                                Console.ReadKey();
                                                estadoActualizadoExitosamente = true;
                                                break;

                                            case 3:
                                                if (Entregas[indiceEntregaActualizar].Estado != "Recogida")
                                                {
                                                    MostrarErrorAnimado("Error: La entrega debe estar 'Recogida' antes de pasar a 'En ruta'.");
                                                    break;
                                                }
                                                Entregas[indiceEntregaActualizar].Estado = "En ruta";
                                                if (Entregas[indiceEntregaActualizar].PaqueteAEnviar != null)
                                                {
                                                    Entregas[indiceEntregaActualizar].PaqueteAEnviar.ActualizarEstado("En tránsito");
                                                }
                                                Console.WriteLine("¡Entrega actualizada a EN RUTA!");
                                                Console.ReadKey();
                                                estadoActualizadoExitosamente = true;
                                                break;

                                            case 4:
                                                if (Entregas[indiceEntregaActualizar].Estado != "En ruta")
                                                {
                                                    MostrarErrorAnimado("Error: La entrega debe estar 'En ruta' antes de ser marcada como 'Entregada'.");
                                                    break;
                                                }

                                                Entregas[indiceEntregaActualizar].Estado = "Entregada";
                                                if (Entregas[indiceEntregaActualizar].PaqueteAEnviar != null)
                                                {
                                                    Entregas[indiceEntregaActualizar].PaqueteAEnviar.ActualizarEstado("Entregado");
                                                }

                                                Console.Write("Ingrese el nombre de la persona que recibe el paquete: ");
                                                string nombreRec = Console.ReadLine();

                                                DatosReceptor receptor = new DatosReceptor();
                                                receptor.Nombre = nombreRec;
                                                Entregas[indiceEntregaActualizar].Receptor = receptor;

                                                int calif = ValidacionEntradas("Ingrese la calificación del repartidor para esta entrega (1 al 5): ", 1, 5, "Calificación inválida.");
                                                Entregas[indiceEntregaActualizar].Calificacion = calif;

                                                if (Entregas[indiceEntregaActualizar].RepartidorAsignado != null)
                                                {
                                                    Entregas[indiceEntregaActualizar].RepartidorAsignado.Disponibilidad = "Disponible";
                                                    Entregas[indiceEntregaActualizar].RepartidorAsignado.ActualizarEntregas(1);
                                                    Entregas[indiceEntregaActualizar].RepartidorAsignado.RegistrarCalificacion(calif);
                                                }


                                                if (Entregas[indiceEntregaActualizar].VehiculoAsignado != null)
                                                {
                                                    Entregas[indiceEntregaActualizar].VehiculoAsignado.Estado = "Disponible";
                                                }


                                                Console.WriteLine("¡Entrega finalizada con éxito! Repartidor y vehículo liberados.");
                                                Console.ReadKey();
                                                estadoActualizadoExitosamente = true;
                                                break;
                                        }
                                    } while (!estadoActualizadoExitosamente);
                                    break;
                            }
                        } while (opcionEntregasSwitch != 7);
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
                                    int codigoEntregaBuscar = ValidacionEntradas("Ingrese el código de la entrega afectada: ENT-", 1, int.MaxValue, "Codigo no encontrado");
                                    int indiceEntrega = -1;

                                    for (int i = 0; i < Entregas.Count; i++)
                                    {
                                        if (codigoEntregaBuscar == Entregas[i].Codigo)
                                        {
                                            indiceEntrega = i;
                                            break;
                                        }
                                    }

                                    if (indiceEntrega == -1)
                                    {
                                        MostrarErrorAnimado("Error: Entrega no encontrada.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        if (Entregas[indiceEntrega].Estado == "Entregada" || Entregas[indiceEntrega].Estado == "Cancelada")
                                        {
                                            MostrarErrorAnimado("Error: No se pueden registrar incidencias ni modificar una entrega que ya está Entregada o Cancelada.");
                                            Console.ReadKey();
                                            break;
                                        }

                                        Console.Clear();
                                        string tipoIncidenciaString;
                                        int tipoIncidencia = ValidacionEntradas("Seleccione tipo de incidencia: \n1. Cliente ausente\n2. Vehículo averiado\n3. Dañado\n4. Otro (Retraso/Clima)\n5. Volver atras\n\nIngrese una opción: ", 1, 5, "Error: Opción no valida");

                                        if (tipoIncidencia == 1) tipoIncidenciaString = "Cliente ausente";
                                        else if (tipoIncidencia == 2) tipoIncidenciaString = "Vehículo averiado";
                                        else if (tipoIncidencia == 3) tipoIncidenciaString = "Dañado";
                                        else if (tipoIncidencia == 4) tipoIncidenciaString = "Otro";
                                        else break;

                                        Console.Clear();
                                        Console.Write("Ingrese descripción: ");
                                        string descripcion = Console.ReadLine();

                                        string estadoIncidencia;
                                        Console.Clear();
                                        int estadoIncidenciaOpcion = ValidacionEntradas("Seleccione estado de incidencia: \n1. Pendiente\n2. En proceso\n3. Resuelto\n\nIngrese una opción: ", 1, 3, "Error: Opción no valida");

                                        if (estadoIncidenciaOpcion == 1) estadoIncidencia = "Pendiente";
                                        else if (estadoIncidenciaOpcion == 2) estadoIncidencia = "En proceso";
                                        else estadoIncidencia = "Resuelto";

                                        Console.Clear();
                                        Console.Write("Acción tomada: ");
                                        string accionTomada = Console.ReadLine();

                                        int confirmacionIncidencia = ValidacionEntradas($"Resumen de datos: \n\nCódigo de incidencia: INC-{codigoPaqueteIncidencia}\nTipo de incidencia: {tipoIncidenciaString}\nDescripción: {descripcion}\nEstado: {estadoIncidencia}\nAcción tomada: {accionTomada}\n\n¿Desea registrar esta incidencia? \n1. Sí \n2. No: ", 1, 2, "Error: Opción no valida");

                                        if (confirmacionIncidencia == 1)
                                        {
                                            Console.Clear();
                                            Incidencias nuevaIncidencia = new Incidencias(codigoPaqueteIncidencia, tipoIncidenciaString, descripcion, estadoIncidencia, accionTomada);
                                            IncidenciasList.Add(nuevaIncidencia);
                                            Entregas[indiceEntrega].AgregarNuevaIncidencia(nuevaIncidencia);

                                            Console.WriteLine("Incidencia registrada con éxito.\n");

                                            int accionEntrega = ValidacionEntradas("¿Qué sucederá con la entrega debido a esta incidencia?\n1. Mantener estado actual (Continúa en ruta)\n2. Cancelar la entrega\n3. Reprogramar la entrega\nIngrese una opción: ", 1, 3, "Error: Opción no valida");

                                            if (accionEntrega == 2)
                                            {
                                                Entregas[indiceEntrega].Estado = "Cancelada";

                                                if (Entregas[indiceEntrega].RepartidorAsignado != null)
                                                    Entregas[indiceEntrega].RepartidorAsignado.Disponibilidad = "Disponible";
                                                if (Entregas[indiceEntrega].VehiculoAsignado != null)
                                                    Entregas[indiceEntrega].VehiculoAsignado.Estado = "Disponible";
                                                if (Entregas[indiceEntrega].PaqueteAEnviar != null)
                                                    Entregas[indiceEntrega].PaqueteAEnviar.ActualizarEstado("Cancelado");

                                                Console.WriteLine("\nLa entrega ha sido CANCELADA y el repartidor/vehículo/paquete han sido actualizados.");
                                            }
                                            else if (accionEntrega == 3)
                                            {
                                                Entregas[indiceEntrega].Estado = "Reprogramada";

                                                Console.Write("\nIngrese la nueva fecha y hora para la entrega (ej. 10/09/2026 14:00): ");
                                                string nuevaFecha = Console.ReadLine();

                                                try
                                                {
                                                    Entregas[indiceEntrega].Fecha = DateTime.Parse(nuevaFecha);
                                                }
                                                catch (Exception)
                                                {
                                                    MostrarErrorAnimado("Error: Formato de fecha inválido.");
                                                    break;
                                                }


                                                if (Entregas[indiceEntrega].RepartidorAsignado != null)
                                                    Entregas[indiceEntrega].RepartidorAsignado.Disponibilidad = "Disponible";
                                                if (Entregas[indiceEntrega].VehiculoAsignado != null)
                                                    Entregas[indiceEntrega].VehiculoAsignado.Estado = "Disponible";
                                                if (Entregas[indiceEntrega].PaqueteAEnviar != null)
                                                    Entregas[indiceEntrega].PaqueteAEnviar.ActualizarEstado("Pendiente");

                                                Console.WriteLine($"\nLa entrega ha sido REPROGRAMADA para: {nuevaFecha}. Repartidor/vehículo liberados temporalmente y paquete en espera.");
                                            }

                                            MostrarAnimacionPuntos();
                                        }
                                        else
                                        {
                                            MostrarErrorAnimado("Operación cancelada");
                                            break;
                                        }
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    if (IncidenciasList.Count == 0)
                                    {
                                        MostrarErrorAnimado("Sin incidencias registradas.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("LISTADO DE INCIDENCIAS\n");
                                        foreach (Incidencias incidencia in IncidenciasList)
                                        {
                                            incidencia.MostrarInformacion();
                                            Console.WriteLine("-----------------------------");
                                        }
                                        Console.ReadKey();
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
                            opcionReportes = ValidacionEntradas("REPORTES\n\n1. Entregas activas.\n2. Entregas finalizadas.\n3. Entregas canceladas.\n4. Entregas con incidencias.\n5. Repartidores disponibles.\n6. Repartidor con más entregas.\n7. Vehículo más utilizado.\n8. Cantidad de paquetes por tipo.\n9. Total de ingresos.\n10. Entrega con mayor costo.\n11. Volver al menú principal\n\nElija una opción: ", 1, 11, "Error: Opción inválida");

                            switch (opcionReportes)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("--- ENTREGAS ACTIVAS ---");
                                    int activas = 0;
                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.Estado != "Entregada" && ent.Estado != "Cancelada")
                                        {
                                            ent.MostrarInformacion();
                                            Console.WriteLine("------------------------");
                                            activas++;
                                        }
                                    }
                                    if (activas == 0) MostrarErrorAnimado("No hay entregas activas en este momento.");
                                    else Console.WriteLine($"Total de entregas activas: {activas}");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("--- ENTREGAS FINALIZADAS ---");
                                    int finalizadas = 0;
                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.Estado == "Entregada")
                                        {
                                            ent.MostrarInformacion();
                                            Console.WriteLine("------------------------");
                                            finalizadas++;
                                        }
                                    }
                                    if (finalizadas == 0) MostrarErrorAnimado("No hay entregas finalizadas.");
                                    else Console.WriteLine($"Total de entregas finalizadas: {finalizadas}");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("--- ENTREGAS CANCELADAS ---");
                                    int canceladas = 0;
                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.Estado == "Cancelada")
                                        {
                                            ent.MostrarInformacion();
                                            Console.WriteLine("------------------------");
                                            canceladas++;
                                        }
                                    }
                                    if (canceladas == 0) MostrarErrorAnimado("No hay entregas canceladas.");
                                    else Console.WriteLine($"Total de entregas canceladas: {canceladas}");
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("--- ENTREGAS CON INCIDENCIAS ---");
                                    int entregasConIncidenciasCount = 0;

                                    foreach (Entrega ent in Entregas)
                                    {
                                        if (ent.IncidenciasHistorial != null && ent.IncidenciasHistorial.Count > 0)
                                        {
                                            Console.WriteLine($"\nCódigo de Entrega: ENT-{ent.Codigo}");
                                            Console.WriteLine($"Estado actual de la entrega: {ent.Estado}");
                                            Console.WriteLine("Detalle de incidencias:");

                                            foreach (Incidencias inc in ent.IncidenciasHistorial)
                                            {
                                                Console.WriteLine($"  * Tipo: {inc.Tipo}");
                                                Console.WriteLine($"  * Descripción: {inc.Descripcion}");
                                                Console.WriteLine($"  * Estado de la incidencia: {inc.Estado}");
                                                Console.WriteLine($"  * Acción tomada: {inc.AccionTomada}");
                                            }
                                            Console.WriteLine("------------------------");
                                            entregasConIncidenciasCount++;
                                        }
                                    }

                                    if (entregasConIncidenciasCount == 0)
                                    {
                                        MostrarErrorAnimado("No hay entregas con incidencias registradas.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\nTotal de entregas con incidencias: {entregasConIncidenciasCount}");
                                    }
                                    Console.ReadKey();
                                    break;

                                case 5:
                                    Console.Clear();
                                    if (Repartidores.Count == 0)
                                    {
                                        MostrarErrorAnimado("Sin repartidores registrados aún.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("--- REPARTIDORES DISPONIBLES ---");
                                        int contadorRepartidoresActivos = 0;
                                        for (int i = 0; i < Repartidores.Count; i++)
                                        {
                                            if (Repartidores[i].Disponibilidad == "Disponible")
                                            {
                                                Console.WriteLine($"- {Repartidores[i].NombreCompleto} (Código: REP-{Repartidores[i].Codigo})");
                                                contadorRepartidoresActivos += 1;
                                            }
                                        }
                                        Console.WriteLine($"\nTotal disponibles: {contadorRepartidoresActivos}");
                                    }
                                    Console.ReadKey();
                                    break;

                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("--- REPARTIDOR CON MÁS ENTREGAS ---");
                                    if (Repartidores.Count == 0 || Entregas.Count == 0)
                                    {
                                        MostrarErrorAnimado("No hay datos suficientes para calcular.");
                                    }
                                    else
                                    {
                                        Repartidor topRepartidor = null;
                                        int maxEntregasRepartidor = -1;

                                        foreach (Repartidor rep in Repartidores)
                                        {
                                            int contadorEntregas = 0;
                                            foreach (Entrega ent in Entregas)
                                            {
                                                if (ent.RepartidorAsignado != null && ent.RepartidorAsignado.Codigo == rep.Codigo && ent.Estado == "Entregada")
                                                {
                                                    contadorEntregas++;
                                                }
                                            }

                                            if (contadorEntregas > maxEntregasRepartidor)
                                            {
                                                maxEntregasRepartidor = contadorEntregas;
                                                topRepartidor = rep;
                                            }
                                        }

                                        if (topRepartidor != null && maxEntregasRepartidor > 0)
                                        {
                                            Console.WriteLine($"El repartidor con más entregas completadas es: {topRepartidor.NombreCompleto}");
                                            Console.WriteLine($"Total de entregas: {maxEntregasRepartidor}");
                                        }
                                        else
                                        {
                                            MostrarErrorAnimado("Aún no hay entregas finalizadas asignadas a un repartidor.");
                                        }
                                    }
                                    Console.ReadKey();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("--- VEHÍCULO MÁS UTILIZADO ---");
                                    if (Entregas.Count == 0)
                                    {
                                        MostrarErrorAnimado("No hay datos de entregas para calcular");
                                    }
                                    else
                                    {
                                        Vehiculo topVehiculo = null;
                                        int maxUsoVehiculo = -1;

                                        List<Vehiculo> todosLosVehiculos = new List<Vehiculo>();
                                        todosLosVehiculos.AddRange(Automoviles);
                                        todosLosVehiculos.AddRange(Motocicletas);
                                        todosLosVehiculos.AddRange(Bicicletas);

                                        foreach (Vehiculo veh in todosLosVehiculos)
                                        {
                                            int contadorUso = 0;
                                            foreach (Entrega ent in Entregas)
                                            {
                                                if (ent.VehiculoAsignado != null && ent.VehiculoAsignado.Codigo == veh.Codigo)
                                                {
                                                    contadorUso++;
                                                }
                                            }

                                            if (contadorUso > maxUsoVehiculo)
                                            {
                                                maxUsoVehiculo = contadorUso;
                                                topVehiculo = veh;
                                            }
                                        }

                                        if (topVehiculo != null && maxUsoVehiculo > 0)
                                        {
                                            Console.WriteLine($"El vehículo más utilizado es: {topVehiculo.Marca} {topVehiculo.Modelo} (Código: VEH-{topVehiculo.Codigo})");
                                            Console.WriteLine($"Cantidad de veces asignado: {maxUsoVehiculo}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Aún no se han asignado vehículos a las entregas.");
                                        }
                                    }
                                    Console.ReadKey();
                                    break;

                                case 8:
                                    Console.Clear();
                                    Console.WriteLine("--- CANTIDAD DE PAQUETES POR TIPO ---");
                                    Console.WriteLine($"1. Documentos registrados:          {Documentos.Count}");
                                    Console.WriteLine($"2. Paquetes Estándar registrados:   {PaquetesEstandar.Count}");
                                    Console.WriteLine($"3. Paquetes Frágiles registrados:   {PaquetesFragiles.Count}");
                                    Console.WriteLine($"4. Productos Refrigerados:          {ProductosRefrigerados.Count}");

                                    int totalPaquetes = Documentos.Count + PaquetesEstandar.Count + PaquetesFragiles.Count + ProductosRefrigerados.Count;
                                    Console.WriteLine($"\nTotal general de paquetes en sistema: {totalPaquetes}");
                                    Console.ReadKey();
                                    break;

                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("--- TOTAL DE INGRESOS  ---");

                                    double SumaIngresosRecursiva(List<Entrega> lista, int indice)
                                    {
                                        if (indice >= lista.Count)
                                        {
                                            return 0;
                                        }

                                        double valorActual = (lista[indice].Estado == "Entregada") ? lista[indice].Total : 0;

                                        return valorActual + SumaIngresosRecursiva(lista, indice + 1);
                                    }

                                    if (Entregas.Count == 0)
                                    {
                                        MostrarErrorAnimado("No hay entregas en el sistema.");
                                    }
                                    else
                                    {
                                        double totalGanado = SumaIngresosRecursiva(Entregas, 0);
                                        Console.WriteLine($"El ingreso total por entregas FINALIZADAS es: Q{totalGanado:F2}");
                                    }

                                    Console.ReadKey();
                                    break;

                                case 10:
                                    Console.Clear();
                                    Console.WriteLine("--- ENTREGA CON MAYOR COSTO ---");
                                    if (Entregas.Count == 0)
                                    {
                                        MostrarErrorAnimado("No hay entregas registradas.");
                                    }
                                    else
                                    {
                                        Entrega entregaMayorCosto = null;
                                        double maxCosto = -1;

                                        foreach (Entrega ent in Entregas)
                                        {
                                            if (ent.Total > maxCosto)
                                            {
                                                maxCosto = ent.Total;
                                                entregaMayorCosto = ent;
                                            }
                                        }

                                        if (entregaMayorCosto != null)
                                        {
                                            Console.WriteLine("La entrega con el mayor costo es:");
                                            entregaMayorCosto.MostrarInformacion();
                                            Console.WriteLine($"Costo total de esta entrega: Q{entregaMayorCosto.Total:F2}");
                                        }
                                    }

                                    break;

                                case 11:
                                    break;
                            }
                        } while (opcionReportes != 11);

                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        break;
                }
            } while (opcion != 8);
        }
        static void CambiarEstadoPaquete<T>(List<T> listaPaquetes, string tipoPaquete) where T : Paquete
        {
            Console.Clear();
            int codigoBuscar = ValidacionEntradas($"Ingrese codigo de paquete: {tipoPaquete}", 1, int.MaxValue, "Codigo no encontrado");

            int indicePaquete = -1;
            for (int i = 0; i < listaPaquetes.Count; i++)
            {
                if (listaPaquetes[i].Codigo == codigoBuscar)
                {
                    indicePaquete = i;
                    break;
                }
            }
            if (indicePaquete == -1)
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
        static double CalcularTarifaBase(double peso, double distancia, string tipoPaquete, string tipoServicio)
        {
            double total;
            total = (peso * 3) + (distancia * 5);
            if (tipoServicio == "Prioritario")
            {
                total += 10;
            }
            else if (tipoServicio == "Urgente")
            {
                total += 20;
            }
            return total;
        }
    }
}

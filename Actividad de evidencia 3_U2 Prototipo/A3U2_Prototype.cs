using System;
using System.Collections.Generic;

namespace PrototypeExamenes
{
    // ==============================
    // PROTOTIPO ABSTRACTO
    // ==============================
    abstract class ExamenPrototype
    {
        public abstract ExamenPrototype Clonar();
    }

    // ==============================
    // CLASE BASE
    // ==============================
    abstract class Examen : ExamenPrototype
    {
        // Datos protegidos
        protected string claveMateria;
        protected string nombreAsignatura;
        protected string docente;
        protected string grupo;
        protected string salon;
        protected string carrera;
        protected int cantidadReactivos;
        protected int duracionMinutos;
        protected string tipoExamen;
        protected DateTime fechaAplicacion;

        public Examen(
            string claveMateria,
            string nombreAsignatura,
            string docente,
            string grupo,
            string salon,
            string carrera,
            int cantidadReactivos,
            int duracionMinutos,
            string tipoExamen,
            DateTime fechaAplicacion)
        {
            this.claveMateria = claveMateria;
            this.nombreAsignatura = nombreAsignatura;
            this.docente = docente;
            this.grupo = grupo;
            this.salon = salon;
            this.carrera = carrera;
            this.cantidadReactivos = cantidadReactivos;
            this.duracionMinutos = duracionMinutos;
            this.tipoExamen = tipoExamen;
            this.fechaAplicacion = fechaAplicacion;
        }

        public void CambiarDocente(string nuevoDocente)
        {
            docente = nuevoDocente;
        }

        public void CambiarGrupo(string nuevoGrupo)
        {
            grupo = nuevoGrupo;
        }

        public void CambiarSalon(string nuevoSalon)
        {
            salon = nuevoSalon;
        }

        public void CambiarFecha(DateTime nuevaFecha)
        {
            fechaAplicacion = nuevaFecha;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Clave de materia : {claveMateria}");
            Console.WriteLine($"Asignatura       : {nombreAsignatura}");
            Console.WriteLine($"Docente          : {docente}");
            Console.WriteLine($"Grupo            : {grupo}");
            Console.WriteLine($"Salón            : {salon}");
            Console.WriteLine($"Carrera          : {carrera}");
            Console.WriteLine($"Reactivos        : {cantidadReactivos}");
            Console.WriteLine($"Duración         : {duracionMinutos} min");
            Console.WriteLine($"Tipo de examen   : {tipoExamen}");
            Console.WriteLine($"Fecha aplicación : {fechaAplicacion:dd/MM/yyyy}");
        }

        public override ExamenPrototype Clonar()
        {
            return (ExamenPrototype)this.MemberwiseClone();
        }
    }

    // ==============================
    // 8 TIPOS DE EXÁMENES
    // ==============================

    class ExamenPatronesDiseno : Examen
    {
        protected string unidadEvaluada;

        public ExamenPatronesDiseno(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCC-1014", "Patrones de Diseño", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 25, 90, "Escrito", fechaAplicacion)
        {
            unidadEvaluada = "Patrones creacionales y estructurales";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Unidad evaluada  : {unidadEvaluada}");
        }
    }

    class ExamenBasesDatos : Examen
    {
        protected string motorBD;

        public ExamenBasesDatos(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCD-1025", "Bases de Datos", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 30, 100, "Teórico-Práctico", fechaAplicacion)
        {
            motorBD = "SQL Server";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Motor BD         : {motorBD}");
        }
    }

    class ExamenProgramacionOO : Examen
    {
        protected string lenguaje;

        public ExamenProgramacionOO(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCC-1007", "Programación Orientada a Objetos", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 20, 80, "Práctico", fechaAplicacion)
        {
            lenguaje = "C#";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Lenguaje         : {lenguaje}");
        }
    }

    class ExamenEstructuraDatos : Examen
    {
        protected string temaPrincipal;

        public ExamenEstructuraDatos(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCD-1015", "Estructura de Datos", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 28, 90, "Mixto", fechaAplicacion)
        {
            temaPrincipal = "Listas, pilas y colas";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tema principal   : {temaPrincipal}");
        }
    }

    class ExamenRedes : Examen
    {
        protected string practicaIncluida;

        public ExamenRedes(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCD-1021", "Redes de Computadoras", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 24, 85, "Teórico-Práctico", fechaAplicacion)
        {
            practicaIncluida = "Direccionamiento IP y subredes";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Práctica         : {practicaIncluida}");
        }
    }

    class ExamenIngenieriaSoftware : Examen
    {
        protected string metodologia;

        public ExamenIngenieriaSoftware(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCC-1010", "Ingeniería de Software", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 26, 95, "Escrito", fechaAplicacion)
        {
            metodologia = "SCRUM y UML";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Metodología      : {metodologia}");
        }
    }

    class ExamenSistemasOperativos : Examen
    {
        protected string sistemaBase;

        public ExamenSistemasOperativos(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("SCD-1003", "Sistemas Operativos", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 22, 90, "Práctico", fechaAplicacion)
        {
            sistemaBase = "Linux";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Sistema base     : {sistemaBase}");
        }
    }

    class ExamenMatematicasDiscretas : Examen
    {
        protected string bloque;

        public ExamenMatematicasDiscretas(
            string docente,
            string grupo,
            string salon,
            DateTime fechaAplicacion)
            : base("ACF-0903", "Matemáticas Discretas", docente, grupo, salon,
                  "Ing. en Sistemas Computacionales", 35, 100, "Escrito", fechaAplicacion)
        {
            bloque = "Lógica proposicional y teoría de conjuntos";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Bloque           : {bloque}");
        }
    }

    // ==============================
    // MAIN
    // ==============================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PATRÓN PROTOTIPO - EXÁMENES\n");

            // Prototipos base
            ExamenPatronesDiseno examenPatronesBase =
                new ExamenPatronesDiseno("Mtro. Carlos López", "5A", "A-101", new DateTime(2026, 3, 15));

            ExamenBasesDatos examenBDBase =
                new ExamenBasesDatos("Dra. Ana Martínez", "4B", "B-202", new DateTime(2026, 3, 16));

            ExamenProgramacionOO examenPOOBase =
                new ExamenProgramacionOO("Ing. José Ramírez", "3A", "LAB-1", new DateTime(2026, 3, 17));

            ExamenEstructuraDatos examenEDBase =
                new ExamenEstructuraDatos("Mtra. Laura Gómez", "3B", "C-103", new DateTime(2026, 3, 18));

            ExamenRedes examenRedesBase =
                new ExamenRedes("Ing. Daniel Torres", "6A", "LAB-REDES", new DateTime(2026, 3, 19));

            ExamenIngenieriaSoftware examenISBase =
                new ExamenIngenieriaSoftware("Mtro. Pedro Sánchez", "7A", "D-104", new DateTime(2026, 3, 20));

            ExamenSistemasOperativos examenSOBase =
                new ExamenSistemasOperativos("Ing. Rosa Hernández", "5B", "LAB-2", new DateTime(2026, 3, 21));

            ExamenMatematicasDiscretas examenMDBase =
                new ExamenMatematicasDiscretas("Mtra. Elena Ruiz", "1A", "E-105", new DateTime(2026, 3, 22));

            // Clonaciones: mismo examen, otro grupo o docente
            ExamenPatronesDiseno examenPatronesClon1 =
                (ExamenPatronesDiseno)examenPatronesBase.Clonar();
            examenPatronesClon1.CambiarGrupo("5B");
            examenPatronesClon1.CambiarSalon("A-102");
            examenPatronesClon1.CambiarFecha(new DateTime(2026, 3, 16));

            ExamenPatronesDiseno examenPatronesClon2 =
                (ExamenPatronesDiseno)examenPatronesBase.Clonar();
            examenPatronesClon2.CambiarGrupo("5C");
            examenPatronesClon2.CambiarDocente("Mtra. Patricia Vega");
            examenPatronesClon2.CambiarSalon("A-103");
            examenPatronesClon2.CambiarFecha(new DateTime(2026, 3, 17));

            ExamenBasesDatos examenBDClon =
                (ExamenBasesDatos)examenBDBase.Clonar();
            examenBDClon.CambiarGrupo("4C");
            examenBDClon.CambiarSalon("B-203");

            ExamenProgramacionOO examenPOOClon =
                (ExamenProgramacionOO)examenPOOBase.Clonar();
            examenPOOClon.CambiarGrupo("3C");
            examenPOOClon.CambiarDocente("Ing. Mario Castro");

            ExamenRedes examenRedesClon =
                (ExamenRedes)examenRedesBase.Clonar();
            examenRedesClon.CambiarGrupo("6B");
            examenRedesClon.CambiarSalon("LAB-REDES-2");

            // Lista general
            List<Examen> examenes = new List<Examen>
            {
                examenPatronesBase,
                examenPatronesClon1,
                examenPatronesClon2,
                examenBDBase,
                examenBDClon,
                examenPOOBase,
                examenPOOClon,
                examenEDBase,
                examenRedesBase,
                examenRedesClon,
                examenISBase,
                examenSOBase,
                examenMDBase
            };

            foreach (Examen examen in examenes)
            {
                examen.MostrarInformacion();
                Console.WriteLine();
            }

            Console.WriteLine("Se generaron exámenes a partir de prototipos base.");
        }
    }
}
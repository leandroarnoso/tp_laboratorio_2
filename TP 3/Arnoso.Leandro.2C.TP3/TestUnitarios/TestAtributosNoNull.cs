using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class TestAtributosNoNull
    {
        /// <summary>
        /// Verifica que los atributos de un instructor no sean null.
        /// </summary>
        [TestMethod]
        public void TestAtributosInstructorNoNull()
        {
            Instructor i = new Instructor(1, "Juan", "Perez", "34339210", Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(i.Nombre);
            Assert.IsNotNull(i.Apellido);
            Assert.IsNotNull(i.DNI);
            Assert.IsNotNull(i.Nacionalidad);
        }

        /// <summary>
        /// Verifica que los atributos de una jornada no sean null.
        /// </summary>
        [TestMethod]
        public void TestAtributosJornadaNoNull()
        {
            Instructor i = new Instructor(1, "Juan", "Perez", "34339210", Persona.ENacionalidad.Argentino);
            Jornada j = new Jornada(Gimnasio.EClases.Natacion, i);

            Assert.IsNotNull(j.Alumnos);
            Assert.IsNotNull(j.Clase);
            Assert.IsNotNull(j.Instructor);
        }

        /// <summary>
        /// Verifica que los atributos de un gimnasio no sean null.
        /// </summary>
        [TestMethod]
        public void TestAtributosGimnasioNoNull()
        {
            Gimnasio g = new Gimnasio();

            Assert.IsNotNull(g.Alumnos);
            Assert.IsNotNull(g.Instrcutores);
            Assert.IsNotNull(g.Jornadas);
        }
    }
}

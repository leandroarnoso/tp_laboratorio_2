using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestDni
    {
        /// <summary>
        /// Verifica que un dni valido se guarde correctamente en el atributo dni y que
        /// uno invalido lanze la excepcion correspondiente.
        /// </summary>
        [TestMethod]
        public void TestCaracteresDni()
        {
            try
            {
                Instructor i1 = new Instructor(1, "Juan", "Perez", "34339210", Persona.ENacionalidad.Argentino);
                Assert.AreEqual(i1.DNI, 34339210);
                Instructor i2 = new Instructor(1, "Juan", "Perez", "3433921o", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Verifica que un DNI fuera de rango lanze la excepcion correspondiente.
        /// </summary>
        [TestMethod]
        public void TestLimitesDniPorNacionalidad()
        {
            try
            {
                Instructor i2 = new Instructor(1, "Juan", "Perez", "0", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            try
            {
                Instructor i = new Instructor(1, "Juan", "Perez", "90000000", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            try
            {
                Instructor i = new Instructor(1, "Juan", "Perez", "89999999", Persona.ENacionalidad.Extranjero);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            try
            {
                Instructor i = new Instructor(1, "Juan", "Perez", "1000000000", Persona.ENacionalidad.Extranjero);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
    }
}

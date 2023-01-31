using Application.Serivce;
using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class SorteioTests
    {
        [TestMethod]
        public void ValidaRegras()
        {
            List<Pessoas> pessoas = new List<Pessoas>();

            pessoas.Add(new Pessoas(){ Nome = "eduardo" , CPF = "45049556893", Data_Nascimento = DateTime.Parse("08/03/1950"), CID = null, Cota = "IDOSO", Renda = "3000.00"});
            pessoas.Add(new Pessoas() { Nome = "fernando", CPF = "45049545213", Data_Nascimento = DateTime.Parse("08/03/1950"), CID = null, Cota = "IDOSO", Renda = "3000.00" });

            Assert.IsNotNull(SorteioService.ValidaRegras(pessoas));
        }

        [TestMethod]
        public void GerarIdosoVencedor()
        {
            List<string> cpfs = new List<string>();

            cpfs.Add("45849556893");
            cpfs.Add("45049545213");

            Assert.IsNotNull(SorteioService.GerarIdosoVencedor(cpfs.ToArray()));
        }

        [TestMethod]
        public void GerarDeficienteVencedor()
        {
            List<string> cpfs = new List<string>();

            cpfs.Add("45849556893");
            cpfs.Add("45049545213");

            Assert.IsNotNull(SorteioService.GerarDeficienteVencedor(cpfs.ToArray()));
        }

        [TestMethod]
        public void GerarGeralVencedor()
        {
            List<string> cpfs = new List<string>();

            cpfs.Add("45849556893");
            cpfs.Add("45049545213");

            Assert.IsNotNull(SorteioService.GerarGeralVencedor(cpfs.ToArray()));
        }
    }
}

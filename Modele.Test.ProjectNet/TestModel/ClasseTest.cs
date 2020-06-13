using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BusinessLayer.ProjectNet.Commands;
using BusinessLayer.ProjectNet.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ProjectNet;
using Model.ProjectNet.Entities;

namespace Modele.Test.ProjectNet.TestModel
{
    [TestClass]
    public class ClasseTest
    {
        private readonly ProNetDbContext _context;
        private ClasseCommand comm;
        private ClasseQuery query;

        public ClasseTest()
        {
            _context = new ProNetDbContext();
            comm = new ClasseCommand(_context);
            query = new ClasseQuery(_context);

        }

        [TestMethod]
        public void TestAddClasse()
        {
            //ARRANGE
            Classe newClasse = new Classe
            {
                Niveau = "6e",
                NomEtablissement = "Collège Jean Moulin"
            };


            //ACT
            comm.Ajouter(newClasse);
            Classe classeGotten = _context.Classes.FirstOrDefault(c => c.NomEtablissement == "Collège Jean Moulin" && c.Niveau == "6e");

            //ASSERT
            Assert.IsTrue(classeGotten.Niveau == newClasse.Niveau);
            Assert.IsTrue(classeGotten.NomEtablissement == newClasse.NomEtablissement);
        }

        [TestMethod]
        public void TestUpdateClasse()
        {
            //ARRANGE
            Classe myClass = query.GetById(1).First();
            string name = myClass.NomEtablissement;
            string nomEtablissement = "Mon etablissement modifié";
            myClass.NomEtablissement = nomEtablissement;

            //ACT
            comm.Modifier(myClass);
            Classe classGotten = query.GetById(1).First();

            //ASSERT
            Assert.AreEqual(classGotten.NomEtablissement, nomEtablissement);
        }

        [TestMethod]
        public void TestDeleteClasse()
        {
            //ARRANGE
            Classe myClasse = new Classe
            {
                Niveau = "CE2",
                NomEtablissement = "Ecole Primaire qui dégoûte"
            };
            _context.Classes.Add(myClasse);
            _context.SaveChanges();

            Classe classeGotten = _context.Classes.FirstOrDefault(c => c.NomEtablissement == "Ecole Primaire qui dégoûte" && c.Niveau == "CE2");


            //ACT
            comm.Supprimer(classeGotten.Id);

            //ASSERT
            Assert.IsNull(_context.Classes.FirstOrDefault(c => c.NomEtablissement == "Ecole Primaire qui dégoûte" && c.Niveau == "CE2"));
        }

        [TestMethod]
        public void TestGetAllClasse()
        {
            //ARRANGE
            _context.Classes.Add(new Classe { Niveau = "CE2", NomEtablissement = "Ecole Primaires de ses morts" });
            _context.Classes.Add(new Classe { Niveau = "CE1", NomEtablissement = "Ecole Primaires de ses morts" });
            _context.Classes.Add(new Classe { Niveau = "CP", NomEtablissement = "Ecole Primaires de ses morts" });
            _context.SaveChanges();
            //ACT
            List<Classe> classes = query.GetAll().ToList();
            //ASSERT
            Assert.IsTrue(classes.Count > 3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MVC1.Controllers
{
    public class VehiculoController : Controller
    {

        Contexto db = new Contexto();

        public class VehiculoTotal
        {
            public string Nom_marca { get; set; }
            public string Nom_serie { get; set; }
            public string Matricula { get; set; }
            public string Color { get; set; }
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            ViewBag.SerieID = new SelectList(db.Series, "ID", "Nom_serie");
            ViewBag.ExtraList = new MultiSelectList(db.Extras, "ID", "Tipo_extra");
            return View();
        }

        public ActionResult Listado()
        {
            ViewBag.nomMarca = db.Marcas.ToList();
            var vehiculos = db.Vehiculos.Include(a => a.Serie);
            return View(vehiculos.ToList());
        }

        public ActionResult ListadoSelectivo(int MarcaId = 1, int SerieId = 0)
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "ID", "Nom_marca");
            ViewBag.SerieId = new SelectList(db.Series.Where(s => s.MarcaID == MarcaId).OrderBy(s => s.Nom_serie), "ID", "Nom_serie");
            var vehiculos = db.Vehiculos.Where(v => v.SerieID == SerieId).ToList();

            return View(vehiculos);
        }

        public ActionResult Listado2()
        {
            db.Database.SqlQuery<VehiculoTotal>("getSeriesVehiculos").ToList();
            return View();
        }

        public ActionResult ListadoPorColor(string color="")
        {
            ViewBag.color = new SelectList(db.Vehiculos.Select(v => new { Color = v.Color }).Distinct(), "Color", "Color");
            var lista = db.Database.SqlQuery<VehiculoTotal>("getVehiculosPorColor @ColorSel", new SqlParameter("@ColorSel", color)).ToList();
            return View(lista);
        }

        public ActionResult Busqueda(string busca="")
        {
            var lista = (from p in db.Vehiculos.Include(a => a.Serie) where p.Matricula.Contains(busca) select p).ToList();
            return View(lista);
        }

        public ActionResult Busqueda2(string Matricula = "")
        {
            ViewBag.Matricula = new SelectList(db.Vehiculos, "Matricula", "Matricula");
            var lista = (from p in db.Vehiculos.Include(a => a.Serie) where p.Matricula==Matricula select p).ToList();
            return View(lista);
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            var vehiculo = db.Vehiculos.Include(b => b.Serie).FirstOrDefault(c => c.ID == id);
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create(VehiculoModelo vehiculo)
        {
            try
            {
                using (var bd = new Contexto())
                {
                    bd.Vehiculos.Add(vehiculo);
                    foreach(int extra in vehiculo.ExtrasSeleccionados)
                    {
                        var obj = new VehiculoExtrasModelo() { extraID = extra, vehiculoID = vehiculo.ID };
                        bd.VehiculosExtras.Add(obj);
                    }

                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int id)
        {
            var vehiculo = db.Vehiculos.Find(id);
            ViewBag.SerieID = new SelectList(db.Series, "ID", "Nom_serie", vehiculo.SerieID);
            
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehiculoModelo coche)
        {
            try
            {
                VehiculoModelo vehiculo = db.Vehiculos.SingleOrDefault(v => v.ID == id);
                vehiculo.Matricula = coche.Matricula;
                vehiculo.Color = coche.Color;
                vehiculo.SerieID = coche.SerieID;
                db.SaveChanges();
                return RedirectToAction("Listado");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int id)
        {
            var vehiculo = db.Vehiculos.Include(b => b.Serie).FirstOrDefault(c => c.ID == id);
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var vehiculo = db.Vehiculos.Find(id);
                db.Vehiculos.Remove(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Listado");
            }
            catch
            {
                return View();
            }
        }
    }
}

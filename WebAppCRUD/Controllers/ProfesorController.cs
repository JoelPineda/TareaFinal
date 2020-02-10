using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCRUD.Models.ViewModel;
using WebAppCRUD.Models;
namespace WebAppCRUD.Controllers
{
    public class ProfesorController : Controller
    {
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (EscuelaEntities db = new EscuelaEntities())
            {
                lst = (from d in db.Profesores
                       select new ListTablaViewModel
                       {
                           Matricula = d.Id,
                           Nombre = d.Nombre,
                           Cedula = d.Cedula,
                           Apellido = d.Apellido,
                           Edad = d.Edad,
                           Genero = d.Genero,
                           Telefono = d.Telefono,
                           Fecha_Nacimiento = d.Fecha_Nacimiento,
                           Nacionalidad = d.Nacionalidad,

                           Email = d.E_mail
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo_Maestro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo_Maestro(TablaViewModel model)
        {

            if (ModelState.IsValid)
            {
                using (EscuelaEntities db = new EscuelaEntities())
                {
                    var oTable = new Profesores();
                    oTable.Nombre = model.Nombre;
                    oTable.Apellido = model.Apellido;
                    oTable.Edad = model.Edad;
                    oTable.Genero = model.Genero;
                    oTable.Fecha_Nacimiento = model.Fecha_Nacimiento;
                    oTable.Nacionalidad = model.Nacionalidad;
                    oTable.Telefono = model.Telefono;
                    oTable.Cedula = model.Cedula;
                    oTable.E_mail = model.Email;
                    oTable.Id = model.Matricula;
                    db.Profesores.Add(oTable);
                    db.SaveChanges();
                }
                return Redirect("~/Profesor/");
            }
            return View(model);
        }
        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (EscuelaEntities db = new EscuelaEntities())
            {
                var oTabla = db.Profesores.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Apellido = oTabla.Apellido;
                model.Edad = oTabla.Edad;
                model.Cedula = oTabla.Cedula;
                model.Genero = oTabla.Genero;
                model.Fecha_Nacimiento = oTabla.Fecha_Nacimiento;
                model.Nacionalidad = oTabla.Nacionalidad;
                model.Telefono = oTabla.Telefono;
                model.Email = oTabla.E_mail;
                model.Matricula = oTabla.Id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {

            if (ModelState.IsValid)
            {
                using (EscuelaEntities db = new EscuelaEntities())
                {
                    var oTable = db.Profesores.Find(model.Matricula);
                    oTable.Id = model.Matricula;
                    oTable.Nombre = model.Nombre;
                    oTable.Apellido = model.Apellido;
                    oTable.Edad = model.Edad;
                    oTable.Genero = model.Genero;
                    oTable.Cedula = model.Cedula;
                    oTable.Fecha_Nacimiento = model.Fecha_Nacimiento;
                    oTable.Nacionalidad = model.Nacionalidad;
                    oTable.Telefono = model.Telefono;
                    oTable.E_mail = model.Email;
                    db.Entry(oTable).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("~/Profesor/");
            }
            return View(model);

        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {

            using (EscuelaEntities db = new EscuelaEntities())
            {

                var oTabla = db.Profesores.Find(Id);
                db.Profesores.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Profesor/");
        }
    }
}
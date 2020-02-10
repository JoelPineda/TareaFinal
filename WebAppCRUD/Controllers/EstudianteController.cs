using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCRUD.Models;
using WebAppCRUD.Models.ViewModel;
namespace WebAppCRUD.Controllers
{
    public class EstudianteController : Controller
    {
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (EscuelaEntities db = new EscuelaEntities())
            {
                lst = (from d in db.Estudiante
                       select new ListTablaViewModel
                       {
                           Matricula = d.Matricula,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Edad = d.Edad,
                           Genero = d.Genero,
                           Fecha_Nacimiento = d.Fecha_Nacimiento,
                           Nacionalidad = d.Nacionalidad,
                           Telefono = d.Telefono,
                           Email = d.E_mail
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {

            if (ModelState.IsValid)
            {
                using (EscuelaEntities db = new EscuelaEntities())
                {
                    var oTable = new Estudiante();
                    oTable.Nombre = model.Nombre;
                    oTable.Apellido = model.Apellido;
                    oTable.Edad = model.Edad;
                    oTable.Genero = model.Genero;
                    oTable.Fecha_Nacimiento = model.Fecha_Nacimiento;
                    oTable.Nacionalidad = model.Nacionalidad;
                    oTable.Telefono = model.Telefono;
                    oTable.E_mail = model.Email;
                    oTable.Matricula = model.Matricula;
                    db.Estudiante.Add(oTable);
                    db.SaveChanges();
                }
                return Redirect("~/Estudiante/");
            }
            return View(model);



        }
        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (EscuelaEntities db = new EscuelaEntities())
            {
                var oTabla = db.Estudiante.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Apellido = oTabla.Apellido;
                model.Edad = oTabla.Edad;
                model.Genero = oTabla.Genero;
                model.Fecha_Nacimiento = oTabla.Fecha_Nacimiento;
                model.Nacionalidad = oTabla.Nacionalidad;
                model.Telefono = oTabla.Telefono;
                model.Email = oTabla.E_mail;
                model.Matricula = oTabla.Matricula;
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
                    var oTable = db.Estudiante.Find(model.Matricula);
                    oTable.Matricula = model.Matricula;
                    oTable.Nombre = model.Nombre;
                    oTable.Apellido = model.Apellido;
                    oTable.Edad = model.Edad;
                    oTable.Genero = model.Genero;
                    oTable.Fecha_Nacimiento = model.Fecha_Nacimiento;
                    oTable.Nacionalidad = model.Nacionalidad;
                    oTable.Telefono = model.Telefono;
                    oTable.E_mail = model.Email;
                    db.Entry(oTable).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("~/Estudiante/");
            }
            return View(model);



        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {

            using (EscuelaEntities db = new EscuelaEntities())
            {

                var oTabla = db.Estudiante.Find(Id);
                db.Estudiante.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Estudiante/");
        }
    }
}
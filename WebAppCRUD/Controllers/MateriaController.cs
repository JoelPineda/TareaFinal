using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCRUD.Models;
using WebAppCRUD.Models.ViewModel;
namespace WebAppCRUD.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (EscuelaEntities db = new EscuelaEntities())
            {
                lst = (from d in db.Asignaturas
                       select new ListTablaViewModel
                       {
                           Matricula = d.Codigo,
                           Nombre = d.Nombre_Materia,

                       }).ToList();
            }
            return View(lst);
        }
        //public ActionResult Nuevo()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Nuevo(TablaViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        using (EscuelaEntities db = new EscuelaEntities())
        //        {
        //            var oTable = new Asignaturas();
        //            oTable.Nombre_Materia = model.Nombre;
                    
        //            oTable.Codigo = model.Matricula;
        //            db.Asignaturas.Add(oTable);
        //            db.SaveChanges();
        //        }
        //        return Redirect("~/Materia/");
        //    }
        //    return View(model);
        //}
        //public ActionResult Editar(int Id)
        //{
        //    TablaViewModel model = new TablaViewModel();
        //    using (EscuelaEntities db = new EscuelaEntities())
        //    {
        //        var oTabla = db.Asignaturas.Find(Id);
        //        model.Nombre = oTabla.Nombre_Materia;
               
        //        model.Matricula = oTabla.Codigo;
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Editar(TablaViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        using (EscuelaEntities db = new EscuelaEntities())
        //        {
        //            var oTable = db.Asignaturas.Find(model.Matricula);
        //            oTable.Codigo = model.Matricula;
        //            oTable.Nombre_Materia = model.Nombre;                  
        //            db.Entry(oTable).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return Redirect("~/Materia/");
        //    }
        //    return View(model);

        //}
        //[HttpGet]
        //public ActionResult Eliminar(int Id)
        //{

        //    using (EscuelaEntities db = new EscuelaEntities())
        //    {

        //        var oTabla = db.Asignaturas.Find(Id);
        //        db.Asignaturas.Remove(oTabla);
        //        db.SaveChanges();
        //    }
        //    return Redirect("~/Materia/");
        //}
    }

}
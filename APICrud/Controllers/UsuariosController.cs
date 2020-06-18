using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICrud.Models.Contexto;
using APICrud.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APICrud.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto _contexto;

        public UsuariosController(Contexto contexto)
        {
            _contexto = contexto;
        }


        #region INDEX

        public IActionResult Index()
        {
            CarregaTipoUsuario();
            var lista = _contexto.Usuario.ToList();
            return View(lista);
        }

        #endregion

        #region CREATE

        [HttpGet]
        public IActionResult Create()
        {
            CarregaTipoUsuario();
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }

            CarregaTipoUsuario();
            return View(usuario);
        }

        #endregion

        #region EDIT

        [HttpGet] //Carregar na tela
        public IActionResult Edit(int id)
        {
            var usuario = _contexto.Usuario.Find(id);

            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost] // Enviar para o banco de dados
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                CarregaTipoUsuario();
                return View(usuario);
            }
        }

        #endregion

        #region DELETE

        [HttpGet] //Carregar na tela
        public IActionResult Delete(int id)
        {
            var usuario = _contexto.Usuario.Find(id);
            CarregaTipoUsuario();
            return View(usuario);
        }


        [HttpPost] //Mandar pro banco
        public IActionResult Delete(Usuario _usuario)
        {
            var usuario = _contexto.Usuario.Find(_usuario.Id);

            if (usuario != null)
            {
                _contexto.Usuario.Remove(usuario);

                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        #endregion

        #region DETAILS

        [HttpGet]
        public IActionResult Details(int id)
        {
            var usuario = _contexto.Usuario.Find(id);
            CarregaTipoUsuario();
            return View(usuario);
        }

        #endregion

        #region VIEWBAG CARREGAR TIPO USUARIO

        public void CarregaTipoUsuario()
        {
            var ItensTipoUser = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text="Administrador"},
                new SelectListItem{ Value = "2", Text="Programador"},
                new SelectListItem{ Value = "3", Text="Advogado"},
                new SelectListItem{ Value = "4", Text="Tecnico"},
                new SelectListItem{ Value = "5", Text="Secretaria"},
                new SelectListItem{ Value = "6", Text="Colaborador"},
            };

            ViewBag.TiposUsuario = ItensTipoUser;
        }

        #endregion


    }
}
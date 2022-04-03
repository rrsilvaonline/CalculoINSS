using System;
using System.IO;
using System.Net;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using PrjWebInss.Models;

using INSS.Repository;
using INSS.Entities;
using INSS.Interfaces.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace PrjWebInss.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioController(FuncionarioRepository funcionarioRepository)
        {
            this._funcionarioRepository = funcionarioRepository;
        }

        // GET: FuncionarioController
        public ActionResult Index()
        {
            var vObject = _funcionarioRepository.GetAll();
            List<Models.Funcionario> vLst = new List<Models.Funcionario>();
            foreach (var item in vObject)
            {
                Models.Funcionario model = new Models.Funcionario();
                model.ID = item.ID;
                model.Nome = item.Nome;
                model.Telefone = item.Telefone;
                model.Email = item.Email;
                model.Salario = item.Salario;
                model.SalarioDescontado = item.SalarioDescontado;
                vLst.Add(model);
                model = null;
            }
            return View(vLst);
        }

        // GET: FuncionarioController/Details/5
        public ActionResult Details(int id)
        {
            PrjWebInss.Models.Funcionario model = new Models.Funcionario();
            var vObject = _funcionarioRepository.GetObject(id);
            if (vObject != null)
            {
                model.ID = vObject.ID;
                model.Nome = vObject.Nome;
                model.Telefone = vObject.Telefone;
                model.Email = vObject.Email;
                model.Salario = vObject.Salario;
                model.SalarioDescontado = vObject.SalarioDescontado;
            }
            return View(model);
        }

        // GET: FuncionarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrjWebInss.Models.Funcionario model)
        {
            string messages = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        INSS.Entities.Funcionario vFunc = new INSS.Entities.Funcionario();
                        vFunc.ID = 0;
                        vFunc.Nome = model.Nome;
                        vFunc.Email = model.Email;
                        vFunc.Telefone = model.Telefone;
                        vFunc.Salario = model.Salario;
                        vFunc.SalarioDescontado = model.SalarioDescontado;
                        var vObject = _funcionarioRepository.SaveObject(vFunc);

                        TempData["MsgSucessoFuncionario"] = "Funcionário incluido com sucesso!";

                    }
                    else
                    {
                        messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                        TempData["MsgError"] = messages;
                    }
                }
                else
                {
                    messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                    TempData["MsgError"] = messages;
                }
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: FuncionarioController/Edit/5
        public ActionResult Edit(int id)
        {
            PrjWebInss.Models.Funcionario model = new Models.Funcionario();
            var vObject = _funcionarioRepository.GetObject(id);
            if (vObject != null)
            {
                model.ID = vObject.ID;
                model.Nome = vObject.Nome;
                model.Telefone = vObject.Telefone;
                model.Email = vObject.Email;
                model.Salario = vObject.Salario;
                model.SalarioDescontado = vObject.SalarioDescontado;
            }
            return View(model);
        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrjWebInss.Models.Funcionario model)
        {
            string messages = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        INSS.Entities.Funcionario vFunc = new INSS.Entities.Funcionario();
                        vFunc.ID = model.ID;
                        vFunc.Nome = model.Nome;
                        vFunc.Email = model.Email;
                        vFunc.Telefone = model.Telefone;
                        vFunc.Salario = model.Salario;
                        vFunc.SalarioDescontado = model.SalarioDescontado;
                        var vObject = _funcionarioRepository.SaveObject(vFunc);

                        TempData["MsgSucessoFuncionario"] = "Funcionário incluido com sucesso!";

                    }
                    else
                    {
                        messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                        TempData["MsgError"] = messages;
                    }
                }
                else
                {
                    messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                    TempData["MsgError"] = messages;
                }
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: FuncionarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FuncionarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

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
using INSS.Services;
using INSS.Interfaces.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace PrjWebInss.Controllers
{
    public class ParametroAliquotaController : Controller
    {
        private readonly ParametroAliquotaRepository _parametroAliquotaRepository;
        private readonly FuncionarioRepository _funcionarioRepository;
        private readonly CalculadorInss _calculadorINSS;

        public ParametroAliquotaController(ParametroAliquotaRepository parametroAliquotaRepository, 
                                           FuncionarioRepository funcionarioRepository,
                                           CalculadorInss calculadorINSS)
        {
            this._parametroAliquotaRepository = parametroAliquotaRepository;
            this._funcionarioRepository = funcionarioRepository;
            this._calculadorINSS = calculadorINSS;
        }

        // GET: ParametroAliquotaController
        public ActionResult Index()
        {
            var vObject = _parametroAliquotaRepository.GetAll();
            List<Models.ParametroAliquota> vLst = new List<Models.ParametroAliquota>();
            foreach (var item in vObject)
            {
                Models.ParametroAliquota model = new Models.ParametroAliquota();
                model.Id = item.Id;
                model.SalCntrMin = item.SalCntrMin;
                model.SalCntrMax = item.SalCntrMax;
                model.ValAlqt = item.ValAlqt;
                model.Ano = item.Ano;
                vLst.Add(model);
                model = null;
            }
            return View(vLst);
        }

        // GET: ParametroAliquotaController/Details/5
        public ActionResult Details(int id)
        {
            PrjWebInss.Models.ParametroAliquota model = new Models.ParametroAliquota();
            var vObject = _parametroAliquotaRepository.GetObject(id);
            if (vObject != null)
            {
                model.Id = vObject.Id;
                model.SalCntrMin = vObject.SalCntrMin;
                model.SalCntrMax = vObject.SalCntrMax;
                model.ValAlqt = vObject.ValAlqt;
                model.Ano = vObject.Ano;
            }
            return View(model);
        }

        // GET: ParametroAliquotaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParametroAliquotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrjWebInss.Models.ParametroAliquota model)
        {
            string messages = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        INSS.Entities.ParametroAliquota vParametro = new INSS.Entities.ParametroAliquota();
                        vParametro.Id = 0;
                        vParametro.Ano = model.Ano;
                        vParametro.SalCntrMax = model.SalCntrMin;
                        vParametro.SalCntrMin= model.SalCntrMin;
                        vParametro.ValAlqt = model.ValAlqt;
                        var vObject = _parametroAliquotaRepository.SaveObject(vParametro);

                        TempData["MsgSucessoParametro"] = "Parametros de Alíquotas incluído com sucesso!";

                    }
                    else
                    {
                        messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                        TempData["MsgErrorParametro"] = messages;
                    }
                }
                else
                {
                    messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                    TempData["MsgErrorParametro"] = messages;
                }
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParametroAliquotaController/Edit/5
        public ActionResult Edit(int id)
        {
            PrjWebInss.Models.ParametroAliquota model = new Models.ParametroAliquota();
            var vObject = _parametroAliquotaRepository.GetObject(id);
            if (vObject != null)
            {
                model.Id = vObject.Id;
                model.SalCntrMin = vObject.SalCntrMin;
                model.SalCntrMax = vObject.SalCntrMax;
                model.ValAlqt = vObject.ValAlqt;
                model.Ano = vObject.Ano;
            }
            return View(model);
        }

        // POST: ParametroAliquotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrjWebInss.Models.ParametroAliquota model)
        {
            string messages = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        INSS.Entities.ParametroAliquota vParametro = new INSS.Entities.ParametroAliquota();
                        vParametro.Id = model.Id;
                        vParametro.Ano = model.Ano;
                        vParametro.SalCntrMax = model.SalCntrMin;
                        vParametro.SalCntrMin = model.SalCntrMin;
                        vParametro.ValAlqt = model.ValAlqt;
                        var vObject = _parametroAliquotaRepository.SaveObject(vParametro);

                        TempData["MsgSucessoParametro"] = "Parametros de Alíquotas incluído com sucesso!";

                    }
                    else
                    {
                        messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                        TempData["MsgErrorParametro"] = messages;
                    }
                }
                else
                {
                    messages = string.Join(Environment.NewLine, ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                    TempData["MsgErrorParametro"] = messages;
                }
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParametroAliquotaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult CalcularINSS(int id)
        {
            PrjWebInss.Models.Funcionario model = new Models.Funcionario();
            var vObject = this._funcionarioRepository.GetObject(id);
            if (vObject != null)
            {
                ViewBag.IdFuncionario = vObject.ID;
                ViewBag.NomeFuncionario = vObject.Nome;
                ViewBag.SalarioFuncionario = vObject.Salario;
            }
            return View();
        }

        // POST: ParametroAliquotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalcularINSS(DateTime data, PrjWebInss.Models.Funcionario Model)
        {
            try
            {
                if (Model != null)
                {
                    decimal vSalario = Model.Salario;
                    decimal valorDesconto = _calculadorINSS.CalcularDesconto(data, vSalario);

                    ViewBag.ValorDesconto = valorDesconto;
                    ViewBag.ValorDesconto = valorDesconto;
                    ViewBag.SalarioDescontado = Model.Salario - valorDesconto;
                    ViewBag.IdFuncionario = Model.ID;
                    ViewBag.NomeFuncionario = Model.Nome;
                }
                return RedirectToAction(nameof(CalcularINSS));
            }
            catch
            {
                return View();
            }
        }

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

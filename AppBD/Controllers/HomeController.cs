using AppBD.Database;
using AppBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBD.Controllers
{
    public class HomeController : Controller
    {
        readonly Consultas consultas = new Consultas();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Produtos()
        {
            ViewBag.TodosProdutos = consultas.ListarProdutos();
            return View();
        }

        public ActionResult ExcluirProduto(string produtoID)
        {
            consultas.ExcluirProduto(produtoID);
            return RedirectToAction("Produtos", "Home");
        }

        public ActionResult AtualizarProduto(int produtoID)
        {
            Produto produto = new Produto();
            produto = consultas.ConsultarProdutoPeloCodigo(produtoID);
            return View(produto);
        }

        public ActionResult CriarProduto()
        {
            return View("CriarProduto");
        }
        
        [HttpPost]
        public ActionResult RegistrarProduto(Produto produto)
        {
            consultas.CadastrarProduto(produto);
            return RedirectToAction("Produtos","Home");
        }

        [HttpPost]
        public ActionResult EditarProduto(Produto produto)
        {
            consultas.EditarProduto(produto);
            return RedirectToAction("Produtos", "Home");
        }

        public ActionResult Clientes()
        {
            ViewBag.TodosClientes = consultas.ListarClientes();
            return View();
        }

        public ActionResult ExcluirCliente(string clienteID)
        {
            consultas.ExcluirCliente(clienteID);
            return RedirectToAction("Clientes","Home");
        }

        [HttpPost]
        public ActionResult EditarCliente(Cliente cliente)
        {
            consultas.EditarCliente(cliente);
            return RedirectToAction("Clientes", "Home");
        }

        public ActionResult AtualizarCliente(int clienteID)
        {
            Cliente cliente = new Cliente();
            cliente = consultas.ConsultarClientePeloCodigo(clienteID);
            return View(cliente);
        }

        public ActionResult AdicionarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCliente(Cliente cliente)
        {
            consultas.CadastrarClientes(cliente);
            return RedirectToAction("Clientes", "Home");
        }

        public ActionResult Funcionarios()
        {
            ViewBag.TodosFuncionarios = consultas.ListarFuncionarios();
            return View();
        }

        public ActionResult AdicionarFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarFuncionario(Funcionario funcionario)
        {
            consultas.CadastrarFuncionarios(funcionario);
            return RedirectToAction("Funcionarios", "Home");
        }

        [HttpPost]
        public ActionResult EditarFuncionario(Funcionario funcionario)
        {
            consultas.EditarFuncionario(funcionario);
            return RedirectToAction("Funcionarios", "Home");
        }

        public ActionResult AtualizarFuncionario(int funcionarioID)
        {
            Funcionario funcionario = new Funcionario();
            funcionario = consultas.ConsultarFuncionarioPeloCodigo(funcionarioID);
            return View(funcionario);
        }

        public ActionResult ExcluirFuncionario(string funcionarioID)
        {
            consultas.ExcluirFuncionario(funcionarioID);
            return RedirectToAction("Funcionarios","Home");
        }
    }
}
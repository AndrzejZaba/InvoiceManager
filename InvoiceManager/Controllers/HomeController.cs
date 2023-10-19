using InvoiceManager.Models.Domains;
using InvoiceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id=1,
                    Title = "Fa/01/2023",
                    CreatedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    Value = 999,
                    Client = new Client {Name = "klient 1"}
                },
                new Invoice
                {
                    Id=2,
                    Title = "Fa/02/2023",
                    CreatedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    Value = 129,
                    Client = new Client {Name = "klient 2"}
                }
            };
            return View(invoices);
        }

        public ActionResult Invoice(int id = 0)
        {

            EditInvoiceViewModel vm = null;

            if (id == 0)
            {
                vm = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "Klient 1" } },
                    MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja Faktury",
                    Invoice = new Invoice()
                };
            }
            else
            {
                vm = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "Klient 1" } },
                    MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja Faktury",
                    Invoice = new Invoice
                    {
                        ClientId = 1,
                        Comments = "Uwagi...",
                        CreatedDate = DateTime.Now,
                        PaymentDate = DateTime.Now,
                        MethodOfPaymentId = 1,
                        Id = 1,
                        Value = 100,
                        Title = "FA/10/2023",
                        InvoicePositions = new List<InvoicePosition>
                        {
                            new InvoicePosition
                            {
                                Lp = 1,
                                Product = new Product { Name = "produkt 1"},
                                Quantity = 2,
                                Value = 50
                            },
                            new InvoicePosition
                            {
                                Lp = 2,
                                Product = new Product { Name = "produkt 2"},
                                Quantity = 4,
                                Value = 50
                            }
                        }
                    }
                };
            }
            


            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
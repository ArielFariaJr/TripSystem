using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using TripSystem.Models;
using TripSystem.ViewModels;

namespace TripSystem.Controllers
{
    public class HomeController : Controller
    {
        SystemEntities storeDB = new SystemEntities();

        [Authorize(Roles = "Administrator")]
        public ActionResult ListaEmbarque()
        {

            using (TripSystemEntities ts = new TripSystemEntities())
            {

                List<ListaDeEmbarque> Fields = new List<ListaDeEmbarque>();

                var result = (from c in ts.Excurcaos
                              join a in ts.Reservas
                              on c.ID equals a.ExcurcaoId
                              select new
                              {
                                  c.Titulo,
                                  c.LocalPartida,
                                  c.DataPartida,
                                  c.DataRetorno,
                                  a.Nome,
                                  a.SobreNome,
                                  a.Telefone,
                                  a.Idade,
                                  a.OrdemId,
                              }).ToList();

                foreach (var fc in result)
                {

                    ListaDeEmbarque epc = new ListaDeEmbarque();
                    epc.Titulo = fc.Titulo;
                    epc.LocalPartida = fc.LocalPartida;
                    epc.DataPartida = fc.DataPartida;
                    epc.DataRetorno = fc.DataRetorno;
                    epc.Nome = fc.Nome;
                    epc.SobreNome = fc.SobreNome;
                    epc.Telefone = fc.Telefone;
                    epc.Idade = fc.Idade;
                    epc.OrdemId = fc.OrdemId;

                    Fields.Add(epc);
                }

                return View("ListaEmbarque", Fields);

            }

        }

        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "ListaDeEmbarque.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Excurcaos> cm = new List<Excurcaos>();
            using (TripSystemEntities dc = new TripSystemEntities())
            {
                cm = dc.Excurcaos.ToList();
            }
            ReportDataSource rd = new ReportDataSource("MyDataset", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }

        public ActionResult Index()
        {
            // Get most popular albums
            var excurcoes = GetTopSellingAlbums(5);

            return View(excurcoes);
        }

        private List<Excurcao> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Excurcao
            .OrderByDescending(a => a.ItensOrdem.Count())
            .Take(count)
            .ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

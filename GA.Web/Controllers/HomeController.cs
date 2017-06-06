using System.IO;
using System.Web;
using System.Web.Mvc;

namespace GA.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            int arquivosSalvos = 0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase arquivo = Request.Files[i];
                
                if (arquivo.ContentLength > 0)
                {
                    var uploadPath = Server.MapPath("~/Content/Uploads");
                    string caminhoArquivo = Path.Combine(@uploadPath, Path.GetFileName(arquivo.FileName));

                    arquivo.SaveAs(caminhoArquivo);
                    arquivosSalvos++;
                }
            }

            return View();
        }
    }
}
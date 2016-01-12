using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconoFood.Product
{
    public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string nomeSession = "Imagem";
            if (context.Request["img"] == "1")
                nomeSession = string.Concat(nomeSession, "1");
            if (context.Request["img"] == "2")
                nomeSession = string.Concat(nomeSession, "2");
            if (context.Request["img"] == "3")
                nomeSession = string.Concat(nomeSession, "3");

            if (context.Session[nomeSession] != null)
            {
                EconoFood.ProdutoService.ProdutoImagem Imagem = (EconoFood.ProdutoService.ProdutoImagem)context.Session[nomeSession];

                context.Response.ContentType = "image/JPEG";
                if(Imagem.Imagem != null)
                    context.Response.BinaryWrite(Imagem.Imagem);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System.Collections.Generic;
using System;

namespace backend.Utils
{
    public class ListaNegraConversor
    {
          public Models.TbListaNegra ParaTabela(Models.Request.ListaNegraRequest request)
        {
            Models.TbListaNegra ln = new Models.TbListaNegra();
            ln.NmPessoa = request.Nome;
            ln.DsMotivo = request.Motivo;
            ln.DtInclusao = DateTime.Now;

            return ln;
        }

        public Models.Response.ListaNegraReponse ParaResponse(Models.TbListaNegra ln)
        {
            Models.Response.ListaNegraReponse resp =new Models.Response.ListaNegraReponse();
            resp.Id = ln.IdListaNegra;
            resp.Nome = ln.NmPessoa;
            resp.Motivo = ln.DsMotivo;
            resp.Inclusao = ln.DtInclusao;
            return resp;
        }

        public List<Models.Response.ListaNegraReponse> ParaResponse(List<Models.TbListaNegra> lns)
        {
            List<Models.Response.ListaNegraReponse> resp = new List<Models.Response.ListaNegraReponse>();
            foreach (Models.TbListaNegra item in lns)
            {
                resp.Add(
                    this.ParaResponse(item));
            }
            return resp;
        }

    }
    
}
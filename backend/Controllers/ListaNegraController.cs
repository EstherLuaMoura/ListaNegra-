using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ListaNegraController : ControllerBase
    {
        Business.ListaNegraBusiness business = new Business.ListaNegraBusiness();
        Utils.ListaNegraConversor conversor = new Utils.ListaNegraConversor();


        [HttpPost]
        public ActionResult<Models.Response.ListaNegraReponse> Inserir(Models.Request.ListaNegraRequest request)
        {
            try
            {
                Models.TbListaNegra ln = conversor.ParaTabela(request);
                business.Salvar(ln);

                Models.Response.ListaNegraReponse resp = conversor.ParaResponse(ln);
                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroReponse(404, ex.Message)
                );
            }
        }


        [HttpGet]
        public ActionResult<List<Models.Response.ListaNegraReponse>> Listar() 
        {
            try
            {
                List<Models.TbListaNegra> lns = business.Listar();
                if (lns.Count == 0)
                    return NotFound();

                List<Models.Response.ListaNegraReponse> resp = conversor.ParaResponse(lns);
                return resp;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroReponse(500, ex.Message)
                );
            }
        }



        
        [HttpGet("ping")]
        public string Ping() 
        {
            return "pong";
        }
    }
}
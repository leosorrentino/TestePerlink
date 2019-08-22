using System;
using System.Web;
using System.Web.Mvc;

namespace EP.CursoMVC5.Infra.CrossCuting.AspNetFilters
{                                      
    public class GlobalActionLogger : ActionFilterAttribute
    {
        // Após a execução....
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log de Auditoria

            if (filterContext.Exception != null)
            {
                //Manipular a EX
                //Injetar alguma LIB de tratamento de erro...
                //Gravar o Log do erro do BD
                //Email para o Admin
                //Retornar Cod. de erro amigavel
                
                // Sempre use ASYNC aqui dentro

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Konzole.InventorySystem.Providers.Interface;
using Konzole.InventorySystem.Entities;

namespace Konzole.InventorySystem.Web.Controllers.Api
{
    public class SetupApiController : ApiController
    {
        IUOMProvider _uomProvider = null;

        public SetupApiController(IUOMProvider uomProvider)
        {
            this._uomProvider = uomProvider;
        }


        public HttpResponseMessage GetList()
        {
            return this.BuildResponse(HttpStatusCode.OK, _uomProvider.GetList());
        }

        public HttpResponseMessage Get(int id)
        {
            return this.BuildResponse(HttpStatusCode.OK, _uomProvider.GetByUOMId(id));
        }

        public HttpResponseMessage Post(UOM uom)
        {
            if (_uomProvider.Save(uom))
            {
                var locationHeaderValue = "/api/SetupApi/" + uom.Id;
                return this.BuildResponse(HttpStatusCode.Created, uom, locationHeaderValue);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        public HttpResponseMessage Put(UOM uom)
        {
            if (_uomProvider.Save(uom))
            {
                return this.BuildResponse(HttpStatusCode.OK, uom);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }

    }
}

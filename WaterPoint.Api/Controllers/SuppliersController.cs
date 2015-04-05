﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Service.Interfaces;

namespace WaterPoint.Api.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var result = await _supplierService.ListAsync();

            return Ok<IEnumerable<SupplierContract>>(result);
        }
    }
}

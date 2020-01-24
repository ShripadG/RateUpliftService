using Microsoft.AspNetCore.Mvc;
using rateupliftservice.Models;
using rateupliftservice.Services;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
using ExcelDataReader;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.PlatformAbstractions;
using rateupliftservice.Processors;
using employeeservice.Common;

namespace rateupliftservice.Controllers
{
    /// <summary>
    /// This class contains methods for CRUD operations
    /// </summary>
    [Route("api/[controller]")]
    public class RateupliftController : Controller    
    {
        private readonly HtmlEncoder _htmlEncoder;
        private readonly ICloudantService _cloudantService;
        private readonly IHelper _helper;
        private readonly IPostRateupliftProcessor _postRateupliftProcessor;
        private readonly IPutRateupliftProcessor _putRateupliftProcessor;

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="htmlEncoder"></param>
        /// <param name="_postRateupliftProcessor"></param>
        /// <param name="_putRateupliftProcessor"></param>
        /// <param name="helper"></param>
        /// <param name="cloudantService"></param>
        public RateupliftController(HtmlEncoder htmlEncoder, IPostRateupliftProcessor postRateupliftProcessor, IPutRateupliftProcessor putRateupliftProcessor, IHelper helper,ICloudantService cloudantService = null)
        {
            _cloudantService = cloudantService;
            _helper = helper;
            _postRateupliftProcessor = postRateupliftProcessor;
            _putRateupliftProcessor = putRateupliftProcessor;
            _htmlEncoder = htmlEncoder;
        }
       
        /// <summary>
        /// Get all the records
        /// </summary>
        /// <returns>returns all records from database</returns>
        [HttpGet]
        public async Task<dynamic> Get()
        {
            if (_cloudantService == null)
            {
                return new string[] { "No database connection" };
            }
            else
            {
                return await _cloudantService.GetAllAsync(DBNames.rateuplift.ToString());
            }
        }

       
        /// <summary>
        /// Get record by ID
        /// </summary>
        /// <param name="id">ID to be selected</param>
        /// <returns>record for the given id</returns>
        [HttpGet("id")]
        public async Task<dynamic> GetByID(string id)
        {
            if (_cloudantService == null)
            {
                return new string[] { "No database connection" };
            }
            else
            {
                var response = await _cloudantService.GetByIdAsync(id, DBNames.rateuplift.ToString());
                return JsonConvert.DeserializeObject<Rateuplift>(response);
            }
        }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="rateuplift">New record to be created</param>
        /// <returns>status of the newly added record</returns>
        [HttpPost]
        public async Task<UpdateRateupliftResponse> Post([FromBody]RateupliftAddRequest rateuplift)
        {
            if (_postRateupliftProcessor != null)
            {                
                return await _postRateupliftProcessor.PostNewRateupliftRecord(rateuplift, _cloudantService);
            }
            else
            {
                return new UpdateRateupliftResponse();
            }
        }

        /// <summary>
        /// Update an existing record by giving _id and _rev values
        /// </summary>
        /// <param name="rateuplift">record to be updated for given _id and _rev</param>
        /// <returns>status of the record updated</returns>
        [HttpPut]
        public async Task<dynamic> Update([FromBody]Rateuplift rateuplift)
        {
            if (_postRateupliftProcessor != null)
            {
                return await _putRateupliftProcessor.PutExistingRateupliftRecord(rateuplift, _cloudantService);
            }
            else
            {
                return new string[] { "No database connection" };
            }
        }


        /// <summary>
        /// Delete the record for the given id
        /// </summary>
        /// <param name="id">record id to be deleted</param>
        /// <param name="rev">revision number of the record to be deleted</param>
        /// <returns>status of the record deleted</returns>
        [HttpDelete]
        public async Task<dynamic> Delete(string id, string rev)
        {
            if (_cloudantService != null)
            {
                return await _cloudantService.DeleteAsync(id, rev, DBNames.rateuplift.ToString());
                //Console.WriteLine("Update RESULT " + response);
                //return new string[] { employee.IBMEmailID, employee._id, employee._rev };
                //return JsonConvert.DeserializeObject<UpdateEmployeeResponse>(response.Result);
            }
            else
            {
                return new string[] { "No database connection" };
            }
        }

         
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rateupliftservice.Models;
using rateupliftservice.Services;
using Newtonsoft.Json;
using employeeservice.Common;

namespace rateupliftservice.Processors
{
    public class PostRateupliftProcessor : IPostRateupliftProcessor
    {
        public async Task<UpdateRateupliftResponse> PostNewRateupliftRecord(RateupliftAddRequest rateupliftAddRequest, ICloudantService cloudantService = null)
        {            
            if (cloudantService != null)
            {
                var response = await cloudantService.CreateAsync(rateupliftAddRequest, DBNames.rateuplift.ToString());
                return JsonConvert.DeserializeObject<UpdateRateupliftResponse>(response);
            }
            else
            {
                return new UpdateRateupliftResponse();
            }
        }
    }
}

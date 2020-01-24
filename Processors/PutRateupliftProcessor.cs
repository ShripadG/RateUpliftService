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
    public class PutRateupliftProcessor : IPutRateupliftProcessor
    {
        public async Task<UpdateRateupliftResponse> PutExistingRateupliftRecord(Rateuplift rateupliftUpdateRequest, ICloudantService cloudantService = null)
        {

            if (cloudantService != null)
            {
                var response = await cloudantService.UpdateAsync(rateupliftUpdateRequest, DBNames.rateuplift.ToString());
                return JsonConvert.DeserializeObject<UpdateRateupliftResponse>(response);
            }
            else
            {
                return new UpdateRateupliftResponse();
            }
        }
    }
}

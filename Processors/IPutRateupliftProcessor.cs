using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rateupliftservice.Models;
using rateupliftservice.Services;

namespace rateupliftservice.Processors
{
    public interface IPutRateupliftProcessor
    {
        Task<UpdateRateupliftResponse> PutExistingRateupliftRecord(Rateuplift rateupliftUpdateRequest, ICloudantService cloudantService = null);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rateupliftservice.Models;
using rateupliftservice.Services;

namespace rateupliftservice.Processors
{
    public interface IPostRateupliftProcessor
    {
        Task<UpdateRateupliftResponse> PostNewRateupliftRecord(RateupliftAddRequest rateupliftAddRequest, ICloudantService cloudantService = null);
    }
}

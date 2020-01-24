using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace rateupliftservice.Models
{
    public class RateupliftAddRequest
    {
       
        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }
        [JsonProperty("EmpName")]
        public string EmpName { get; set; }
        [JsonProperty("EmpNo")]
        public string EmpNo { get; set; }
        [JsonProperty("NBSCID")]
        public string NBSCID { get; set; }
        [JsonProperty("IBMRole")]
        public string IBMRole { get; set; }
        [JsonProperty("CurrentLoc")]
        public string CurrentLoc { get; set; }
        [JsonProperty("Squad")]
        public string Squad { get; set; }
        [JsonProperty("NewLoc")]
        public string NewLoc { get; set; }

        [JsonProperty("OldNBSRole")]
        public string OldNBSRole { get; set; }

        [JsonProperty("NewNBSRole")]
        public string NewNBSRole { get; set; }

        [JsonProperty("HCAMSrNo")]
        public string HCAMSrNo { get; set; }

        [JsonProperty("OnshoreLead")]
        public string OnshoreLead { get; set; }

        [JsonProperty("OffshoreLead")]
        public string OffshoreLead { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("NBSManager")]
        public string NBSManager { get; set; }

        [JsonProperty("DOJNBS")]
        public string DOJNBS { get; set; }

        [JsonProperty("NBSPractionerMngr")]
        public string NBSPractionerMngr { get; set; }
        [JsonProperty("DGArea")]
        public string DGArea { get; set; }
        [JsonProperty("DGLead")]
        public string DGLead { get; set; }

        [JsonProperty("ChangeEffFromDate")]
        public string ChangeEffFromDate { get; set; }
        [JsonProperty("ChangeEffToDate")]
        public string ChangeEffToDate { get; set; }

        [JsonProperty("BusinessJustification")]
        public string BusinessJustification { get; set; }
        [JsonProperty("ReferenceId")]
        public string ReferenceId { get; set; }
        [JsonProperty("Comments")]
        public string Comments { get; set; }
        [JsonProperty("ApprovalReceivedDate")]
        public string ApprovalReceivedDate { get; set; }

    }
}
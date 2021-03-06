using System.Threading;
using System.Threading.Tasks;

﻿namespace Stripe
{
    public class StripeDisputeService : StripeService
    {
        public StripeDisputeService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCharge { get; set; }
        public bool ExpandBalanceTransaction { get; set; }



        //Sync
        public virtual StripeDispute Update(string chargeId, string evidence = null, StripeRequestOptions requestOptions = null)
        {
            var url = this.ApplyAllParameters(null, $"{chargeId}/dispute", false);

            if (!string.IsNullOrEmpty(evidence))
                url = ParameterBuilder.ApplyParameterToUrl(url, "evidence", evidence);

            return Mapper<StripeDispute>.MapFromJson(
                Requestor.PostString(url,
                SetupRequestOptions(requestOptions))
            );
        }



        //Async
        public virtual async Task<StripeDispute> UpdateAsync(string chargeId, string evidence = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = this.ApplyAllParameters(null, $"{chargeId}/dispute", false);

            if (!string.IsNullOrEmpty(evidence))
                url = ParameterBuilder.ApplyParameterToUrl(url, "evidence", evidence);

            return Mapper<StripeDispute>.MapFromJson(
                await Requestor.PostStringAsync(url,
                SetupRequestOptions(requestOptions),
                cancellationToken)
            );
        }
    }
}

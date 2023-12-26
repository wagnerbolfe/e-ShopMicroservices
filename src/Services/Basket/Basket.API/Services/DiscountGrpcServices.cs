using Discount.gRPC.Protos;

namespace Basket.API.Services
{
    public class DiscountGrpcServices
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _serviceGrpc;

        public DiscountGrpcServices(DiscountProtoService.DiscountProtoServiceClient serviceGrpc)
        {
            _serviceGrpc = serviceGrpc ?? throw new ArgumentNullException(nameof(serviceGrpc));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest {  ProductName = productName };

            return await _serviceGrpc.GetDiscountAsync(discountRequest);
        }
    }
}

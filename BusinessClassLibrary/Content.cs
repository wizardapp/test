using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessClassLibrary
{
    public class BillingAddress
    {
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public object Line3 { get; set; }
        public string Gender { get; set; }
        public object CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public object HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string CountryIso { get; set; }
        public object Original { get; set; }
    }

    public class Content
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime? AcknowledgedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object MerchantComment { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public double SubTotalInclVat { get; set; }
        public double SubTotalVat { get; set; }
        public double ShippingCostsVat { get; set; }
        public double TotalInclVat { get; set; }
        public double TotalVat { get; set; }
        public double OriginalSubTotalInclVat { get; set; }
        public double OriginalSubTotalVat { get; set; }
        public double OriginalShippingCostsInclVat { get; set; }
        public double OriginalShippingCostsVat { get; set; }
        public double OriginalTotalInclVat { get; set; }
        public double OriginalTotalVat { get; set; }
        public List<Line> Lines { get; set; }
        public double ShippingCostsInclVat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public object CompanyRegistrationNo { get; set; }
        public object VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public object PaymentReferenceNo { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public object ChannelCustomerNo { get; set; }
        public ExtraData ExtraData { get; set; }
    }

    public class ExtraData
    {
        public string VAT_CALCULATION_METHOD_KEY { get; set; }

        [JsonProperty("Extra Data")]
        public string ExtraDatas { get; set; }
    }

    public class Line
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public double UnitVat { get; set; }
        public double LineTotalInclVat { get; set; }
        public double LineVat { get; set; }
        public double OriginalUnitPriceInclVat { get; set; }
        public double OriginalUnitVat { get; set; }
        public double OriginalLineTotalInclVat { get; set; }
        public double OriginalLineVat { get; set; }
        public double OriginalFeeFixed { get; set; }
        public object BundleProductMerchantProductNo { get; set; }
        public object JurisCode { get; set; }
        public object JurisName { get; set; }
        public double VatRate { get; set; }
        public List<object> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public double UnitPriceInclVat { get; set; }
        public double FeeFixed { get; set; }
        public double FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }

    public class Root
    {
        public List<Content> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public object RequestId { get; set; }
        public object LogId { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }

    public class ShippingAddress
    {
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public object Line3 { get; set; }
        public string Gender { get; set; }
        public object CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public object HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string CountryIso { get; set; }
        public object Original { get; set; }
    }

    public class StockLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ValidationErrors
    {
    }

    public class OrderView
    {
        public OrderView()
        {
            Content = new List<Content>();
        }
        public List<Content> Content { get; set; }
    }

    public class Product
    {
        public bool IsActive { get; set; }
        public List<ExtraDatum> ExtraData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Ean { get; set; }
        public string ManufacturerProductNumber { get; set; }
        public string MerchantProductNo { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double MSRP { get; set; }
        public double PurchasePrice { get; set; }
        public string VatRateType { get; set; }
        public double ShippingCost { get; set; }
        public string ShippingTime { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public object ExtraImageUrl1 { get; set; }
        public object ExtraImageUrl2 { get; set; }
        public object ExtraImageUrl3 { get; set; }
        public object ExtraImageUrl4 { get; set; }
        public object ExtraImageUrl5 { get; set; }
        public object ExtraImageUrl6 { get; set; }
        public object ExtraImageUrl7 { get; set; }
        public object ExtraImageUrl8 { get; set; }
        public object ExtraImageUrl9 { get; set; }
        public string CategoryTrail { get; set; }
    }

    public class ExtraDatum
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool IsPublic { get; set; }
    }

    public class ProductView
    {
        public Product Content { get; set; }
    }

    public class StockView
    {
        public string MerchantProductNo { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int StockLocationId { get; set; }
    }

    public class Order
    {        
        public string Gtin { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
    }


}

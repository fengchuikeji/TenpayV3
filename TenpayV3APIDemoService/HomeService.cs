using SKIT.FlurlHttpClient.Wechat.TenpayV3;
using SKIT.FlurlHttpClient.Wechat.TenpayV3.Models;
using SKIT.FlurlHttpClient.Wechat.TenpayV3.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenpayV3APIDemoService
{
    public class HomeService
    {
        public async Task<string> Transactions()
        {
            var certManager = new InMemoryCertificateManager();
            var options = new WechatTenpayClientOptions()
            {
                MerchantId = "MerchantId",
                MerchantV3Secret = "MerchantV3Secret",
                MerchantCertSerialNumber = "MerchantCertSerialNumber",
                MerchantCertPrivateKey = @"-----BEGIN PRIVATE KEY-----
		-----END PRIVATE KEY-----",
                CertificateManager = certManager
            };
            var client = new WechatTenpayClient(options);
            /* 以 JSAPI 统一下单接口为例 */
            var request = new CreatePayPartnerTransactionJsapiRequest()
            {
                AppId = "AppId",
                MerchantId = "MerchantId",
                SubMerchantId = "SubMerchantId",
                Description = "产品描述",
                OutTradeNumber = "2021081300000001",
                NotifyUrl = "https://wxapi.daxianghaoke.com/Home/PayNotify",
                Amount = new CreatePayTransactionJsapiRequest.Types.Amount()
                {
                    Total = 1
                },
                Payer = new CreatePayPartnerTransactionJsapiRequest.Types.Payer()
                {
                    OpenId = "oYfFe5F4RiHxgY37y64SEpPnFJTc"
                }
            };
            var response = await client.ExecuteCreatePayPartnerTransactionJsapiAsync(request);
            if (response.IsSuccessful())
            {
                return response.PrepayId;
            }
            else
            {
                return response.ErrorCode;
            }
        }
    }
}

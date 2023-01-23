using Moq;
using TPFinalWindowsForms;
using TPFinalWindowsForms.Api;

namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        //[TestCase]
        //public void Prueba()
        //{
        //    Mock<IJSONApiResponse> responseMock = new Mock<IJSONApiResponse>(); 
        //    string jsonBitcoin = "{\"data\": {\r\n    \"id\": \"bitcoin\",\r\n    \"rank\": \"1\",\r\n    \"symbol\": \"BTC\",\r\n    \"name\": \"Bitcoin\",\r\n    \"supply\": \"17193925.0000000000000000\",\r\n    \"maxSupply\": \"21000000.0000000000000000\",\r\n    \"marketCapUsd\": \"119179791817.6740161068269075\",\r\n    \"volumeUsd24Hr\": \"2928356777.6066665425687196\",\r\n    \"priceUsd\": \"6931.5058555666618359\",\r\n    \"changePercent24Hr\": \"-0.8101417214350335\",\r\n    \"vwap24Hr\": \"7175.0663247679233209\"\r\n  },\r\n  \"timestamp\": 1533581098863}";
        //    JSONApiResponse jsonApiResponse = new JSONApiResponse();
        //    var respuesta = jsonApiResponse.GetAPIResponseItem("https://api.coincap.io/v2/assets");
        //    Assert.AreEqual(respuesta, jsonBitcoin);

        //}

        [TestCase]
        public void CheckCryptoNameApi()
        {
            var interaccionApi = new TPFinalWindowsForms.DataCriptoAPI();
            List<String> pLista = new List<String>();
            pLista.Add("bitcoin");
            pLista.Add("ethereum");
            pLista.Add("tether");
            pLista.Add("xrp");
            var resultado = interaccionApi.GetFavCryptosDTO(pLista);
            Assert.AreEqual("BITCOIN", resultado[0].Name.ToUpper());
            Assert.AreEqual("ETHEREUM", resultado[1].Name.ToUpper());
            Assert.AreEqual("TETHER", resultado[2].Name.ToUpper());
            Assert.AreEqual("XRP", resultado[3].Name.ToUpper());
        }
        [TestCase]
        public void ConnectDB()
        {
            var context = new TPFinalWindowsForms.DAL.EntityFramework.DBContext();
            var repoUsuario = new TPFinalWindowsForms.DAL.EntityFramework.RepositorioUsuario(context);
            var usuario = repoUsuario.Get("0000");
            Assert.AreEqual("0000", usuario.Nickname);
            Assert.AreEqual("0000", usuario.Contraseña);
            Assert.AreEqual("0000@hotmail.com", usuario.Email);
            Assert.AreEqual("0000", usuario.Nombre);
            Assert.AreEqual("0000", usuario.Apellido);
            Assert.AreEqual("0000", usuario.Apellido);
            Assert.AreEqual(" bitcoin tether chainlink trust-wallet-token", usuario.Favcriptos);
            Assert.AreEqual(3.897, usuario.Umbral);
        }

    }
}
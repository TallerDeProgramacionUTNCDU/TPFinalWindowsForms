using Moq;
using System.Security.Cryptography;
using System.Xml.Linq;
using TPFinalWindowsForms;
using TPFinalWindowsForms.Api;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        [TestCase]

        public void TestCaminoFeliz()
        {
            Mock<IJSONApiResponse> fakeJsonMock=new Mock<IJSONApiResponse>();
            fakeJsonMock.SetupAllProperties();
            //Mock<JSONApiResponse> fakeJsonMock=new Mock<JSONApiResponse>();
            //var fakeJsonMock=new Mock<IJSONApiResponse>();
            fakeJsonMock.SetupProperty(d => d.Data , "{\r\n  \"data\": [\r\n    {\r\n      \"id\": \"bitcoin\",\r\n      \"rank\": \"1\",\r\n      \"symbol\": \"BTC\",\r\n      \"name\": \"Bitcoin\",\r\n      \"supply\": \"17193925.0000000000000000\",\r\n      \"maxSupply\": \"21000000.0000000000000000\",\r\n      \"marketCapUsd\": \"119150835874.4699281625807300\",\r\n      \"volumeUsd24Hr\": \"2927959461.1750323310959460\",\r\n      \"priceUsd\": \"6929.8217756835584756\",\r\n      \"changePercent24Hr\": \"-0.8101417214350335\",\r\n      \"vwap24Hr\": \"7175.0663247679233209\"\r\n    }\r\n  ],\r\n  \"timestamp\": 1533581088278\r\n}");
            DataCriptoAPI interaccionAPI = new DataCriptoAPI();
            List<CryptoDTO> lista = interaccionAPI.GetAllCrytosDTO(fakeJsonMock.Object.Data);

            Assert.AreEqual(lista[0].Id,"bitcoin");
            Assert.AreEqual(lista[0].Rank,"1");
            Assert.AreEqual(lista[0].Name,"Bitcoin");
            Assert.AreEqual(lista[0].PriceUSD,"6929.8217756835584756");
            Assert.AreEqual(lista[0].Symbol, "BTC");
            Assert.AreEqual(lista[0].ChangePercent24hs, "-0.8101417214350335");

        }

        /*
        public class CryptoCompare
        {
            private string iName;
            private string iSymbol;
            private string iId;

            public CryptoCompare(string pid, string pName, string pSymbol)
            {
                iId = pid;
                iName = pName;
                iSymbol = pSymbol;
            }
            public string Id
            {
                get { return iId; }
                set { iId = value; }
            }
            public string Name
            {
                get { return iName; }
                set { iName = value; }
            }
            public string Symbol
            {
                get { return iSymbol; }
                set { iSymbol = value; }
            }
        }

        [TestCase]
        public void TestResponseItems()
        {
            var lista = new List<CryptoCompare>();
            var bitcoinCompare = new CryptoCompare("bitcoin", "bitcoin", "btc");
            var conexionCryptos = new JSONApiResponse();
            conexionCryptos.GetAPIResponseItem("https://api.coincap.io/v2/assets");
            var response = conexionCryptos.data;
            bool resultado = false;
            foreach (var bResponseItem in response.data)
            {
                var objeto =  new CryptoCompare(bResponseItem.id.ToString().ToLower(), bResponseItem.name.ToString().ToLower(), bResponseItem.symbol.ToString().ToLower());
                lista.Add(objeto);
            }
            foreach (var crypto in lista)
            {
                if (crypto.Name == bitcoinCompare.Name && crypto.Id == bitcoinCompare.Id && crypto.Symbol == bitcoinCompare.Symbol )
                    resultado = true;
            }
            Assert.IsTrue(resultado);
        }

        private Newtonsoft.Json.Linq.JObject JSONResponse()
        {
            JSONApiResponse jsonApiResponse = new JSONApiResponse();
            jsonApiResponse.GetAPIResponseItem("https://api.coincap.io/v2/assets");
            return jsonApiResponse.data;
        }

        [TestCase]
        public void JSONResponseApiResponse()
        {
            var respuesta = JSONResponse().ToString();
            Assert.IsTrue(respuesta.Length>0);
        }

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
        */
    }
}
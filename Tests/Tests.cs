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
            var response = conexionCryptos.GetAPIResponseItem("https://api.coincap.io/v2/assets");
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
            return jsonApiResponse.GetAPIResponseItem("https://api.coincap.io/v2/assets");
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

    }
}
namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        [TestCase]
        public void CheckCryptoNameApi()
        {
            var interaccionApi = new TPFinalWindowsForms.InteraccionApi();
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
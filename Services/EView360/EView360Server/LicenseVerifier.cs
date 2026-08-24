using System;
using System.Text;
using LicenseVerifierLib;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Avanza.CCMS
{
    /// <summary>
    /// Summary description for LicenseVerifier.
    /// </summary>
    public class LicenseVerifier
    {
        int LicensedATMs = 5;
        int CheckLicense = 0;
        VerifyLicenseClass verifier;
        StringBuilder strBuilder;
        public bool valid = false;

        public int GetLicensedATMsCount()
        {
            if (this.CheckLicense > 0)
            {
                this.CheckLicense--;
                return this.LicensedATMs;
            }
            this.CheckLicense = 10;

            int maxAtms = 5;
            if (valid == false)
            {
                throw new Exception("INVALID License or Licenseverifier.dll COM not loaded.");
            }
            try
            {
                
                if (this.IsLicensed())
                {
                    maxAtms = verifier.GetTotalAtmAllowed();
                }
                else
                {
                    maxAtms = verifier.GetTotalAtmAllowed();
                    if (this.RemainingDays() < 0)
                        throw new Exception("Trial Expired");
                }

                this.LicensedATMs = maxAtms;
                int atmsCount = 0;
                SqlConnection conn = ConnectionFactory.GetNewConnection(DatabaseName.Core);
                // what will happen 
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select count(*) from atm where is_Active =1";
                atmsCount = (int)cmd.ExecuteScalar();
                conn.Close();
                return maxAtms;
            }
            catch (Exception ex)
            {
                throw new Exception(this.GetLastError() + ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// initializes with the private key
        /// </summary>
        public LicenseVerifier()
        {
            strBuilder = new StringBuilder();
            //strBuilder.Append("30820120300D06092A864886F70D01010105000382010D00308201080282010100AA7DD2173D952AB9CD13D0B692E38EDB9126D586A2BAD24A1BE0DDB76D0BFB8FC5480C5EB49B609B4D25A977802DFE7718248FCE9041B524F5FE5AB699EDD2CF68FF74D593E18F90CD3342360E50244A1ED29F61BE893EC067318104DE39A1F977DBE6C81891AC63F178566AEBFD4A91335B4B6975BC0EB56B2EE4E40DC6BFCCF1A5F5F9ABE278B8F80D9A0DF25941EBCF6991BD079AAE776BE607869C5C2F63D677CFCAE0B51920E6DB0B8C2DDF1D240304600B11EE7FF891C813D3507745E3DEBBA647C3E0FB75E02C98B538F3D80CAE639F081AE7AFD0FC38C9BC5C30418E3807B757C0BF41B3E27720F821E576A2DF3D9157EED81CD882538B86E4B5D343020111");
            strBuilder.Append("308204BB020100300D06092A864886F70D0101010500048204A5308204A10201000282010100D0C5CA088B167902F054E4940BEEE2CA294EA3B1E3C3A3F38BD3D136B795ACC57F6536E4BBE92300F7503F75067DB4049ECC82B52D0FD0197F900C8844506B7D5F2865A95C7DA007672990C7E0A39F43E7CBFAD54C3E8E46716506DC869DB07388DDD58298390037379BBDC3FF426753FA3C80F24FCE9178BBA80ACB690AE850572B373D90B45FADAE9A235A62B9300FAA1C33F06B4DF3CBF878CF35785D50038AC47AEAC330F8A1872D73F147D317EF2F72879CCF52270D5FE18523238459026490F238D3D3FB16CF13A0B9C657959091D51CD29165112F94CB48FB87C74BBB022422A0AD6B1B757FD9D8BE13B644C844734851C3A234B82B75C39871AA5B15020111028201000311F7AD4D56EB30FC013F98C3F0B082F913FAE0BBD1EF9667B40E5EEC1C8DD5BA5813A17B3BE6296D0C79675E368DF10255D4BEE64F4A96F694F1201F1F4CDFF61AF26FAAC59CB4D0936F4E3BC62BC0FFA4E1CE6E4C36CC547DB8924D46156B1C5D9D7E27E2B8794858E0E88784BDC13C26896CF9A4EB8D11D187B02AF4DDC4EB6C6D9B7F9C009FA30827065C66F0A43CEFD3469C21259AE7C953E715BDBBF16E93BEDA5B6FC9C51D78253D9AEE3022B6A5B2988A9DC71859626BC74235ADBF52F514405C8DA376082BE71DD1D038A4F3D1A282EC0C8691F94BA9865BE64E0DEC757B020ABEDA19BF9B3F756490C7C08E2A361F9ECCB41A7A735AF58985C05102818100E6C9D5EAD0726390B670580F5A3FB40746F65F92B0459286178B1F7DB35B8C6EA85E8780EDAA1528544C4E6AAED9A535C21BDEA510C670548BF741CA08E31CDCC771AAD58E66F649278FADF7D8B1FE437DD1F7C0CCD0D937AD2E900C7109F4232A6CFD781EB5733F52DAD70CB88EB71A25186263E17C91D0742B8539515606E102818100E7944404DAD1D1B5A9FF6D9A7D2190683371B59C423A64204F736655FE9BD773832741698BD54B1D5EF7412971B4A980E9533872ECA2D44115C5A26B845F15539405E64AAFCD99737BDA8ED632568B7C5053FA4B11407931AF83B13EAD909BE50882789DB403B95F47C22682A4B27E885C248587B3C5CBDF30A6152698CD3EB502818043E102AE798B0E399F11FBC847B86220420C3A3A33D83A277056185225B183A8136718CB9132063909BC1710518B4EB575537DB813FE2109CED04086B751DB4FFE6CB9C6570F3960CF667E76128EB431F7D457ED696A9A3D8D49EE21C6E4CF55A310FF4172719A5DEB314E4F091AEA8F38163B0E5160DF97A9B2727A45194D510281810095D8683F6069A5CFE67819BE50F799ACD5FE48560CBC5EE7BAF05146B3CE401D9119668F96B7309A88BE1B1AD11A8BCBE244E84A5CE1D4A2959DFFAEFB4C9554329A67D5F948CCB422F6D4E4F3652D1433FA1A6CCEED7B989EBE9FDD432155D06EEB02C0656BD24CB5F618EB1F4651DFC326B0C1381692F9D42F3ADCBD3982ED02818046D5A6F2222A81CD74C0C4FA1354E2B0B6AB79CE6CAEF7F9531B0E190AC5AD4E7D4C197FE56906F247922B03D66E2B02F9465C667416CBEF817235328BE3EFF949E68DEBC61029B2658BF7E283FE989CFD34C57D499788DAF53D3182130BB493E82182187B339EC8B381F95A73C73DDF8D881D0F2892E58CA75BBED10EE4CEB9");

            verifier = new VerifyLicenseClass();
            valid = true;
        }        /// <summary>

        /// initializes and validates license
        /// </summary>
        /// <returns></returns>
        public bool IsLicensed()
        {
            verifier.InitializeText(EView360Server.appSettings.LicenseKey, strBuilder.ToString());
            //LogableTask.LogMonoActivityTask("machineGUID", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, verifier.GetGUID());
            if (!verifier.ValidateLicense())
                throw new Exception("could not validate license");

            return verifier.IsLicensedVersion();
        }

        /// <summary>
        /// throw exception if expired
        /// </summary>
        /// <returns></returns>
        public int RemainingDays()
        {
            try
            {
                if (verifier.IsTrialExpired())
                    throw new Exception("Trial has Expired");
                
                string str = verifier.GetFromDate();
                string[] parts = str.Split('/');
                DateTime fromTime = new DateTime(int.Parse(parts[2].Split(':')[0]), int.Parse(parts[1]), int.Parse(parts[0]));
                TimeSpan datediff = DateTime.Today - fromTime;
                return (verifier.GetTotalDays() - (int)datediff.TotalDays);
            }
            catch
            {
                return -1;
            }
        }

        public string GetLastError()
        {
            return verifier.getLastError() + " Details : " + verifier.getLastErrorDetail();
        }

    }
}


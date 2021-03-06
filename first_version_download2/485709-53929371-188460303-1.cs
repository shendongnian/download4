    private string GetToken()
        {
            var dsa = GetECDsa();
            return CreateJwt(dsa, "keyId", "teamId");
        }
        
        private ECDsa GetECDsa()
        {
            using (TextReader reader = System.IO.File.OpenText("AuthKey_xxxxxxx.p8"))
            {
            var ecPrivateKeyParameters =
                (ECPrivateKeyParameters)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();
            var x = ecPrivateKeyParameters.Parameters.G.AffineXCoord.GetEncoded();
            var y = ecPrivateKeyParameters.Parameters.G.AffineYCoord.GetEncoded();
            var d = ecPrivateKeyParameters.D.ToByteArrayUnsigned();
            // Convert the BouncyCastle key to a Native Key.
            var msEcp = new ECParameters {Curve = ECCurve.NamedCurves.nistP256, Q = {X = x, Y = y}, D = d};
            return ECDsa.Create(msEcp);
            }
        }
        
        private string CreateJwt(ECDsa key, string keyId, string teamId)
        {
            var securityKey = new ECDsaSecurityKey(key) { KeyId = keyId };
            var credentials = new SigningCredentials(securityKey, "ES256");
            var descriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Issuer = teamId,
                SigningCredentials = credentials,
                
            };
            var handler = new JwtSecurityTokenHandler();
            var encodedToken = handler.CreateEncodedJwt(descriptor);
            return encodedToken;
        }

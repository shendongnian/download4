    //rootCert contains the rootcertificate in bouncycastle format
    var pemstring = "a string containing the PEM";
    PemReader pr = new PemReader (new StringReader (pemstring));
    Pkcs10CertificationRequest csr = (Pkcs10CertificationRequest)pr.ReadObject ();
    X509V3CertificateGenerator certgen = new X509V3CertificateGenerator();
    certgen.SetSubjectDN(csr.GetCertificationRequestInfo().Subject);
    certgen.SetIssuerDN(rootCert.SubjectDN);
    certgen.SetPublicKey(csr.GetPublicKey());
    certgen.SetSignatureAlgorithm(csr.SignatureAlgorithm.ObjectID.Id);
    certgen.SetNotAfter(validThrough); //a datetime object
    certgen.SetNotBefore(validFrom); //a datetime object
    certgen.SetSerialNumber(serialNumber); //a biginteger
    X509Certificate clientcert = certgen.Generate(rootPrivateKey);
    //to send the certificate without the private key to the client you'll have to 
    //convert it to PEM:
    StringBuilder sb = new StringBuilder();
    PemWriter pw = new PemWriter (new StringWriter (sb));
    pw.WriteObject (clientcert);
    pw.Writer.Flush ();
    var pemstring = sb.ToString ();
    //to make it a .net certificate use:
    X509Certificate2 netcert = DotNetUtilities.ToX509Certificate (clientcert);

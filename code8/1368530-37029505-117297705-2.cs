    var credentials = new StoredProfileAWSCredentials();
    //if dont works try to pass trhe profile name new StoredProfileAWSCredentials("ashu")
    using (IAmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client(credentials, RegionEndpoint.USWest2)) 
    {                  
        PutObjectRequest request = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = ps1,
            FilePath = path
        };
    
        PutObjectResponse response = s3Client.PutObject(request);
        richTextBox1.Text = response.ToString();
    }

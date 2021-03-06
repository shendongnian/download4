    using (HttpClient client = new HttpClient())
                        {
                            var request_json = "your json string";
                            var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                            var authenticationBytes = Encoding.ASCII.GetBytes("YourUsername:YourPassword");
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                                   Convert.ToBase64String(authenticationBytes));
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                            var result = await client.PostAsync("YourURL", content);
                            var result_string = await result.Content.ReadAsStringAsync();
                        }

        /// <summary>
        /// Gets the local Ipv4.
        /// </summary>
        /// <returns>The local Ipv4.</returns>
        /// <param name="networkInterfaceType">Network interface type.</param>
        IPAddress GetLocalIPv4(NetworkInterfaceType networkInterfaceType)
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(i => i.NetworkInterfaceType == networkInterfaceType && i.OperationalStatus == OperationalStatus.Up);
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                var adapterProperties = networkInterface.GetIPProperties();
                if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                {
                    foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address;
                        }
                    }
                }
            }
            return null;
        }

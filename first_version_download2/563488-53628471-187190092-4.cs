                _manager = new CallbackManager(_steamClient);
                _steamUser = _steamClient.GetHandler<SteamUser>();
                _steamFriends = _steamClient.GetHandler<SteamFriends>();
                _manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
                _manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
                _manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
                _manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);
                _manager.Subscribe<SteamUser.AccountInfoCallback>(OnAccountInfo);
                _manager.Subscribe<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth);
                _manager.Subscribe<SteamFriends.FriendMsgCallback>(OnChatMessage);
                _manager.Subscribe<SteamFriends.FriendsListCallback>(OnFriendList);
                Console.WriteLine("Connecting to steam in 3s");
                _steamClient.Connect();

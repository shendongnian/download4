        private Object thisLock = new Object();
        public TableMapping GetMapping(Type type, CreateFlags createFlags = CreateFlags.None)
		{
            lock (thisLock)
            {
                if (_mappings == null)
                {
                    _mappings = new Dictionary<string, TableMapping>();
                }
                TableMapping map;
                if (!_mappings.TryGetValue(type.FullName, out map))
                {
                    map = new TableMapping(type, createFlags);
                    _mappings[type.FullName] = map;
                }
                return map;
            }
		}

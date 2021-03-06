    dynamic parsed = JsonConvert.DeserializeObject(jsonString);
    Message message = MapToMessage(parsed);
    // ...
    private Message MapToMessage(dynamic json)
    {
        return new Message()
        {
            Type = json.Type,
            Name = json.Name,
            Data = ((IEnumerable<dynamic>)json.Data).Select(d =>
            {
                var dic = new Dictionary<string, string>();
                foreach (var v in d) dic.Add(v.Name, v.Value.Value);
                return dic;
             }).ToList()
        };
    }

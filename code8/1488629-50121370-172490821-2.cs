    /* Action code */
    [HttpPost]
    public Weird NOURLAuthenticate([FromBody] Weird form) {
        return form;
    }
    /* Model class code */
    public class Weird {
        public string UserId {get;}
        public string UserPwd {get;}
    }

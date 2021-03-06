        public static bool HasRoles(this Controller controller, string action, string[] roles)
        {
            var controllerType = controller.GetType();
            var method = controllerType.GetMethod(action);
    
            object[] filters = method.GetCustomAttributes(typeof(AuthorizeAttribute), true);
    
            if(!filters.Any())
            {
                throw new Exception();
            }
    
            var rolesOnCurrentMethodsAttribute = filters.SelectMany(attrib => ((AuthorizeAttribute)attrib).Roles.Split(new[] { ',' })).ToList();
    
            return roles.Except(rolesInMethod).Count() == 0 && rolesInMethod.Except(roles).Count() == 0;
        }

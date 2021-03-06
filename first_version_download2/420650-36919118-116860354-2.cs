    var query = (from project in db.ProjMasters
                 join pd in db.ProjDetails on project.ProjMasterID equals pd.ProjMasterID
                 join dc in db.DivCodes on project.DivisionCode equals dc.DivCode1
                 join ec in db.EmpCodes on project.ProjManager equals ec.UserNm
                 join ptc in db.ProjTypeCodes on pd.ProjTypeCode equals ptc.ProjTypeCode1
                 join psc in db.ProjStatusCodes on pd.ProjStatusCode equals psc.ProjStatusCode1
                 where pd.ProjDeleteDate == null
                     && (sProjType == null || ptc.TypeDesc == sProjType)
                     && (sTitle == null || project.Title.Contains(sTitle))
                 orderby project.Title
                 select new
                 {
                      project.ProjMasterID,
                      project.Title,
                      pd.ProjDesc,
                      pd.ContractNum,
                      pd.ProjDetailID,
                      dc.DivNm,
                 }).ReduceConstPredicates();

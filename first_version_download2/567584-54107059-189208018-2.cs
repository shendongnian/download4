    public ActionResult GenerateSupplyInformation(List<string> serialNumbers)
        {            
                if (serialNumbers != null)
                {
                    ViewBag.strmsg = "";
                    foreach (var serialNumber in serialNumbers)
                    {
                        if (!string.IsNullOrWhiteSpace(serialNumber))
                        {
                            var results = _ftRepository.GetSupplyInformation(serialNumber);
                            var filePath = _documentGenerator.GenerateSupplyInformation(serialNumber, results);
                            return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YourDownloadedFileName.xls");
                        }
                    }
                }
            }
            return null;
        }

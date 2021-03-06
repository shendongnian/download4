    ExcelRange rng = ws.Cells[statsTableRowStart, 10, statsTableRowStart + gud.levels.level.Count() - 1, 10];
    OfficeOpenXml.ConditionalFormatting.Contracts.IExcelConditionalFormattingExpression _condp01 = ws.ConditionalFormatting.AddExpression(rng);
    _condp01.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    _condp01.Style.Fill.BackgroundColor.Color = System.Drawing.Color.OrangeRed;
    _condp01.Formula = new ExcelFormulaAddress(rng.Address) + "<.01";
    OfficeOpenXml.ConditionalFormatting.Contracts.IExcelConditionalFormattingExpression _condp05 = ws.ConditionalFormatting.AddExpression(rng);
    _condp05.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    _condp05.Style.Fill.BackgroundColor.Color = System.Drawing.Color.OliveDrab;
    _condp05.Formula = new ExcelFormulaAddress(rng.Address) + "<.05";
    OfficeOpenXml.ConditionalFormatting.Contracts.IExcelConditionalFormattingExpression _condp1 = ws.ConditionalFormatting.AddExpression(rng);
    _condp1.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    _condp1.Style.Fill.BackgroundColor.Color = System.Drawing.Color.LightCyan;
    _condp1.Formula = new ExcelFormulaAddress(rng.Address) + "<.1";

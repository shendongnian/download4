    I have imported System.Windows.Forms; and then used this Code to 
    
    IWebElement checkbx = driver.FindElement(By.CssSelector("input#mf_file_FileUploaddiv.file"));
    Actions actions = new Actions(driver);
    actions = actions.MoveToElement(checkbx);
    actions = actions.Click();
    actions.Build().Perform();
    System.Windows.Forms.SendKeys.SendWait("C:\\Users\\Y.P.Singh\\Desktop\\ETS.txt");
    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
    System.Threading.Thread.Sleep(4000);
    driver.SwitchTo().DefaultContent();
    System.Threading.Thread.Sleep(10000);
    driver.FindElement(By.XPath("//a[@value='SAVE']")).Click();
    System.Threading.Thread.Sleep(10000);
                
    Thank You for Your Help!  
    Yatindra  
    QA Analyst

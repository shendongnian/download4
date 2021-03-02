        var regex = new Regex(@"\.((part0*1\.)?rar|001)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        Assert.That(regex.IsMatch("filename.001"));
        Assert.That(regex.IsMatch("filename.rar"));
        Assert.That(regex.IsMatch("filename.part1.rar"));
        Assert.That(regex.IsMatch("filename.part01.rar"));
        Assert.That(regex.IsMatch("filename.004"), Is.False);
        Assert.That(regex.IsMatch("filename.057"), Is.False);
        Assert.That(regex.IsMatch("filename.r67"), Is.False);
        Assert.That(regex.IsMatch("filename.s89"), Is.False);
        Assert.That(regex.IsMatch("filename.part2.rar"), Is.False);
        Assert.That(regex.IsMatch("filename.part04.rar"), Is.False);
        Assert.That(regex.IsMatch("filename.part11.rar"), Is.False);

var doc = XDocument.Parse(xml);
var namespaceAttributes = doc.Descendants()
    .SelectMany(x => x.Attributes())
    .Where(x => x.IsNamespaceDeclaration);
int count = 1;
foreach (var namespaceAttribute in namespaceAttributes)
{
    doc.Root.Add(new XAttribute(XNamespace.Xmlns + $"h{count}", namespaceAttribute.Value));
    namespaceAttribute.Remove();
    count++;
}
We loop through all namespace declarations (`xmlns:foo="foo"`). For each one we find, we put a namespace attribute with the same URL on the root element, and remove that one.
Note that this does slightly odd things if you have multiple namespaces with the same URL (e.g. if you have two lots of `xmlns:h="https://www.namespaces.com/namespaceOne"` on different children): it puts multiple `xmlns` declarations on the root element with the same URL, but all elements use the last such namespace. If you want to avoid that, just keep a list of namespaces you've added to the root element.
